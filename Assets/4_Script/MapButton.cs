using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security;

public class MapButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNumber;
    [SerializeField] private Image imageCleared;
    private int number;

    public void SetNumber(int value)
    {
        number = value;
        textNumber.text = $"{number:00}";
    }
    public void SetCleared(bool value)
    {
        imageCleared.gameObject.SetActive(value);
    }
    /// <summary>
    /// 멥 데이터 ㅂ르고 시작하기
    /// </summary>
    public void LoadMap()
    {
        GameManager.instance.StartPlay(number);
    }
}
