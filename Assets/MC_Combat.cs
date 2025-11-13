using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Combat : MonoBehaviour
{

    public Animator animator;

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
        //play an attack animation

        animator.SetTrigger("Attack");

        //detect enemies in range of attack



        //damage them
    }
}
