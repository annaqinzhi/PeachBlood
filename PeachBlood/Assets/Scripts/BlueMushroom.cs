using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMushroom : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("BlueMushroom has been eaten!");
        }
    }

}
