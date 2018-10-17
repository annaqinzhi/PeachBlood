using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneSprawner : MonoBehaviour {

    public GameObject changeScenePrefab;
    public GameManager gameManager;
    public GameObject player;

    Vector2 sprawnPos;
    float waitTime = 10f;


    void Start()
    {
        StartCoroutine(createSprawner());
    }


    IEnumerator createSprawner()
    {
        while (!gameManager.gameOver)
        {
            float sprawnValueX = player.gameObject.transform.position.x;
            float sprawnValuey = player.gameObject.transform.position.y;

            yield return new WaitForSeconds(waitTime);
            sprawnPos = new Vector2(Random.Range(sprawnValueX - 8f, sprawnValueX + 8f), Random.Range(sprawnValuey - 5f, sprawnValuey + 5f));
            Instantiate(changeScenePrefab, sprawnPos, gameObject.transform.rotation);
        }
    }
}
