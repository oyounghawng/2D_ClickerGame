using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int gold;
    public int jelly;
    public int jellyCount = 1;
    public int jellyMaxCount = 2;
    public int goldOffset;
    public int jellyOffset;


    public event Action uiUpdate;
    public Transform jellyContainer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CallUIEvent()
    {
        uiUpdate?.Invoke();
    }
}
