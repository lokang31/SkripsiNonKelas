using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootscript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera cam;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cek apakah ada sentuhan di layar
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
           
        }
    }
    public void Shoot()
    {
        GameObject obj = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);

        //kasih velocity ke bullet
        obj.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        //destroy bullet setiap n-detik
        Destroy(obj, 5f);
    }
}
