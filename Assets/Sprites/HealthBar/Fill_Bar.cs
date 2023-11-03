using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fill_Bar : MonoBehaviour
{
    public Image fill_Bar;
    public TextMeshProUGUI value;

    public void UpdateBar(int currentValue, int MaxValue)
    {
        fill_Bar.fillAmount = (float)currentValue / (float)MaxValue;
        value.text = currentValue.ToString() + " / " +MaxValue.ToString();
    }
}
