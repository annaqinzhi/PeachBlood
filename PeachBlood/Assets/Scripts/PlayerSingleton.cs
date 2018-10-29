using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerSingleton : MonoBehaviour {

    public Vector2 touchStartPos;
    public Vector2 direction;
    public Vector2 playerStartPos;
    public Vector2 playerNewPos;
    public float moveSpeed = 2.5f;
    public bool directionChosen;

    public AudioClip eatenSound;
    public AudioClip deadSound;

    private AudioSource audioSource;
    private bool hasTreeProtected;
    private string objTag;

    public static int point = 0;
    public static int protectedPoint = 0;



    [HideInInspector]
    public List<GameObject> trees = new List<GameObject>();

    [HideInInspector]
    public GameManager gameManager;


    Vector3 maxLocalscale;
    float maxLocalscaleMagnitude;


    Rigidbody2D rd;



    private static PlayerSingleton _instance;

    public static PlayerSingleton Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<GameObject>("Player")).GetComponent<PlayerSingleton>();
            }

            return _instance;
        }
    }

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);

        }

        else
        {
            _instance = this;
           // DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        playerStartPos = rd.position;

        maxLocalscale = new Vector3(2.0f, 2.0f, 2.0f);
        maxLocalscaleMagnitude = maxLocalscale.magnitude;

    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - touchStartPos;
                    directionChosen = true;
                    break;

                case TouchPhase.Ended:
                    directionChosen = false;
                    break;
            }
        }

        if (directionChosen)
        {
            movePlayer();

        }

    }


    public void OnTriggerEnter2D(Collider2D cl)
    {
        objTag = cl.gameObject.tag;

        if (objTag == "RedMushroom")
        {
            moveSpeed += 2f;
            audioSource.PlayOneShot(eatenSound);
            Debug.Log("moveSpeed added!");
            Invoke("returnToOriginalMoveSpeed", 6f);
        }

        else if (objTag == "BlueMushroom")
        {
            gameObject.transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
            audioSource.PlayOneShot(eatenSound);
            Debug.Log("Scale added!");
            Invoke("returnToOriginalScale", 6f);
        }
        else if (objTag == "Coint")
        {
            addPointsEatenCoint();
            audioSource.PlayOneShot(eatenSound);
            gameManager.getPoints();
            Debug.Log("Points added!");
        }
        else if (objTag == "Tree")
        {
            hasTreeProtected = true;
            trees.Add(cl.gameObject);
            audioSource.PlayOneShot(eatenSound);
            addProtectedCounts();
            gameManager.getPoints();
            Debug.Log("treescount is " + trees.Count);
        }

        else if (objTag == "Cliff")
        {
            gameManager.gameEnding();
            audioSource.PlayOneShot(deadSound);
            Destroy(gameObject);
            Debug.Log("player falling down in kaj! Game over!");
        }

        else if (cl.gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<SpriteRenderer>().sprite)
        {
            if (cl.gameObject.GetComponent<Transform>().localScale.magnitude
                                < gameObject.transform.localScale.magnitude)
            {
                cl.gameObject.SetActive(false);
                gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                addPointsEatenEnemy();
                gameManager.getPoints();
                audioSource.PlayOneShot(eatenSound);
                Debug.Log("smaller has been eaten!");

                if (gameObject.transform.localScale.magnitude > maxLocalscaleMagnitude)
                {
                    gameObject.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                    gameManager.gameEnding();


                }

            }

            if (cl.gameObject.GetComponent<Transform>().localScale.magnitude
                > gameObject.transform.localScale.magnitude)
            {
                if (hasTreeProtected)
                {
                    Destroy(trees[trees.Count - 1]);
                    trees.Remove(trees[trees.Count - 1]);
                    audioSource.PlayOneShot(eatenSound);
                    minusProtectedCounts();
                    gameManager.getPoints();
                    Debug.Log("One tree destroied!");

                    if (trees.Count == 0)
                    {
                        hasTreeProtected = false;
                        Debug.Log("No tree protected!");
                    }
                }
                else
                {
                    audioSource.PlayOneShot(deadSound);
                    if (gameManager != null)
                    {
                        gameManager.gameEnding();
                    }

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

    public void addProtectedCounts()
    {
        protectedPoint++;
    }

    public void minusProtectedCounts()
    {
        protectedPoint--;
    }


    public void addPointsEatenCoint()
    {
        point += 5;
    }


    public void addPointsEatenEnemy()
    {
        point += 1;

    }

    void movePlayer()
    { 
      playerNewPos = playerStartPos + direction.normalized * moveSpeed * Time.deltaTime;  
      rd.position = playerNewPos;
      playerStartPos = rd.position;

    }


}
