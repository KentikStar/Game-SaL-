using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    int countEnemy;

    [SerializeField]
    int startCount = 5;
    
    
    void Start()
    {        
        countEnemy = transform.childCount;
        StartSpawn();
    }

    void StartSpawn(){
        for(int i = 0; i<startCount; i++){
            SpawnEnemy();
        }

        StartCoroutine(SpawnDelay());
    }

    GameObject GetFreeEnemy(){
        int rndEnemy = 0;
        Enemy enemy;
        do{
            rndEnemy = Random.Range(0,countEnemy);
            enemy = transform.GetChild(rndEnemy).GetComponent<Enemy>();
        } while(!enemy.IsFree);
        
        enemy.IsFree = false;

        return enemy.gameObject;
    }

    void SpawnEnemy(){
        GameObject enemy = GetFreeEnemy();
        enemy.SetActive(true);
    }

    IEnumerator SpawnDelay(){
        int count = countEnemy - startCount;
        for(int i = 0; i < count; i ++){
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }       
    }
}
