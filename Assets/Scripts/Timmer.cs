using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;


public class Timmer : NetworkBehaviour
{
    public float time;
    public bool isCountdown;
    public TextMeshProUGUI text;
    public UnityAction finishCountDown;

    [SyncVar(hook = nameof(HandleText))]
    string timmerText;

    void HandleText(string oldValue, string newValue)
    {
        text.text = newValue;
    }

    // Update is called once per frame

    [Server]
    public void ChangeScene()
    {
        NetworkManager.singleton.ServerChangeScene("MainMenu");
    }

    [ServerCallback]
    void Update()
    {
        if (isCountdown && time >= 0)
        {
            time -= Time.deltaTime;

            timmerText = (($"{Mathf.Floor(time / 60):00}:{time % 60:00}"));

            if (time < 0)
            {
                timmerText = "00:00";
                ChangeScene();
            }
        }
        else
        {
            time += Time.deltaTime;
        }

        Mathf.Floor(100 / 60);

        //Debug.Log($"{Mathf.Floor(time / 60):00}:{time % 60:00}");
    }

}
