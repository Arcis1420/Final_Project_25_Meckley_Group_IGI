using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemySteeringAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float chaseDistance = 10f;
    public float stopChaseDistance = 14f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // prevent tipping over

        // find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseDistance)
        {
            ChasePlayer();
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0); // stop moving but keep gravity
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Ignore vertical difference if you want flat movement:
        direction.y = 0;

        Vector3 desiredVelocity = direction * moveSpeed;
        desiredVelocity.y = rb.velocity.y; // keep gravity

        rb.velocity = desiredVelocity;

        // 🚫 Removed rotation code so enemy doesn’t turn
    }
}
