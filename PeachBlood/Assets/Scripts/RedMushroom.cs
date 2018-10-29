using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D cl)
    {
        if(cl.gameObject == PlayerSingleton.Instance.gameObject)
        {
            Destroy(gameObject);
            Debug.Log("RedMushroom has been eaten!");
        }
    }


}
