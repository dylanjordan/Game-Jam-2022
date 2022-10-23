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
        Debug.Log("Loading Scene");
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        //SceneManager.GetActiveScene().buildIndex + 1)
        //operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress * 100;
            Debug.Log("Progress: " + slider.value);
            
           
            yield return null;
            
        }
        
    }
}
