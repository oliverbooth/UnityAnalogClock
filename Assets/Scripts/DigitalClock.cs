using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     Represents a behavior which controls the digital clock.
/// </summary>
public class DigitalClock : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
