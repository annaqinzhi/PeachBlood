using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameManager gameManager;
    public GameObject player;
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
        float sprawnValueX = player.transform.position.x;
        float sprawnValuey = player.transform.position.y;

        sprawnPos = new Vector2(Random.Range(sprawnValueX - 8f, sprawnValueX + 8f), 
                                Random.Range(sprawnValuey - 8f, sprawnValuey + 8f));
        while (sprawnPos == new Vector2(player.transform.position.x, 
                                        player.transform.position.y))
        {
           sprawnPos = new Vector2(Random.Range(sprawnValueX - 8f, sprawnValueX + 8f), 
                                   Random.Range(sprawnValuey - 8f, sprawnValuey + 8f));
        }
    }
}
