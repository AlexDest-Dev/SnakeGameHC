using UnityEngine;

public class MobileInput : IInput
{
    private readonly float _screenRatio;
    public MobileInput()
    {
        _screenRatio = (float)Screen.width / Screen.height;
    }
    public Vector2 GetDeltaPosition() => 
        Input.touchCount > 0 ? Input.GetTouch(0).deltaPosition * _screenRatio : Vector2.zero;
}