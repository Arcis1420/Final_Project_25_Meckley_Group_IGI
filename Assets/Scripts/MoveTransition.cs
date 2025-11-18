using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : MonoBehaviour
{
    public Animator animator;


    void Start()
    {
        // Get the Animator component attached to this GameObject
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //play an attack animation
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        { 
            animator.SetFloat("Speed", 2);
            Debug.Log("Anim switch");
        }
        else
        {
            if (!(Input.GetAxis("Horizontal") > .005) && !(Input.GetAxis("Horizontal") < -.005))
            {
                  animator.SetFloat("Speed", 0);
            }
   
        }
            

        //detect enemies in range of attack



        //damage them
    }
}
