#region Using Directives

using System;
using UnityEngine;

#endregion

/// <summary>
/// Represents a behavior which controls a clock hand.
/// </summary>
public class ClockHand : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// The hand type.
    /// </summary>
    public HandType Type = HandType.Second;

    /// <summary>
    /// The movement type.
    /// </summary>
    public HandMovement Movement = HandMovement.Smooth;

    #endregion

    #region Methods

    /// <summary>
    /// Called when the object is enabled.
    /// </summary>
    private void Start()
    {
        this.SetValue();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        this.SetValue();
    }

    /// <summary>
    /// Sets the clock value.
    /// </summary>
    private void SetValue() =>
        this.SetValue(DateTime.Now);

    /// <summary>
    /// Sets the clock value.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> instance to use.</param>
    private void SetValue(DateTime dateTime)
    {
        float v           = 0,
              max         = 60.0f,
              hour        = Convert.ToInt32(dateTime.ToString("hh")),
              minute      = dateTime.Minute,
              second      = dateTime.Second,
              millisecond = dateTime.Millisecond;

        if (this.Movement == HandMovement.Smooth)
        {
            second += millisecond / 1000.0f;
            minute += second      / 60.0f;
            hour   += minute      / 60.0f;
        }

        switch (this.Type)
        {
            case HandType.Second:
                v = second;
                break;
            case HandType.Minute:
                v = minute;
                break;
            case HandType.Hour:
                v   = hour;
                max = 12.0f;
                break;
        }

        this.transform.localEulerAngles = new Vector3(0.0f, v / max * 360.0f, 0.0f);
    }

    #endregion
}
