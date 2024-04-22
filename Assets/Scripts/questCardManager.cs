using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questCardManager : MonoBehaviour
{
    [SerializeField] TMP_Text questTitle;
    [SerializeField] TMP_Text maxLevel;
    [SerializeField] TMP_Text minLevel;
    [SerializeField] TMP_Text power;
    [SerializeField] TMP_Text reqClass;

    public void setStatus(string title, string minlevel, string maxlevel, string vpower, string vclassName)
    {
        questTitle.text = title;
        maxLevel.text = "Max Level: " + maxlevel;
        minLevel.text = "Min Level: " + minlevel;
        power.text = "Power: " + vpower;
        reqClass.text = "Req. Class: " + vclassName;

    }
}

