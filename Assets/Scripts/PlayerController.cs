using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;
    public float up;
    public Animator animator;


    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //animator.SetFloat("Speed", Mathf.Abs(x));
        //animator.SetFloat("up", (y));




        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;


        if (x != 0 && x < 0)
        {
            sr.flipX = true;
            animator.SetFloat("Speed", Mathf.Abs(x));
        }
        else if (x != 0 && x > 0)
        {  
            sr.flipX = false;
            animator.SetFloat("Speed", Mathf.Abs(x));
        }
        else if (y != 0 && y < 0)
        {
            animator.SetFloat("down", Mathf.Abs(y));
        }
        else if (y != 0 && y > 0)
        {
            animator.SetFloat("up", (y));
        }






    }
}
