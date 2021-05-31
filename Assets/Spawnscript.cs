using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnscript : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float timerCooldown;
    public float currentTimer;
    public float spawnDist;
    GameObject[] enemyObject;
    public int maxEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountEnemy();
        print(enemyObject.Length);
        currentTimer += Time.deltaTime;
        if (currentTimer >= timerCooldown && enemyObject.Length < maxEnemy)
        {
            Spawn();
            currentTimer = 0;
        }
    }
    public void Spawn()
    {
        Vector3 spawnCircle = Random.onUnitSphere;
        spawnCircle.y = Mathf.Abs(spawnCircle.y);

        Vector3 spawnPos = transform.position + spawnCircle * spawnDist;
        Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
    }

    public int CountEnemy()
    {
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        return enemyObject.Length;
    }
}
