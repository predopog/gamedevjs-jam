using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{
    public int questPower = 0;
    public int minLevel = 0;
    public int maxLevel = 0;
    public playerStatus.classesList requiredClass = playerStatus.classesList.None;
    public void createQuest(){
        questPower = Random.Range(0, 125);

        // Se existe uma classe obrigatória
        switch (Random.Range(0,3)){
            case 0:
                requiredClass = playerStatus.classesList.None;
                break;
            case 1:
                requiredClass = playerStatus.classesList.Warrior;
                break;
            case 2:
                requiredClass = playerStatus.classesList.Archer;
                break;
            case 3:
                requiredClass = playerStatus.classesList.Mage;
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
}
