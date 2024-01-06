using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy has no trigger as it shouls collide with particle system
//idea-//add box collider to enemy during runtime
//3 step process for particle collision via bullet-
//1. switch off trigger 2.add enemy script and mention OnParticleCollision function 3. destroy game object enemy when colloded with particles
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    int alreadyHit = 1;
    ScoreBoard scoreBoard;
    EnemyBoard enemyBoard;
    EasierEnemies easierEnemies;
    SpawningEnemies spawningEnemies;
    [SerializeField] int hits = 3;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        enemyBoard = FindObjectOfType<EnemyBoard>();
        easierEnemies= FindObjectOfType<EasierEnemies>();
        spawningEnemies= FindObjectOfType<SpawningEnemies>();

        //gameObject.SetActive(false);
    }
    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update() 
    {
        //print("Lol my score look there: " + scoreBoard.ScoreReturn());
        /*
        if (scoreBoard.ScoreReturn() >-1 && scoreBoard.ScoreReturn() <= 50)
        {
            gameObject.SetActive(true);
            print("enabled");
        }*/
        //Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        //boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 1)
        {
            KillEnemy();
        }
        //Pop up the object named deathFX at the position just before where the enmy has died and dont rotate the object
        //scoreBoard.ScoreHit(scorePerHit);        
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits = hits - 1;
        // todo consider hit FX
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        enemyBoard.EnemyHit(alreadyHit); /**/
        print("OMG dead"); /***/
        Destroy(gameObject);
                
    }
}
