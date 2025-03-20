using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    
    public int score = 0;
    public int highScore = 0;
    public int finalScore = 0;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text finalScoreText;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {   
        //debug button
        /*if(Input.GetKey(KeyCode.E))
        {
            UpdateScoreText();
        }
        */

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            UpdateScoreText();
        }
        
        if(Input.GetKey(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //or
            // SceneManager.Load("GameScene");
        }

        if(Input.GetKey(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (player == null) 
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
        if (player.transform.position.y > score)
        {
            score = (int) player.transform.position.y;
            UpdateScoreText();
        }

        if(player != null)
        {
            if(!player.activeSelf)
            {
                if (score > highScore)
                {
                    highScore = score;
                }
                Debug.Log("Player Killed");
                finalScore = score;
                score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
        }
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreText = GameObject.FindGameObjectWithTag("Score")?.GetComponent<TMP_Text>();
        highScoreText = GameObject.FindGameObjectWithTag("HighScore")?.GetComponent<TMP_Text>();
        finalScoreText = GameObject.FindGameObjectWithTag("FinalScore")?.GetComponent<TMP_Text>();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
        finalScoreText.text = "Final Score: " + finalScore;
    }
}
