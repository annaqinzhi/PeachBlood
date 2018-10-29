using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameManager gameManager;
    public float waitTime = 3f;

    Vector2 sprawnPos;



    void Start () {

        StartCoroutine(createSprawner());
	}


    IEnumerator createSprawner()
    {

        while (!gameManager.gameOver)
        {
            yield return new WaitForSeconds(waitTime);

            getSprawnPos();

            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject();

            if(enemy!=null)
            {
                enemy.transform.position = sprawnPos;
                enemy.transform.rotation = gameObject.transform.rotation;
                enemy.SetActive(true);
            }
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
