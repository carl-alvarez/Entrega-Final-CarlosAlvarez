using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    int score;

    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] AudioSource musicSkybox;

    [SerializeField] PlayerMovement playerMovement;

    public GameObject EscapeMenu;

    public GameObject Ganaste1;
    public GameObject Ganaste2;

    public GameObject Perdiste1;
    public GameObject Perdiste2;

    public string levelUno;
    public string levelDos;

    Scene scene;
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
        scene = SceneManager.GetActiveScene();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            EscapeMenu.SetActive(true);
        }

        WonUI();
        LoseUI();

    }
    
    public void GoPlay()
    {
        EscapeMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }

    public void WonUI()
    {
        if (score == 25 && scene.name == levelUno) 
        {            
            Time.timeScale = 0.0f;
            Ganaste1.SetActive(true);
            musicSkybox.gameObject.GetComponent<AudioSource>().Stop();
            playerMovement.GetComponent<AudioSource>().Stop();
        }

        if (score == 25 && scene.name == levelDos) 
        {
            Time.timeScale = 0.0f;
            Ganaste2.SetActive(true);
            musicSkybox.gameObject.GetComponent<AudioSource>().Stop();
            playerMovement.GetComponent<AudioSource>().Stop();

        }
    }

    public void LoseUI()
    {
        if (playerMovement.gameObject.GetComponent<PlayerMovement>().alive == false && scene.name == levelUno)
        {
            Time.timeScale = 0.0f;
            Perdiste1.SetActive(true);
            musicSkybox.gameObject.GetComponent<AudioSource>().Stop();
            playerMovement.GetComponent<AudioSource>().Stop();

        }

        if (playerMovement.gameObject.GetComponent<PlayerMovement>().alive == false && scene.name == levelDos)
        {
            Time.timeScale = 0.0f;
            Perdiste2.SetActive(true);
            musicSkybox.gameObject.GetComponent<AudioSource>().Stop();
            playerMovement.GetComponent<AudioSource>().Stop();
        }
    }
}
