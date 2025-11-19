using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Combat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

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

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            

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


