using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int scene;
    public GameObject credits;

    private void Start()
    {
        credits.SetActive(false);
    }

    public void StartScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void StartCredits()
    {
        credits.SetActive(true);
    }

    public void KillGame()
    {
        Application.Quit();
    }

    public void KillCredits()
    {
        credits.SetActive(false);
    }
}
