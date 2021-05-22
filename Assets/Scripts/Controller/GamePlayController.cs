using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel,pausePanel;
   

    [SerializeField]
    private Button ResumeButton, PauseButton;

    [SerializeField]
    private Button ResumeMenuClick;

    void _MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }
    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);

    }
    public void _ResumeMenuButton()
    {
        gameOverPanel.SetActive(false);
        ResumeButton.gameObject.SetActive(true);
        Application.LoadLevel("GamePlay");
        SceneManager.LoadScene("GamePlay");
    }
    public void _ResumeMenu()
    {
        Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
    public void _SetScore(int score)
    {
        scoreText.text = score.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        gameOverPanel.SetActive(false);
     if(BirdController.instance.flag == 1)
        {
            gameOverPanel.SetActive(true);
            endScoreText.text = scoreText.text;
            if(BirdController.instance.Score > Game_Manager.instance.GetHighScore())
            {
                Game_Manager.instance.SetHighScore(BirdController.instance.Score);
            }
            bestScoreText.text = Game_Manager.instance.GetHighScore().ToString();
        }   
    }
    public void _PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
