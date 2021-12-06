using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class LanternHit : NetworkBehaviour
{
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;
    public float ghostScore = 0;

    public TextMeshProUGUI score;

    [SyncVar(hook = nameof(HandleScore))]
    string scoreText;

    public GameObject lastHit;
  

    void HandleScore(string oldValue, string newValue)
    {
        score.text = newValue;
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText = ghostScore.ToString();

        //creo un rayo que sirve para validar en el raycast si le doy a algo
        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
       //Variable obtiene info del objeto al que le pego
        RaycastHit hit;
        //regresa bool de si pego o no
        if(Physics.Raycast(ray, out hit, 5
            ))
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;

            if(lastHit.CompareTag("ghost"))
            {
                ghostScore++;
                Destroy(lastHit);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(collision, radius: 0.2f);
    }
}
