using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //  if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 5f)
     //   {
            rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position) * 0.1f;
    //    }
   //     else
   //     {
    //        rb.velocity = Vector3.zero;
    //    }
    }
}
