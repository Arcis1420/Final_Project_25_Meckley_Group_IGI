using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Combat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }



    void Attack()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {


            animator.SetTrigger("Attac");
        }


        //detect enemies in range of attack

       Collider [] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);


        //damage them

        foreach (Collider enemy in hitEnemies)
        {


            Debug.Log("We hit" + enemy.name);

        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint  == null)
        {
            return; 
        }


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


