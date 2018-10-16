using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public PlayerController playerController;
    public GameObject player;

    Vector2 sprawnPos;
    float waitTime = 2f;


	void Start () {

        StartCoroutine(createSprawner());
	}


    IEnumerator createSprawner()
    {

        while (!playerController.gameOver)
        {
            float sprawnValueX = player.transform.position.x;
            float sprawnValuey = player.transform.position.y;

            yield return new WaitForSeconds(waitTime);
            sprawnPos = new Vector2(Random.Range(sprawnValueX-8f, sprawnValueX+8f), Random.Range(sprawnValuey-5f, sprawnValuey +5f));

            //Instantiate(enemyPrefab, sprawnPos, gameObject.transform.rotation);
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject();
            if(enemy!=null)
            {
                enemy.transform.position = sprawnPos;
                enemy.transform.rotation = gameObject.transform.rotation;
                enemy.SetActive(true);
            }
        }
    }
}
