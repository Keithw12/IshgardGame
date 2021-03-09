using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public GameObject[] startCanvasItems;
    public GameObject[] InGameCanvasItems;
    public GameObject[] EndCanvasItems;

    public GameObject gameCredits;
    
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
}
