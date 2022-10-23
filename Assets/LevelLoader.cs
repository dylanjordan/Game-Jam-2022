using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        slider.maxValue = 100;
        StartCoroutine(SceneLoader());
    }

    IEnumerator SceneLoader()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        //SceneManager.GetActiveScene().buildIndex + 1)
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress * 100;
            if (operation.progress >= 0.95f)
            {
                operation.allowSceneActivation = true;
            }
           
            yield return null;
            
        }
    }
}
