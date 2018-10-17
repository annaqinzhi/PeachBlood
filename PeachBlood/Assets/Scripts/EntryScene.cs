using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntryScene : MonoBehaviour {

    //public Canvas startCanvas;
    public Button play;
   
    public void onPreePlay()
    {
        SceneManager.LoadScene("MainScene");
    }
}
