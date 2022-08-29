using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float phealth=100f;

    

   
 public void TakeDamage(float damage)
 {
    
    phealth-=damage;
    if(phealth<=0)
    {
        GetComponent<DeathHandler>().HandleDeath();
    }
 }
}
