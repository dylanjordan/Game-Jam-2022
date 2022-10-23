using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene("LevelLoader");
    }

    public void ToTitleButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
