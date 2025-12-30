using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action ClickedButtonSpace;
    public event Action ClickedButtonR;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClickedButtonSpace?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ClickedButtonR?.Invoke();
        }
    }
}
