using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    GameObject[] civilians;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnLoop), 2, 2);
    }
    void SpawnEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
           if(enemies[i].activeSelf)
           {
                continue;
           }
            else
            {
                enemies[i].SetActive(true);
                enemies[i].transform.position = RandoPos();
                return;
            }
        }
    }
    void SpawnCivilian()
    {
        for (int i = 0; i < civilians.Length; i++)
        {
            if (civilians[i].activeSelf)
            {
                continue;
            }
            else
            {
                civilians[i].SetActive(true);
                civilians[i].transform.position = RandoPos();
                return;
            }
        }
    }
    void SpawnLoop()
    {
        
        int index = Random.Range(0, 10);
        if(index < 6)
            SpawnEnemy();
        else
            SpawnCivilian();
        
    }
    Vector3 RandoPos()
    {
        return new Vector3(Random.Range(-5, 5), 0, 22);
    }
}
