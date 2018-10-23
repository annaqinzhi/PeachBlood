using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

 
    public Vector2 touchStartPos;
    public Vector2 direction;
    public Vector2 playerStartPos;
    public Vector2 playerNewPos;
    public float moveSpeed = 2.5f;
    public bool directionChosen;
    public Text pointsText;
    public Text protectedText;
    public GameManager gameManager;
    public AudioClip eatenSound;
    public AudioClip deadSound;

    private AudioSource audioSource;
    private bool hasTreeProtected;
    private string objTag;

   

    [HideInInspector]
    public List<GameObject> trees = new List<GameObject>();


    static int point = 0;
    Vector3 maxLocalscale;
    float maxLocalscaleMagnitude;
   
    Rigidbody2D rd; 


    void Start () 
    {
        rd = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        playerStartPos = rd.position;
        pointsText.text = "0";
        protectedText.text = "0";

        maxLocalscale = new Vector3(2.0f, 2.0f, 2.0f);
        maxLocalscaleMagnitude = maxLocalscale.magnitude;
     
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

    private void OnCollisionEnter2D(Collision2D cl)
    {
        objTag = cl.gameObject.tag;

        if (objTag =="RedMushroom")
        {
            moveSpeed += 2f;
            audioSource.PlayOneShot(eatenSound);
            Debug.Log("moveSpeed added!");
            Invoke("returnToOriginalMoveSpeed", 6);
        } 

        else if (objTag == "BlueMushroom")
        {
            gameObject.transform.localScale +=new Vector3(0.8f,0.8f,0.8f) ;
            audioSource.PlayOneShot(eatenSound);
            Debug.Log("Scale added!");
            Invoke("returnToOriginalScale", 6);
        }
        else if (objTag == "Coint")
        {
            addPointsEatenCoint();
            audioSource.PlayOneShot(eatenSound);
            Debug.Log("Points added!");
        }
        else if (objTag == "Tree")
        {
            hasTreeProtected = true;
            trees.Add(cl.gameObject);
            audioSource.PlayOneShot(eatenSound);
            addProtectedCounts();
            Debug.Log("treescount is " + trees.Count);
        }
        else if (objTag == "ChangeScene")
        {
            Invoke("changeSceneBack", 5f);
        }
        else if (cl.gameObject.GetComponent<SpriteRenderer>().sprite==gameObject.GetComponent<SpriteRenderer>().sprite)
        {
            if(cl.gameObject.GetComponent<Transform>().localScale.magnitude
                                < gameObject.transform.localScale.magnitude)
            {
                cl.gameObject.SetActive(false);
                gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                addPointsEatenEnemy();
                audioSource.PlayOneShot(eatenSound);
                Debug.Log("smaller has been eaten!");

                if(gameObject.transform.localScale.magnitude > maxLocalscaleMagnitude)
                {
                    gameObject.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                    gameManager.gameOver = true;
                    gameManager.winnerCanvas.enabled = true;

                }
            }

            if (cl.gameObject.GetComponent<Transform>().localScale.magnitude
                              > gameObject.transform.localScale.magnitude)
            { if(hasTreeProtected)
                {
                    Destroy(trees[trees.Count-1]);
                    trees.Remove(trees[trees.Count-1]);
                    audioSource.PlayOneShot(eatenSound);
                    addProtectedCounts();
                    Debug.Log("One tree destroied!");

                    if(trees.Count==0)
                    {
                        hasTreeProtected = false;
                      addProtectedCounts();
                      Debug.Log("No tree protected!");
                    }
                } else 
                    {
                      gameManager.gameOver = true;
                      gameManager.gameOverCanvas.enabled = true;
                      audioSource.PlayOneShot(deadSound);
                      Debug.Log("player is dead! Game over!");
                    }
             }
        }

    }

    void returnToOriginalScale()
    {
        gameObject.transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
    }


    void returnToOriginalMoveSpeed()
    {
        moveSpeed -= 2f;
    }


    void changeSceneBack()
    {
        SceneManager.LoadScene("MainScene");
    }


    void addPointsEatenCoint()
    {
        point += 5;
        pointsText.text = point.ToString();
    }


    void addPointsEatenEnemy()
    {
        point += 1;
        pointsText.text = point.ToString();
    }


    void addProtectedCounts()
    {
        protectedText.text = trees.Count.ToString();
    }


}
