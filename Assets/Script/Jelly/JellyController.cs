using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnTouchEvent;

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

    public void CallTouchEvent()
    {
        OnTouchEvent?.Invoke();
    }
}
