using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public enum classesList {
        None, 
        Warrior,
        Archer,
        Mage
    }

    private int power = 0;
    private int level = 1;
    private classesList playerClass;
    public string playerName = "";
    string[] playerNames = { "xXNightSlayerXx", "j0sh241", "lililillililil", 
    "betterthanu", "cheezkk", "adamalfred87", 
    "berma387", "wowisbetter", "n00bplr", 
    "imsmurfing", "n0tab0t", "icecreamking", 
    "boberts", "__extreme.gamer__", "imthedevgivemecoins", 
    "npckiller", "munkin", "tilili", 
    "konners", "_gregojogos_", "ixterzinhagameplays", 
    "rawlynx", "fishpoles", "zenor13", "alexaboveheaven",
    "Destoroyah2131", "Bgkuk", "XX_xx_XX", "propteses", 
    "pepe323", "ynup", "Pogginton" };
    void Awake(){
        playerName = playerNames[Random.Range(0, playerNames.Length)];
    }
    public void setStatus(int power, int level, classesList playerClass){
        this.power = power;
        this.level = level;
        this.playerClass = playerClass;
    }

    public int getPower(){
        return power;
    }

    public int getLevel(){
        return level;
    }

    public classesList getClass(){
        return playerClass;
    }

}
