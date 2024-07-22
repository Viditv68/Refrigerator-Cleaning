using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;


    private void Start()
    {
        text.text =  GameManager.Instance.scoreText.text;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }


}
