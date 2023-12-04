using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] Enemies;
    public int EnemiesCount = 0, EnemiesDead = 3;

    void Start()
    {
        GetRandom();
    }

    public void GetRandom()
    {
        if (EnemiesCount <= 1 && EnemiesDead >= 2)
        {
            EnemiesCount += 1;
            int RandomCatch = Random.Range(0, Enemies.Length - 1);
            Instantiate(Enemies[RandomCatch]);
            StartCoroutine(Delay());
        }else if(EnemiesCount >= 1 && EnemiesDead >= 2)
        {
            EnemiesCount = 0;
            EnemiesDead = 0;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        GetRandom();
    }
}
