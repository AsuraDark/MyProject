using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    const KeyCode KeyCodeSpace = KeyCode.Space;
    const KeyCode KeyCodeR = KeyCode.R;

    public event Action ClickedButtonSpace;
    public event Action ClickedButtonR;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCodeSpace))
        {
            ClickedButtonSpace?.Invoke();
        }

        if (Input.GetKeyDown(KeyCodeR))
        {
            ClickedButtonR?.Invoke();
        }
    }
}
