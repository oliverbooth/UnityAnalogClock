using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///     Represents a behavior which controls a clock hand.
/// </summary>
public class ClockHand : MonoBehaviour
{
    [SerializeField, FormerlySerializedAs("Type")] private HandType _type = HandType.Second;
    [SerializeField, FormerlySerializedAs("Movement")] private HandMovement _movement = HandMovement.Smooth;

    private void Start()
    {
        SetValue();
    }

    private void Update()
    {
        SetValue();
    }

    private void SetValue()
    {
        SetValue(DateTime.Now);
    }

    private void SetValue(DateTime dateTime)
    {
        float v = 0,
            max = 60.0f,
            hour = 12 + dateTime.Hour % 12,
            minute = dateTime.Minute,
            second = dateTime.Second,
            millisecond = dateTime.Millisecond;

        if (_movement == HandMovement.Smooth)
        {
            second += millisecond / 1000.0f;
            minute += second / 60.0f;
            hour += minute / 60.0f;
        }

        switch (_type)
        {
            case HandType.Second:
                v = second;
                break;
            case HandType.Minute:
                v = minute;
                break;
            case HandType.Hour:
                v = hour;
                max = 12.0f;
                break;
        }

        transform.localEulerAngles = new Vector3(0.0f, v / max * 360.0f, 0.0f);
    }
}
