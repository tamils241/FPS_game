using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{ 
    public float currentHealth = 100f;  // Make sure the health field is public
    public Slider health_Bar;
    public Transform cam;
    Move_Player Move_Player;
    public GameObject coinPrefab;
    public float coinSpawnHeight = 2.0f;
    public Animator ani; 
   
  

   
  void Update()
  {
    health_Bar.value = currentHealth ;
  }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("enemy health" + currentHealth);
        if (currentHealth < 0)
        { 

           currentHealth = 0;
           Debug.Log("distroy"+ gameObject.name);
           Cion_Spawn();
           Destroy(gameObject);
            //Die();
        }
    }

    /*public void Die()
    {
        // Example action: Destroy the object
           // Enemy_followe.Death_Ani();
           
            Move_Player.score_display();
          
           
          
    }*/
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
    public void Cion_Spawn()
    {
       Vector3 coinSpawnPosition = transform.position + new Vector3(0, coinSpawnHeight, 0);  
       Instantiate(coinPrefab, coinSpawnPosition, Quaternion.identity);

        // Destroy the enemy
        Destroy(gameObject);
    }
}
