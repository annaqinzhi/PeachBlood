using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntryScene : MonoBehaviour {

    public AudioClip playSound;
    public Button play;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void onPreePlay()
    {
        SceneManager.LoadScene("MainScene");
        Destroy(PlayerSingleton.Instance);
        audioSource.PlayOneShot(playSound);
    }
}
