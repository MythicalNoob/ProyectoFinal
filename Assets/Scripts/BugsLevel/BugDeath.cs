using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.CompareTag("Net"))
        {
            Destroy(gameObject);
        }
    }
}
