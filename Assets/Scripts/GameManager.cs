using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private List<Food> foods;
    public AudioManager audioManager;
    public ChefController chefController;
    public TextMeshProUGUI scoreText;

    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject scorePanel;

    public int scoreTokeepItemOnFride = 10;
    public int scoreToKeepItemOnTable = 10;
    public float timer = 60;
    private string text = "Start cleaning the fridge";
    int score;

    public bool isGameMute;
    internal bool isTouchEnabled;
    public bool isGamePaused;


    public UnityAction openScorePanel;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        chefController.Init(true, text);
        isTouchEnabled = true;
        openScorePanel += OpenScoreScreen;
    }

    public bool isAnyItemPresentInFirdge()
    {
        for(int i = 0; i < foods.Count; i++)
        {
            if (foods[i].isNearFridge)
                return true;
        }

        return false;
    }


    public void IncrementScore(int _score)
    {
        score += _score;
        scoreText.text = "Score: " + score;
    }

    public void OpenPauseScreen()
    {
        if (!isTouchEnabled)
            return;
        isTouchEnabled = false;

        PausePanel.SetActive(true);
    }

    public void OpenScoreScreen()
    {
        scorePanel.SetActive(true);
        openScorePanel -= OpenScoreScreen;
    }
}
