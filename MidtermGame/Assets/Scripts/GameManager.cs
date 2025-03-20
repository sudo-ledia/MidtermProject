using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    
    public int score;
    public int highScore;
    private void Awake()
    {
        // makes sure singleton player object doesnt destroy while loading
        if(Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        // makes sure there's onle one singleton player object
        else{
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if (player == null) 
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if(!player.activeSelf)
        {
            Debug.Log("Player Killed");
            SceneManager.LoadScene(0);
        }

        if (player.transform.position.y > score)
        {
            score = player.transform.position.y;
        }
    }


}
