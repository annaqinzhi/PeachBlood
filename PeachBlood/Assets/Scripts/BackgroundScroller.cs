using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {


    public float horizontalLength=8;
    public float verticalLength=13;


    private GameObject player;
    private Vector3 startPosition;

    void Start () 
    {
        Debug.Log(horizontalLength + " " + verticalLength);
        startPosition = transform.position;
        player = GameObject.FindWithTag("Player");

       
	}

    void Update()
    {
        Debug.Log(player.transform.position.x + " " + -horizontalLength /2);
        if(player.transform.position.x < -horizontalLength/2)
        {
            Vector2 offset = new Vector2(horizontalLength, 0);
            Vector2 newPos = (Vector2)startPosition - offset;
            transform.position = newPos;

        }

    }


}
