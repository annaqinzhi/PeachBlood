using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D cl)
    {
        if(cl.gameObject.name=="Player")
        {
            Destroy(gameObject);
            Debug.Log("RedMushroom has been eaten!");
        }
    }


}
