using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI jellyText;
    [SerializeField]
    private TextMeshProUGUI jellyCountText;
    [SerializeField]
    private TextMeshProUGUI goldOffsetText;
    [SerializeField]
    private TextMeshProUGUI jellyOffsetText;
    private void Start()
    {
        GameManager.Instance.uiUpdate += SetText;
        SetText();
    }

    private void SetText()
    {
        goldText.text = GameManager.Instance.gold.ToString();
        jellyText.text  = GameManager.Instance.jelly.ToString();
        jellyCountText.text = $"{GameManager.Instance.jellyCount} / {GameManager.Instance.jellyMaxCount}";
        goldOffsetText.text = $"½Ã°£´ç °ñµå È¹µæ + {GameManager.Instance.goldOffset}";
        jellyOffsetText.text = $"½Ã°£´ç Á©¸® È¹µæ + {GameManager.Instance.jellyOffset}";
    }
}
