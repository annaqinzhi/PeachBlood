using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetThingsSprawner : MonoBehaviour {

    public List<GameObject> meetThings;
    public GameManager gameManager;
    public GameObject player;

    Vector2 sprawnPos;
    float waitTime = 6f;


    void Start()
    {
        StartCoroutine(createSprawner());
    }


    IEnumerator createSprawner()
    {
        while (!gameManager.gameOver)
        {
            float sprawnValueX = player.transform.position.x;
            float sprawnValuey = player.transform.position.y;

            yield return new WaitForSeconds(waitTime);
            sprawnPos = new Vector2(Random.Range(sprawnValueX - 8f, sprawnValueX + 8f), 
                                    Random.Range(sprawnValuey - 5f, sprawnValuey + 5f));
            int index = Random.Range(0, 3);
            Instantiate(meetThings[index], sprawnPos, gameObject.transform.rotation);
        }
    }
}
