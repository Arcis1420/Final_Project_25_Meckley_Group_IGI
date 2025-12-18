using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakR1 : MonoBehaviour
{
    public int enemiesToKill = 5;
    private int enemiesKilled = 0;

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= enemiesToKill)
        {
            BreakWall();
        }
    }
    void BreakWall() 
    { 
        Destroy(gameObject); 
    }
    }
