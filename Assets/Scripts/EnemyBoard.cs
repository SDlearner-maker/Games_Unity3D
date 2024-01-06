using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoard : MonoBehaviour
{
    int enemiesHit;

    Text EnemiesKilled;

    // Use this for initialization
    void Start()
    {
        EnemiesKilled = GetComponent<Text>();
        EnemiesKilled.text = "Killed = " + enemiesHit.ToString();
    }

    public void EnemyHit(int hitted)
    {
        enemiesHit = enemiesHit + hitted;
        EnemiesKilled.text = "Killed = " + enemiesHit.ToString();
    }
}
