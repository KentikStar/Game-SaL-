using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    int countEnemy;

    [SerializeField]
    int spawnCount = 5;
    
    
    void Start()
    {        
        countEnemy = transform.childCount;
        StartSpawn();
    }

    public void StartSpawn(){
        for(int i = 0; i<spawnCount; i++){
            SpawnEnemy();
        }
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

    public void Reset(){
        Enemy enemy;
        for(int i = 0; i < countEnemy; i++){
            enemy = transform.GetChild(i).GetComponent<Enemy>();
            enemy.IsFree = true;
        }
    }

    void SpawnEnemy(){
        GameObject enemy = GetFreeEnemy();
        enemy.SetActive(true);
    }

    IEnumerator SpawnDelay(){
        int count = countEnemy - spawnCount;
        for(int i = 0; i < count; i ++){
            yield return new WaitForSeconds(5f);
            SpawnEnemy();
        }       
    }
}
