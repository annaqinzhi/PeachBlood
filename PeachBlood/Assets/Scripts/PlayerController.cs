﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    
    Rigidbody2D rd;

    public Vector2 touchStartPos;
    public Vector2 direction;
    public Vector2 playerStartPos;
    public Vector2 playerNewPos;
    public bool directionChosen;
    public GreenTree tree;
    public Text pointsText;


    private List<GameObject> trees = new List<GameObject>();


    int point = 0;
    float moveSpeed=2f;


    void Start () 
    {
        rd = GetComponent<Rigidbody2D>();
        playerStartPos = rd.position;
        pointsText.text = "0";
     
	}
	
	
	void Update () 
    {
     
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position-touchStartPos;
                    directionChosen = true;
                    break;

                case TouchPhase.Ended:
                    directionChosen = false;
                    break;
            }
        }


	}

    private void FixedUpdate()
    {
        if (directionChosen)
        {
            playerNewPos = playerStartPos + direction.normalized * moveSpeed * Time.fixedDeltaTime;
            rd.position = playerNewPos;
            playerStartPos = rd.position;


        } 

    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.tag =="RedMushroom")
        {
            moveSpeed += 2f;
            Debug.Log("moveSpeed added!");
        } 

        else if (cl.tag =="BlueMushroom")
        {
            gameObject.transform.localScale +=new Vector3(0.8f,0.8f,0.8f) ;
            Debug.Log("Scale added!");
            Invoke("returnToOriginalScale", 6);
        }
        else if (cl.tag == "Coint")
        {
            addPoints();
            Debug.Log("Points added!");
        }
        else if (cl.tag == "Tree")
        {
            trees.Add(cl.gameObject);
            Debug.Log("treescount is " + trees.Count);
        }

        if (cl.gameObject.GetComponent<SpriteRenderer>().sprite==gameObject.GetComponent<SpriteRenderer>().sprite)
        {
            if(cl.gameObject.GetComponent<Transform>().localScale.magnitude
                                < gameObject.transform.localScale.magnitude)
            {
                Destroy(cl.gameObject);
                Debug.Log("smaller has been eaten!");
            }

            if (cl.gameObject.GetComponent<Transform>().localScale.magnitude
                              > gameObject.transform.localScale.magnitude)
            { if(tree.TreeProtected)
                {
                    Destroy(trees[trees.Count-1]);
                    trees.Remove(trees[trees.Count-1]);
                    Debug.Log("One tree destroied!");

                    if(trees.Count==0)
                    {
                      tree.TreeProtected = false;
                        Debug.Log("No tree protected!");
                    }
                } else 
                    {
                      Destroy(gameObject);
                      Debug.Log("player is dead! Game over!");
                    }
                
            }
        }

    }

    void returnToOriginalScale()
    {
        gameObject.transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
    }

    void addPoints()
    {
        point += 5;
        pointsText.text = point.ToString();

       
    }

}