using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;        // assign the CHILD animator in inspector
    public int maxHealth = 99;
    private int currentHealth;

    private Rigidbody rb;
    private EnemySteeringAI ai;
    private Collider[] colliders;

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();
        ai = GetComponent<EnemySteeringAI>();
        colliders = GetComponentsInChildren<Collider>();  // parent + children
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage: " + damage);
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Debug.Log("Health <= 0, calling Die()");
            Die();
        }
    
}

    void Die()
    {
        Debug.Log("Enemy died");

        // 1. Stop all movement
        if (ai != null) ai.enabled = false;
        if (rb != null) rb.velocity = Vector3.zero;

        // 2. Disable ALL colliders (parent + children)
        foreach (var col in colliders)
            col.enabled = false;

        // 3. Play death animation
        if (animator != null)
            animator.SetBool("IsDead", true);

        // 4. Destroy after the animation finishes
        Destroy(gameObject, 1.5f);
    }


    }



