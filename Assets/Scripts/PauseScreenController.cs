using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseScreenController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI muteText;

    private void Start()
    {
        GameManager.Instance.isGamePaused = true;
        muteText.gameObject.SetActive(GameManager.Instance.isGameMute);
    }

    public void ResumeGame()
    {
        GameManager.Instance.isTouchEnabled = true;
        GameManager.Instance.isGamePaused = false;
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnMuteButtonClicked()
    {
        if (GameManager.Instance.isGameMute)
        {
            GameManager.Instance.audioManager.UnmuteAllAudio();
            muteText.gameObject.SetActive(false);
            GameManager.Instance.isGameMute = false;
        }
        else
        {
            GameManager.Instance.audioManager.MuteAllAudio();
            muteText.gameObject.SetActive(true);
            GameManager.Instance.isGameMute = true;
        }

    }
}
