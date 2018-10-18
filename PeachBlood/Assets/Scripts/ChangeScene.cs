using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    public AudioClip eatenSound;

    private AudioSource audioSource;

    ParticleSystem particle;
    Color newColor = new Color32(103, 118, 115, 0);

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.name == "Player")
        {
            particle.Play();
            audioSource.PlayOneShot(eatenSound);

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
