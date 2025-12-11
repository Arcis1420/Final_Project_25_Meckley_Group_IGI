using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public int hitsToBreak = 3;
    public GameObject breakEffect; // optional VFX

    // called by player when they attack foliage
    public void TakeHit()
    {
        hitsToBreak--;

        if (hitsToBreak <= 0)
        {
            Break();
        }
    }

    void Break()
    {
        if (breakEffect != null)
            Instantiate(breakEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
