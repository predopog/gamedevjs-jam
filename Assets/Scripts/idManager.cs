using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class idManager : MonoBehaviour
{
    [SerializeField] TMP_Text username;
    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text power;
    [SerializeField] TMP_Text className;

    gameManager gm;

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }
    
    public void setStatus(string user, string vlevel, string vpower, string vclassName){
        username.text = user;
        level.text = "Level: "+vlevel;
        power.text = "Power: "+vpower;
        className.text = vclassName;

    }
}
