using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = GameManager.Instance.timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGamePaused)
        {
            if (totalTime > 0)
            {
                // Subtract elapsed time every frame
                totalTime -= Time.deltaTime;

                // Divide the time by 60
                float minutes = Mathf.FloorToInt(totalTime / 60);

                // Returns the remainder
                float seconds = Mathf.FloorToInt(totalTime % 60);

                // Set the text string
                timerText.text = $"{minutes} : {seconds}";
            }
            else
            {
                GameManager.Instance.openScorePanel?.Invoke();
                totalTime = 0;
            }
        }
        
    }
}

