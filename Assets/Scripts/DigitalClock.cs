#region Using Directives

using System;
using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// Represents a behavior which controls the digital clock.
/// </summary>
public class DigitalClock : MonoBehaviour
{
    #region Methods

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        this.GetComponent<Text>().text = DateTime.Now.ToString("HH:mm:ss");
    }

    #endregion
}
