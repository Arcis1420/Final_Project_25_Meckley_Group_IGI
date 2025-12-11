using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHeartsUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public int maxHearts = 5;
    public int currentHearts = 5;

    List<GameObject> hearts = new List<GameObject>();

    void Start()
    {
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        // Clear existing
        foreach (var h in hearts)
            Destroy(h);

        hearts.Clear();

        // Spawn new
        for (int i = 0; i < currentHearts; i++)
        {
            GameObject h = Instantiate(heartPrefab, transform);
            hearts.Add(h);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHearts -= amount;
        if (currentHearts < 0) currentHearts = 0;

        UpdateHearts();
    }
}
