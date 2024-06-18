using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BuyJelly : MonoBehaviour
{
    [SerializeField] private GameObject jellyPrefab;
    [SerializeField] private Sprite[] jellyImages;
    [SerializeField] private Jelly[] jellys;
    [SerializeField] private int index = 0;
    [SerializeField] private TextMeshProUGUI needJellyText;
    [SerializeField] private Image jellyIcon;
    [SerializeField] private Button rockClearButton;
    [SerializeField] private Button buyButton;

    private int[] costJelly =
    {50,70,100,150,200,250,300,350,400,450,500,550
    };
    private int[] needJelly =
    {0,100,200,300,400,500,600,700,800,900,1000,1100 
    };
    private bool[] isOpen =
{true,false,false,false,false,false,false,false,false,false,false,false
    };
    private void OnEnable()
    {
        index = 0;
        SetInfo();
    }

    public void IncreaseIndex()
    {
        if(index >= jellyImages.Length-1)
        {
            index = 0;
            return;
        }    
        index++;
        SetInfo();
    }

    public void DecreaseIndex()
    {
        if(index ==0)
        {
            index = jellyImages.Length-1;
            return;
        }
        index--;
        SetInfo();
    }

    private void SetInfo()
    {
        jellyIcon.sprite = jellyImages[index];
        if (isOpen[index])
        {
            rockClearButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            needJellyText.text = costJelly[index].ToString();
        }
        else
        {
            rockClearButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            needJellyText.text = needJelly[index].ToString();
        }
    }
    public void OpenJelly()
    {
        if (GameManager.Instance.jelly < needJelly[index])
            return;

        GameManager.Instance.jelly -= needJelly[index];
        GameManager.Instance.CallUIEvent();

        isOpen[index] = true;
        SetInfo();
    }

    public void BuyJelly()
    {
        if (GameManager.Instance.jelly < costJelly[index])
            return;

        if (GameManager.Instance.jellyCount >= GameManager.Instance.jellyMaxCount)
            return;

        GameManager.Instance.jellyCount++;
        GameManager.Instance.jelly -= costJelly[index];
        GameManager.Instance.CallUIEvent();

        GameObject go = Instantiate(jellyPrefab, Vector3.zero, Quaternion.identity);
        go.transform.SetParent(GameManager.Instance.jellyContainer);
        go.GetComponentInChildren<SpriteRenderer>().sprite = jellyImages[index];
        go.GetComponent<InputSystem>().jellySO = jellys[index];
    }
}
