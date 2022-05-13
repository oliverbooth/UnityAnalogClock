using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents a behavior which controls the digital clock.
/// </summary>
public class DigitalClock : MonoBehaviour
{
    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        GetComponent<Text>().text = DateTime.Now.ToString("HH:mm:ss");
    }
}
