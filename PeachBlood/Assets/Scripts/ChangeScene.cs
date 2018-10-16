using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    ParticleSystem particle;
    Color newColor = new Color32(120, 200, 187, 0);

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.name == "Player")
        {
            particle.Play();
            Camera.main.backgroundColor = newColor;
            particle.Stop();

            Invoke("destroyObject", 1f);

            Debug.Log("Scene is changed!");
        }
    }

    void destroyObject()
    {
       Destroy(gameObject);
    }

}
