using UnityEngine;

public class EnemyContactAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackCooldown = 3.5f;
    public Animator animator;

    float nextAttackTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                Attack(other.GetComponent<PlayerHealth>());
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack(PlayerHealth player)
    {
        if (animator != null)
            animator.SetTrigger("Attack");

        player.TakeDamage(damage);
    }
}
