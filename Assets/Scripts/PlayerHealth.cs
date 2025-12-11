using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 5;
    public int currentHearts;

    public Animator animator;

    public HeartsUI heartsUI; // ? ADD THIS

    void Start()
    {
        currentHearts = maxHearts;

        if (heartsUI != null)
            heartsUI.RebuildHearts();
    }

    public void TakeDamage(int amount)
    {
        currentHearts -= amount;
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);

        if (animator != null)
            animator.SetTrigger("Hurt");

        if (heartsUI != null)
            heartsUI.UpdateHearts();

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHearts = Mathf.Clamp(currentHearts + amount, 0, maxHearts);

        if (heartsUI != null)
            heartsUI.UpdateHearts();
    }

    void Die()
    {
        Debug.Log("PLAYER DIED");
    }
}
