using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneSprawner : MonoBehaviour {

    public GameObject changeScenePrefab;
    public GameManager gameManager;

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
            yield return new WaitForSeconds(waitTime);

            getSprawnPos();
            Instantiate(changeScenePrefab, sprawnPos, gameObject.transform.rotation);
        }
    }

    void getSprawnPos()
    {
        float sprawnValueX = PlayerSingleton.Instance.transform.position.x;
        float sprawnValuey = PlayerSingleton.Instance.transform.position.y;

        sprawnPos = new Vector2(Random.Range(sprawnValueX - 8f, sprawnValueX + 8f),
                                Random.Range(sprawnValuey - 5f, sprawnValuey + 5f));
        while (sprawnPos == new Vector2(PlayerSingleton.Instance.transform.position.x,
                                        PlayerSingleton.Instance.transform.position.y))
        {
            sprawnPos = new Vector2(Random.Range(sprawnValueX - 8f, sprawnValueX + 8f),
                                    Random.Range(sprawnValuey - 5f, sprawnValuey + 5f));
        }
    }
}
