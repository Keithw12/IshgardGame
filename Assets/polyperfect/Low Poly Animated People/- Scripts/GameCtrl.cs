using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public GameObject[] startCanvasItems;
    public GameObject[] InGameCanvasItems;
    public GameObject[] EndCanvasItems;

    public GameObject gameCredits;
    public GameObject gameStory;

    public int waveNumber = 1; 

    
    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
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
        foreach (var item in EndCanvasItems)
        {
            item.SetActive(true);
        }
    }

    public void HideEndMenu()
    {
        foreach (var item in EndCanvasItems)
        {
            item.SetActive(false);
        }
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
