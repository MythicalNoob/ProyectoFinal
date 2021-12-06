using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;

public class PlayerBoard : NetworkBehaviour
{
    [SerializeField] Button dice;

    public float diceNumber = 0;
    public float myNumber = 0;

    NavMeshAgent agent;
    public List<Transform> nodePoints;
    public TextMeshProUGUI diceText;

    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        dice.onClick.AddListener(RollDice);

        agent = GetComponent<NavMeshAgent>();
        

        
    }

    private void Update()
    {
        diceText.SetText($"{myNumber}");

        float distance = Vector3.Distance(transform.position, agent.destination);
        if (distance < .5f)
        {
            //agent.ResetPath();
            agent.SetDestination(transform.position);
        }
    }

    void RollDice()
    {
        myNumber = Random.Range(1, 4);
        diceNumber += myNumber;
        Debug.Log(diceNumber);
        agent.SetDestination(nodePoints[(int)diceNumber].position);
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("mini"))
        {
            ChangeScene();
        }
    }

    [Server]
    public void ChangeScene()
    {
        NetworkManager.singleton.ServerChangeScene("Ghosts");
    }
}
