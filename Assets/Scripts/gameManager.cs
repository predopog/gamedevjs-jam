using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    questManager qManager;
    guildManager gManager;

    public List<GameObject> playerPositions = new List<GameObject>();
    void Start()
    {
        qManager = gameObject.GetComponent<questManager>();
        gManager = gameObject.GetComponent<guildManager>();

        gManager.createGuild(Random.Range(1,5));
        qManager.createQuest();
    }
}
