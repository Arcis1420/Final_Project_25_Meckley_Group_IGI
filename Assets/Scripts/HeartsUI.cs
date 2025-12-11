using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartsUI : MonoBehaviour
{
    public PlayerHealth player;          // reference to the player
    public Image heartPrefab;            // drag your HeartPrefab here
    public Transform heartsPanel;        // drag the HeartsPanel object here

    private List<Image> hearts = new List<Image>();

    void Start()
    {
        RebuildHearts();
    }

    void Update()
    {
        UpdateHearts();
    }

    public void RebuildHearts()
    {
        // clear old hearts
        foreach (Transform t in heartsPanel)
            Destroy(t.gameObject);

        hearts.Clear();

        // create new hearts
        for (int i = 0; i < player.maxHearts; i++)
        {
            Image newHeart = Instantiate(heartPrefab, heartsPanel);
            hearts.Add(newHeart);
        }
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].enabled = (i < player.currentHearts);
        }
    }
}
