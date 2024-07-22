using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void OpenPauseScreen()
    {
        GameManager.Instance.OpenPauseScreen();
    }
}
