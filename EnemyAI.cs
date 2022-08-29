using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 2f;
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    // Start is called before the first frame update
    bool isProvoked=false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget<=chaseRange)
         {
            isProvoked=true;

                //navMeshAgent.SetDestination(target.position);
         }
            
    }

    public void OnDamageTaken(){
        isProvoked=true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget>=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if(distanceToTarget<= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    

    private void AttackTarget()
    {
         GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack",true);
        
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack",false);
        
    }

    private void FaceTarget()
    {
        // transform.rotatio
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x , 0 ,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,  Time.deltaTime *turnSpeed);
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
