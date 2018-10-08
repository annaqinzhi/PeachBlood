using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTree : MonoBehaviour {

    public GameObject player;
    public float allowDistance = 1f;


   
    public bool isEaten;


    private void FixedUpdate()
    {
        if (isEaten)
        {
            Vector3 direction = transform.position - player.transform.position;
            transform.position = player.transform.position + direction.normalized*allowDistance;
        }

    }


    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject == player)
        {
            isEaten = true;
            Debug.Log("Tree has been eaten!");
        }
    }
}
