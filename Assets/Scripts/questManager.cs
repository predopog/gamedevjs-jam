using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{
    public int questPower = 0;
    public int minLevel = 0;
    public int maxLevel = 0;
    public playerStatus.classesList requiredClass = playerStatus.classesList.None;
    private bool bRequiredClass = false;
    public void createQuest(){
        questPower = Random.Range(0, 125);

        // Se existe uma classe obrigatória
        switch (Random.Range(1,6)){ // 50% de ter uma classe e 50% de não ter
            case 1:
                requiredClass = playerStatus.classesList.Warrior;
                break;
            case 2:
                requiredClass = playerStatus.classesList.Archer;
                break;
            case 3:
                requiredClass = playerStatus.classesList.Mage;
                break;

            default:
                requiredClass = playerStatus.classesList.None;
                break;
        }

        // Se existe um level máximo
        if (Random.Range(0,1) == 0){
            maxLevel = Random.Range(5, 100);

            // Se existe um level mínimo
            if (Random.Range(0, 1) == 0)
            {
                minLevel = Random.Range(5, maxLevel);
            }
        }
        
    }

    public bool validateQuest(int guildPower, int guildMinLevel, int guildMaxLevel, List<GameObject> playersList){
    
        if (guildPower < questPower) return false;
    
        if (guildMinLevel < minLevel) return false;

        if (guildMaxLevel > maxLevel) return false;

        foreach (GameObject player in playersList)
        {
            if (player.GetComponent<playerStatus>().getClass() == requiredClass) bRequiredClass = true;
        }

        if (!bRequiredClass) return false;

        // Se passar por todas as validações
        return true;
    }
}
