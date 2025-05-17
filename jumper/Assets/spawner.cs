using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject bonusObstacle;

    public Transform spawnPoint;

    void Start()
    {
        StartCoroutine(repeater());
    }


    public void Spawn()
    {
        int randomChoice = Random.Range(0, 2);

        GameObject toSpawn;

        if (randomChoice == 0)
        {
            toSpawn = obstacle;
        }
        else
        {
            toSpawn = bonusObstacle;
        }

        Instantiate(toSpawn, spawnPoint != null ? spawnPoint.position : transform.position, Quaternion.identity);
    }

    public IEnumerator repeater()
    {
        yield return new WaitForSeconds(2);
        Spawn();
        StartCoroutine(repeater());
    }
}
