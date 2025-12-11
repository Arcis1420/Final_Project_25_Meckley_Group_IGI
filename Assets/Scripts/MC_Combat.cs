using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Combat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 33;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;


            }

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
            Enemy e = enemy.GetComponentInParent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(attackDamage);
            }



            // 3. Detect foliage (NO LAYER FILTER SO ANYTHING CAN BE CHECKED)
            Collider[] hitFoliage = Physics.OverlapSphere(attackPoint.position, attackRange);

            // 4. Break foliage objects
            foreach (Collider f in hitFoliage)
            {
                BreakableObject b = f.GetComponentInParent<BreakableObject>();
                if (b != null)
                    b.TakeHit();
            }
        

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


