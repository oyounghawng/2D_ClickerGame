using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCostText;
    [SerializeField] private TextMeshProUGUI jellyCostText;
    [SerializeField] private TextMeshProUGUI maxjellyCostText;

    int goldCost = 100;
    int jellyCost = 100;
    int maxjellyCost = 100;

    private void Start()
    {
        SetInfo();
    }

    private void SetInfo()
    {
        goldCostText.text = goldCost.ToString();
        jellyCostText.text = jellyCost.ToString();
        maxjellyCostText.text = maxjellyCost.ToString();
    }
    public void BuyGoldOffset()
    {
        if (goldCost > GameManager.Instance.gold)
            return;

        GameManager.Instance.gold -= goldCost;
        GameManager.Instance.goldOffset++;
        goldCost += 50;
        GameManager.Instance.CallUIEvent();
        SetInfo();
    }
    public void BuyJellyOffset()
    {
        if (jellyCost > GameManager.Instance.gold)
            return;

        GameManager.Instance.gold -= jellyCost;
        GameManager.Instance.jellyOffset++;
        jellyCost += 50;
        GameManager.Instance.CallUIEvent();
        SetInfo();

    }
    public void BuyJellyMaxCount()
    {
        if (maxjellyCost > GameManager.Instance.gold)
            return;

        GameManager.Instance.gold -= maxjellyCost;
        GameManager.Instance.jellyMaxCount++;
        maxjellyCost += 50;
        GameManager.Instance.CallUIEvent();
        SetInfo();
    }
}
