using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public GameObject scoreboard;

    // Update is called once per frame
    public void SetScene(string sceneIndex)
    {
        Debug.Log(sceneIndex);
        var scene = SceneManager.GetSceneByName(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShowScoreboard()
    {
        //scoreboard.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
