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

    private float Timer2 = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkLevelFinish())
        {
            if (Timer2 <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            Timer2 -= Time.deltaTime;
            if (Input.anyKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }


    // check if this level finished
    bool checkLevelFinish() 
    {
        if (player.transform.position == FinishPoint.position && player_past.transform.position == FinishPoint_past.position) 
        {
            NextLevelPanel.SetActive(true);
            return true;
        }
        return false;
    }
}
