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

            Invoke("destroyObject", 0.5f);

            Debug.Log("Scene is changed!");
        }
    }

    void destroyObject()
    {
        particle.Stop();
        Camera.main.backgroundColor = newColor;
        Destroy(gameObject);
    }

}
