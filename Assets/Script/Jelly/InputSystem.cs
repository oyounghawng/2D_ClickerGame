using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Jelly jellySO;

    private int exp = 0;
    private int level = 0;
    private JellyController jellyController;

    private void Awake()
    {
        jellyController = GetComponent<JellyController>();
    }

    private void Start()
    {
        StartCoroutine(AutoGoldJelly());
    }

    IEnumerator AutoGoldJelly()
    {
        while (true)
        {
            exp += 1;
            CheckLevelUp();
            GameManager.Instance.gold += jellySO.gold[level] + GameManager.Instance.goldOffset;
            GameManager.Instance.jelly += jellySO.jelly[level] + GameManager.Instance.jellyOffset;
            GameManager.Instance.CallUIEvent();
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnMouseDown()
    {
        StopAllCoroutines();
        exp += 1;
        CheckLevelUp();
        GameManager.Instance.gold += jellySO.gold[level] + GameManager.Instance.goldOffset;
        GameManager.Instance.jelly += jellySO.jelly[level] + +GameManager.Instance.jellyOffset;
        StartCoroutine(AutoGoldJelly());
        jellyController.CallTouchEvent();
        GameManager.Instance.CallUIEvent();
    }

    private void CheckLevelUp()
    {
        if (level >= 2)
            return;
        else
        {
            if (exp >= jellySO.needexp[level])
            {
                exp = 0;
                level++;
                GetComponent<AnimationSystem>().SetAnimationController(level);
            }
        }
    }
}
