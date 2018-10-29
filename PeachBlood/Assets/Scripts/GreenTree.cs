using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTree : MonoBehaviour {

     
    public float allowDistance = 1.5f;

    bool TreeProtected;
    private GameObject player;

    private void Start()
    {
        player = PlayerSingleton.Instance.gameObject;
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

    private void FixedUpdate()
    {
        if (TreeProtected)
        {
            Vector3 treeDirection = transform.position - player.transform.position;
            transform.position = player.transform.position + treeDirection.normalized * allowDistance;
        }
    }
}
