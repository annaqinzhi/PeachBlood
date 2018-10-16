using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler SharedInstance;

    public List<GameObject> enemies;
    public GameObject enemyToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Use this for initialization
    void Start () {
        enemies = new List<GameObject>();
        for (int i = 0; i<amountToPool; i++)
        {
            GameObject enemy = (GameObject)Instantiate(enemyToPool);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }

    }
	
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }

        return null;
    }
}
