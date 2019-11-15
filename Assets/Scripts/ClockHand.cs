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
        float y = 0;

        switch (this.Type)
        {
            case HandType.Second:
                y = dateTime.Second / 60.0f * 360.0f;
                break;
            case HandType.Minute:
                y = dateTime.Minute / 60.0f * 360.0f;
                break;
            case HandType.Hour:
                int hour = Convert.ToInt32(dateTime.ToString("hh"));
                y = hour / 12.0f * 360.0f;
                break;
        }

        Vector3 euler = this.transform.localEulerAngles;
        euler.y = y;

        this.transform.localEulerAngles = euler;
    }

    #endregion
}
