using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    void Start()
    {
        target= FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(target == null)return;
        target.TakeDamage(damage);
        Debug.Log("KILLLLL");
    }
    // Update is called once per frame
   
}
