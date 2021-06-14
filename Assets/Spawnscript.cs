using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Spawnscript : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float timerCooldown;
    public float currentTimer;
    public float spawnDist;
    GameObject[] Type001;
    GameObject[] Type002;
    GameObject[] Type003;
    public int maxEnemy1, maxEnemy2, maxEnemy3;
    GameObject player;
    public GamemanagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        CountEnemy();
 
        currentTimer += Time.deltaTime;
        if (currentTimer >= timerCooldown)
        {
            Spawn();
            currentTimer = 0;
        }
    }
    public void Spawn()
    {
        

        if(Type001.Length < maxEnemy1)
        {
            transform.position = player.transform.position;
            Vector3 spawnCircle = Random.onUnitSphere;
            spawnCircle.y = Mathf.Abs(spawnCircle.y);

            Vector3 spawnPos = transform.position + spawnCircle * spawnDist;
            Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
        }
        if (Type002.Length < maxEnemy2)
        {
            transform.position = player.transform.position;
            Vector3 spawnCircle = Random.onUnitSphere;
            spawnCircle.y = Mathf.Abs(spawnCircle.y);

            Vector3 spawnPos = transform.position + spawnCircle * spawnDist;
            Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);
        }
        if (Type003.Length < maxEnemy3)
        {
            transform.position = player.transform.position;
            Vector3 spawnCircle = Random.onUnitSphere;
            spawnCircle.y = Mathf.Abs(spawnCircle.y);

            Vector3 spawnPos = transform.position + spawnCircle * spawnDist;
            Instantiate(enemyPrefab[2], spawnPos, Quaternion.identity);
        }

    }

    public void CountEnemy()
    {
       
        Type001 = GameObject.FindGameObjectsWithTag("Type001");
        Type002 = GameObject.FindGameObjectsWithTag("Type002");
        Type003 = GameObject.FindGameObjectsWithTag("Type003");
       
    }
}
