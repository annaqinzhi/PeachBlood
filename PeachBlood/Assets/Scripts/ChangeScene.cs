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
        if (cl.gameObject == PlayerSingleton.Instance.gameObject)
        {
            particle.Play();
            audioSource.PlayOneShot(eatenSound);
            changeScene();
            Debug.Log("Scene is changed!");
        }
    }

    void changeScene()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            SceneManager.LoadScene("DangerScene");
        } else 
        {
            SceneManager.LoadScene("MainScene");
        }
        Destroy(gameObject);
    }

}
