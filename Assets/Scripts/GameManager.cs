using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform FinishPoint;
    public Transform SpawnPoint_past;
    public Transform FinishPoint_past;
    public GameObject Teleport_Entry;
    public GameObject Teleport_Exit;
    

    public GameObject NextLevelPanel;


    public GameObject player;
    public GameObject player_past;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkLevelFinish();
    }


    // check if this level finished
    void checkLevelFinish() 
    {
        if (player.transform.position == FinishPoint.position && player_past.transform.position == FinishPoint_past.position) 
        {
            NextLevelPanel.SetActive(true);
        }
    }
}
