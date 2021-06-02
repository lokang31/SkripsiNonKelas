using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthmanager : MonoBehaviour
{
    public Shootscript shootScript;
    public Text healthText;
 
    public int currHealth;
    public int maxHealth;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"{currHealth}";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            currHealth--;
        }
    }
}
