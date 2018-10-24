using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public AudioClip eatenSound;

    private AudioSource audioSource;

    ParticleSystem particle;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.name == "Player")
        {
            particle.Play();
            audioSource.PlayOneShot(eatenSound);

            Invoke("changeScene", 0.5f);

            Debug.Log("Scene is changed!");
        }
    }

    void changeScene()
    {
        particle.Stop();
        SceneManager.LoadScene("DangerScene");
        Destroy(gameObject);
    }

}
