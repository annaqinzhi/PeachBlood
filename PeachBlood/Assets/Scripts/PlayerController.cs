using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    Rigidbody2D rd;

    public Vector2 touchStartPos;
    public Vector2 direction;
    public Vector2 playerStartPos;
    public Vector2 playerNewPos;
    public bool directionChosen;
    public Vector2 treePos;


    float moveSpeed=2f;


    void Start () 
    {
        rd = GetComponent<Rigidbody2D>();
        playerStartPos = rd.position;
     


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

    }

    void returnToOriginalScale()
    {
        gameObject.transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
    }


}
