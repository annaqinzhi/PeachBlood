using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour {

   

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject == PlayerSingleton.Instance.gameObject)
        {
            Destroy(gameObject);
            Debug.Log("Coint has been eaten!");

            

        }
    }
}
