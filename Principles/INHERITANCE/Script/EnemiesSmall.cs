using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agil;

public class EnemiesSmall : EnemiesControler
{
    void Start()
    {
        if (child == false)
        {
            int RandomSpawn = Random.Range(0, SpawnX.Length - 1);
            transform.position = new Vector3(SpawnX[RandomSpawn],
                SpawnY, SpawnZ);

            if (transform.position.x <= -2.13f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (transform.position.x >= 2.13)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }
}
