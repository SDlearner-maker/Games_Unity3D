using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawningEnemies : MonoBehaviour

{
    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject InstanceEnemy;
    ScoreBoard scoreBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (scoreBoard.ScoreReturn() > 36)
        {
            foreach (GameObject enemy in enemy)
            {
                
                if (enemy != null) { 
                enemy.SetActive(true); //activate guns for firing
                }
            }
            /*
            if (enemy.Length == 4)
            {
                foreach (GameObject enemy in enemy)
                {
                    enemy.SetActive(true); //activate guns for firing
                }
            }
            else { 

                GameObject fx= Instantiate(InstanceEnemy, new Vector3(x, y, z), Quaternion.identity);
                
            }*/
            //Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);         
        }
        
    }
}
