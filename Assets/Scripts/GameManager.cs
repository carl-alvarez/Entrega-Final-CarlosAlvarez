using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;

    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

    public GameObject EscapeMenu;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score:  " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            EscapeMenu.SetActive(true);
        }
        
    }
    
    public void GoPlay()
    {
        EscapeMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
