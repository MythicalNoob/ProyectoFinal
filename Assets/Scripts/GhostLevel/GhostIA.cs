using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostIA : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    private void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
    }
    private void Update()
    {
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if(transform.position.x <= -9.3 || transform.position.x >= 9 || transform.position.z <= -10 || transform.position.z >= 8)
        {
            isWalking = false;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 2);
        int rotLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 2);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotWait);
        if(rotLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}
