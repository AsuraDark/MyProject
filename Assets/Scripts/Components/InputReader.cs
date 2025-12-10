using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public event Action<float> ClickedAnyDirection;
    public event Action<float> ClickedUpDirection;
    public event Action ClickedFButton;

    private void Update()
    {
        float directionHorizontal = Input.GetAxis(Horizontal);
        float directionVertical = Input.GetAxis(Vertical);

        if (directionHorizontal >= 0 || directionHorizontal <= 0)
        {
            ClickedAnyDirection?.Invoke(directionHorizontal);
        }
        
        if (directionVertical >= 0)
        {
            ClickedUpDirection?.Invoke(directionVertical);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ClickedFButton?.Invoke();
        }
    }
}