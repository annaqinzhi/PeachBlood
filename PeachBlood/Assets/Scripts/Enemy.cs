using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float dangerousDistance = 5f;

    [HideInInspector]
    public GameManager gameManager;

    private Vector2 randomDirection;
    private Vector2 moveDirection;
    private float chractorVelocity = 1f;
    private float directionChangeTime = 5f;
    private float moveLastTime;
    private float moveSpeed=1.3f;

    private string objTag;

    Rigidbody2D rd;
 

	void Start () {

        rd = GetComponent<Rigidbody2D>();

        getEnemySize();

        moveLastTime = 0f;
        changeMoveDirection();
  

	}

    private void Update()
    {
        if (Time.time - moveLastTime > directionChangeTime)
        {
            moveLastTime = Time.time;
            changeMoveDirection();
        }

        moveToNewPosition();

        BigEnemyFollowPlayer();

    }

    private void OnTringerEnter2D(Collider2D cl)
    {
        objTag = cl.gameObject.name;
        if(objTag=="Enemy")
        {
            changeMoveDirection();
        }
    }

    void changeMoveDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        moveDirection = randomDirection * chractorVelocity;

    }


    void moveToNewPosition()
    {
       Vector2 newPosition = new Vector2(transform.position.x + (moveDirection.x * Time.deltaTime),
                                      transform.position.y + (moveDirection.y * Time.deltaTime));
       rd.MovePosition(newPosition);
        //transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
      
    }

    void getEnemySize()
    {
        float size = Random.Range(0.5f, 1.4f);
        transform.localScale = new Vector3(size, size, size);

        while (size.Equals(PlayerSingleton.Instance.transform.localScale.magnitude))
        {
            size = Random.Range(0.5f, 1.4f);
            transform.localScale = new Vector3(size, size, size);
        }
    }

    void BigEnemyFollowPlayer()
    {
        if (transform.localScale.magnitude > PlayerSingleton.Instance.transform.transform.localScale.magnitude)
        {
            if (Vector2.Distance(transform.position, PlayerSingleton.Instance.transform.transform.position) < dangerousDistance)
            {
                rd.position =
                      Vector2.MoveTowards(transform.position, PlayerSingleton.Instance.transform.transform.position, moveSpeed * Time.deltaTime);
            }
        }
    }

}
