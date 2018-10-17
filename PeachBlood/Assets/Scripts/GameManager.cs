using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameOver;
    public Canvas gameOverCanvas;
    public Button Yes;
    public Button No;

    void Start () {

        gameOver = false;
        gameOverCanvas.enabled = false;
    }
	

    public void onPreeYes()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onPressNo()
    {
        SceneManager.LoadScene("EntryScene");
    }

}
