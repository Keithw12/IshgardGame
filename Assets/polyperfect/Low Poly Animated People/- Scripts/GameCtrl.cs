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
    public GameObject menuCamera;
    public GameObject playerCamera;
    public HitController hitController;
    //public PlayerController playerController;

    
    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
        spawnController = GetComponent<SpawnController>();
        Debug.Assert(spawnController != null);
        Debug.Assert(menuCamera != null);
        Debug.Assert(playerCamera != null);
        Debug.Assert(hitController != null);
    }

    public void StartGame()
    {
        ShowStartMenu();
    }

    public void InGame()
    {
        spawnController.enabled = true;
        hitController.resetHealth();
        foreach (var item in InGameCanvasItems)
        {
            item.SetActive(true);
        }
    } 

    public void EndGame()
    {
        foreach (var item in InGameCanvasItems)
        {
            item.SetActive(false);
        }
        spawnController.enabled = false;
        ShowEndMenu();
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
        Cursor.lockState = CursorLockMode.None;
        startTitle.text = "Game Over";
        deathStats.text = "Number of Waves Survived: " + spawnController.waveNumber + "Enemies Killed: " + spawnController.totalKilledEnemies;
        deathStats.enabled = true;
        menuCamera.SetActive(true);
        playerCamera.SetActive(false);
        spawnController.gameOverState = true;
        spawnController.destroyEnemies();
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
