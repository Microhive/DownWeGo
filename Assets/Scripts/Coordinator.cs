using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    public GameObject startUI;
    public GameObject player;
    public GameObject healthBarUI;
    public GameObject depthMeterUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        healthBarUI.SetActive(true);
        depthMeterUI.SetActive(true);
        player.SetActive(true);
    }

    public void ViewScore()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
