using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed = 1f;

    GameObject player;
    private Vector2 randomDirection;
    private Vector2 moveDirection;
    private float chractorVelocity=3f;
    private float directionChangeTime = 3f;
    private float moveLastTime;
 

	void Start () {
        player = GameObject.FindWithTag("Player");
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, size);

        while (size.Equals(player.transform.localScale.magnitude))
        {
            size = Random.Range(0.5f, 1.5f);
            transform.localScale = new Vector3(size, size, size);
        }

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
        //transform.position = newPosition;
        transform.position = Vector3.MoveTowards(transform.position, newPosition,moveSpeed*Time.deltaTime);

    }

    void caculatNewMoveDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        moveDirection = randomDirection * chractorVelocity;
    }


}
