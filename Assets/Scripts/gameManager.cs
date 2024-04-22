using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    questManager qManager;
    guildManager gManager;

    [SerializeField] GameObject playerIdPrefab;
    [SerializeField] GameObject questCardPrefab;
    public List<GameObject> playerPositions = new List<GameObject>();
    public List<GameObject> idPositions = new List<GameObject>();
    private List<GameObject> idsList = new List<GameObject>();
    private GameObject questCard;
    public GameObject questPosition;

    private int playersKilled = 0;
    private int correctQuests = 0;
    private int wrongQuests = 0;
    void Start(){
        qManager = gameObject.GetComponent<questManager>();
        gManager = gameObject.GetComponent<guildManager>();

        createLevel();
    } 

    public void getIDs(){
        for (int i = 0; i < gManager.guildList.Count; i++){
            playerStatus player = gManager.guildList[i].GetComponent<playerStatus>();

            GameObject id = Instantiate(playerIdPrefab, idPositions[i].transform.position, Quaternion.identity);
            idsList.Add(id);
            id.GetComponent<idManager>().setStatus(player.playerName, player.getLevel().ToString(),player.getPower().ToString(), player.getClass().ToString());
        }
    }

    private void createLevel(){
        gManager.createGuild(Random.Range(1, 5));
        qManager.createQuest();

        questCard = Instantiate(questCardPrefab, questPosition.transform.position, Quaternion.identity);
        
        questCard.GetComponent<questCardManager>().setStatus("quest maneira", qManager.minLevel.ToString(), qManager.maxLevel.ToString(), qManager.questPower.ToString(), qManager.requiredClass.ToString());
        getIDs();
    }

    public void goToNextLevel(bool isAccepted){

        // Valida a quest
        bool result = qManager.validateQuest(gManager.totalGuildPower, gManager.minGuildLevel, gManager.maxGuildLevel, gManager.guildList);

        // Analisa se o player acertou
        if (!(result ^ isAccepted)){
            correctQuests += 1;
        }
        else{
            wrongQuests += 1;
            playersKilled += gManager.guildList.Count;
        }
        // Limpa o nível anterior
        foreach (GameObject player in gManager.guildList)
        {
            Destroy(player);
        }
        gManager.guildList.Clear();
        foreach (GameObject id in idsList)
        {
            Destroy(id);
        }
        idsList.Clear();
        Destroy(questCard);


        // Inicia o próximo nível
        createLevel();

    }
}


