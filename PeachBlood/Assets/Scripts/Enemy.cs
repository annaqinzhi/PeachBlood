using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float dangerousDistance = 5f;

    GameObject player;
    private Vector2 randomDirection;
    private Vector2 moveDirection;
    private float chractorVelocity = 1.6f;
    private float directionChangeTime = 5f;
    private float moveLastTime;
    private float moveSpeed=1.3f;

    Rigidbody2D rd;
 

	void Start () {

        rd = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        getEnemySize();

        moveLastTime = 0f;
        caculatNewMoveDirection();

	}

    private void Update()
    {
        if (Time.time - moveLastTime > directionChangeTime)
        {
            moveLastTime = Time.time;
            caculatNewMoveDirection();

        }

        Vector2 newPosition = new Vector2(transform.position.x + (moveDirection.x * Time.deltaTime),
                                              transform.position.y + (moveDirection.y * Time.deltaTime));

        // transform.position = Vector3.MoveTowards(transform.position, newPosition,moveSpeed*Time.deltaTime);
        rd.MovePosition(newPosition);

        if(transform.localScale.magnitude > player.transform.localScale.magnitude)
        {
            if(Vector2.Distance(transform.position,player.transform.position) < dangerousDistance)
            {

               rd.position = 
                    Vector2.MoveTowards(transform.position, player.transform.position,  moveSpeed * Time.deltaTime);
            }
        }

    }

    void caculatNewMoveDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        moveDirection = randomDirection * chractorVelocity;
    }

    void getEnemySize()
    {
        float size = Random.Range(0.5f, 1.4f);
        transform.localScale = new Vector3(size, size, size);

        while (size.Equals(player.transform.localScale.magnitude))
        {
            size = Random.Range(0.5f, 1.4f);
            transform.localScale = new Vector3(size, size, size);
        }
    }

}
