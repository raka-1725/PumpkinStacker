using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SQuit : MonoBehaviour
{
    private void Update()
    {
        if (Gamepad.current.startButton.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
