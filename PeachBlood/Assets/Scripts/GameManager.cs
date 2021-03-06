﻿using System.Collections;
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
    public Text pointsText;
    public Text protectedText;

 

    void Start () {

        gameOver = false;
        gameOverCanvas.enabled = false;
        winnerCanvas.enabled = false;

        PlayerSingleton.Instance.transform.position = Vector3.zero;
        PlayerSingleton.Instance.gameManager = this;

        pointsText.text = PlayerSingleton.point.ToString();
        protectedText.text = PlayerSingleton.protectedPoint.ToString();

    }



    public void onPreeYes()
    {
        PlayerSingleton.point = 0;
        PlayerSingleton.protectedPoint = 0;
        SceneManager.LoadScene("MainScene");
        Debug.Log("yes button is pressed.");

    }

    public void onPressNo()
    {
        PlayerSingleton.point = 0;
        PlayerSingleton.protectedPoint = 0;
        SceneManager.LoadScene("EntryScene");
        Debug.Log("no button is pressed.");
    }


    public void gameEnding()
    {
        gameOver = true;
        gameOverCanvas.enabled = true;

    }

    public void getPoints()
    {
        pointsText.text = PlayerSingleton.point.ToString();
        protectedText.text = PlayerSingleton.protectedPoint.ToString();
    }

    public void winnerEnding()
    {
        gameOver = true;
        winnerCanvas.enabled = true;
    }
}
