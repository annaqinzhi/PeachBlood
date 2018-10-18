using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameOver;
    public Canvas gameOverCanvas;
    public Canvas winnerCanvas;
    public Button Yes;
    public Button No;

    void Start () {

        gameOver = false;
        gameOverCanvas.enabled = false;
        winnerCanvas.enabled = false;
    }
	

    public void onPreeYes()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("yes button is pressed.");
    }

    public void onPressNo()
    {
        SceneManager.LoadScene("EntryScene");
        Debug.Log("no button is pressed.");
    }

}
