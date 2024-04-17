using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guildManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    public List<GameObject> guildList = new List<GameObject>();
    gameManager gm;

    public int totalGuildPower = 0;
    public int maxGuildLevel = 0;
    public int minGuildLevel = 100;

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }
    public void createGuild(int playerCount){
        for (int i = 0; i < playerCount; i++){
            guildList.Add(Instantiate(playerPrefab, gm.playerPositions[i].transform.position, Quaternion.identity));
            playerStatus.classesList playerClass = playerStatus.classesList.None; // tempvalue

            switch (Random.Range(1,3)){
                case 1:
                    playerClass = playerStatus.classesList.Warrior;
                    break;
                case 2:
                    playerClass = playerStatus.classesList.Archer;
                    break;
                case 3:
                    playerClass = playerStatus.classesList.Mage;
                    break;
            }

            guildList[i].GetComponent<playerStatus>().setStatus(Random.Range(1, 50), Random.Range(1, 100), playerClass);
        }
        getGuildPower();

    }

    public void getGuildPower(){
        foreach (GameObject player in guildList){
            playerStatus sPlayer = player.GetComponent<playerStatus>();

            if (sPlayer.getLevel() >= maxGuildLevel) maxGuildLevel = sPlayer.getLevel();
            if (sPlayer.getLevel() <= minGuildLevel) minGuildLevel = sPlayer.getLevel();

            totalGuildPower += sPlayer.getPower();
        }
    }
}
