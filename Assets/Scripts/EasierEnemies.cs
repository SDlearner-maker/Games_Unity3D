using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasierEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemyEasier;
    [SerializeField] GameObject InstanceEnemy;
    ScoreBoard scoreBoard;
    
       // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        Instantiate(InstanceEnemy, new Vector3(-63, -104, 469), Quaternion.identity);

    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (scoreBoard.ScoreReturn() >= 0 && scoreBoard.ScoreReturn() <= 30)
        {
            
            foreach (GameObject enemyEasier in enemyEasier)
            {      
                if (enemyEasier != null)
                {
                    enemyEasier.SetActive(true);
                }//activate guns for firing 
                
                //GameObject fx = Instantiate(enemyEasier, new Vector3(x, y, z), Quaternion.identity);

            }/*
            if (enemyEasier.Length == 5)
            {
                foreach (GameObject enemyEasier in enemyEasier)
                {
                    enemyEasier.SetActive(true); //activate guns for firing
                                                 //GameObject fx = Instantiate(enemyEasier, new Vector3(x, y, z), Quaternion.identity);
                }
            }
            else
            {

                GameObject fx = Instantiate(InstanceEnemy, new Vector3(x, y, z), Quaternion.identity);

            }*/

            //Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);         
        }
    }

    public int Killed(int killed) { return killed; }

}
