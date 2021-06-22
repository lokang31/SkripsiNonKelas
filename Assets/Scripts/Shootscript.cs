using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shootscript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera cam;
    public Text currentAmmoText;
    public float bulletSpeed;
    bool isShoot;
   float shootCooldown;
    public float cooldownTime;
    
    public int currentAmmo;
    public int maxAmmo;

    bool isReload;
    public float reloadDelay;
    float reloadCounter;
    public Slider reloadSlider;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0;
        isReload = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShoot == true )
        {
            shootCooldown -= Time.deltaTime;
           if(shootCooldown <= 0f)
            {
                Shoot();
            }
           
        }
        if(isReload == true)
        {
            reloadSlider.gameObject.SetActive(true);
            reloadSlider.value = reloadCounter / reloadDelay;
            reloadCounter += Time.deltaTime;
            if(reloadCounter >= reloadDelay)
            {
                isReload = false;
                if (currentAmmo + maxAmmo <= 30)
                {
                    //currentAmmo = 30;
                    //maxAmmo -= 30;
                    currentAmmo += maxAmmo;
                    maxAmmo = 0;
                }
                else
                {
                    int tempTotalAmmo = maxAmmo + currentAmmo;

                    currentAmmo = 30;
                    maxAmmo = tempTotalAmmo - 30;

                }
                reloadCounter = 0;
                reloadSlider.gameObject.SetActive(false);
            }
        }
        currentAmmoText.text = $"{currentAmmo} / {maxAmmo}";
    }
    public void Shoot()
    {
        if (currentAmmo > 0 && !isReload)
        {
            GameObject obj = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);

            //kasih velocity ke bullet
            obj.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

            //destroy bullet setiap n-detik
            Destroy(obj, 5f);
            shootCooldown = cooldownTime;
            currentAmmo--;
            if (currentAmmo <= 0)
            {
                Reload();
            }
        }
        
       
        
    }
    public void Reload()
    {
        isReload = true;

        
    }
    public void TurnOnShoot()
    {
        isShoot = true;
    }
    public void TurnOffShoot()
    {
        isShoot = false;
        shootCooldown = 0f;
    }
}
