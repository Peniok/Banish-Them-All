using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] SpawnPoint;
    public GameObject[] Ghosts;
    int RandomPoint, RandomEnemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects",5,5);
    }
    void SpawnObjects()
    {
        RandomPoint = Random.Range(0,SpawnPoint.Length);
        RandomEnemy = Random.Range(0, Ghosts.Length);
        Instantiate(Ghosts[RandomEnemy], SpawnPoint[RandomPoint]);
    }
}
