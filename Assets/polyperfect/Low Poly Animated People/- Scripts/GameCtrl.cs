using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    public GameObject[] startCanvasItems;
    public GameObject[] InGameCanvasItems;
    public GameObject[] EndCanvasItems;

    public GameObject gameCredits;
    public GameObject gameStory;
    public Text startTitle;
    public Text deathStats;

    public int waveNumber = 1; 

    private SpawnController spawnController;

    
    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
        spawnController = GetComponent<SpawnController>();
        Debug.Assert(spawnController != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        ShowStartMenu();
    }

    public void InGame()
    {
        foreach (var item in InGameCanvasItems)
        {
            item.SetActive(true);
        }
        GetComponent<SpawnController>().enabled = true;
    } 

    public void EndGame()
    {
        foreach (var item in InGameCanvasItems)
        {
            item.SetActive(false);
        }
        GetComponent<SpawnController>().enabled = false;
        Debug.Log("Ending Game");

    }

    public void ShowStartMenu()
    {
        foreach (var item in startCanvasItems)
        {
            item.SetActive(true);
        }
    }

    public void HideStartMenu()
    {
        foreach (var item in startCanvasItems)
        {
            item.SetActive(false);
        }

        if (deathStats.enabled)
        {
            deathStats.enabled = false;
        }
    }

    public void showInGameHUD()
    {
        foreach (var item in InGameCanvasItems)
        {
            item.SetActive(true);
        }
    }

    public void HideInGameHUD()
    {
        foreach (var item in InGameCanvasItems)
        {
            item.SetActive(false);
        }
    }

    public void ShowEndMenu()
    {
        startTitle.text = "Game Over";
        deathStats.text = "Number of Waves Survived: " + spawnController.waveNumber + "Enemies Killed: " + spawnController.totalKilledEnemies;
        deathStats.enabled = true;
        ShowStartMenu();
    }

    public void ExitGame()
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }

    public void ShowCredits()
    {
        gameCredits.SetActive(true);
    }

    public void HideCredits()
    {
        gameCredits.SetActive(false);
    }

    public void ShowStory()
    {
        gameStory.SetActive(true);
    }

    public void HideStory()
    {
        gameStory.SetActive(false);
    }
}
