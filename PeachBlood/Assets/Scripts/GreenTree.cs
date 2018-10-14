using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTree : MonoBehaviour {

    public GameObject player;
    public float allowDistance = 1.5f;
    public bool TreeProtected;
   


    private void FixedUpdate() 
    {
        if (TreeProtected)
        {

            Vector3 direction = transform.position - player.transform.position;
            transform.position = player.transform.position + direction.normalized * allowDistance;
         

        }

    }


    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject == player)
        {
            TreeProtected = true; 
            Debug.Log("Tree has been eaten!");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
