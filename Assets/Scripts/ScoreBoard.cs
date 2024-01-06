using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int score;

    ////int score;
    
    Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score = "+ score.ToString();
    }
    void Update()
    {
        //print(score);

    }
    public void ScoreHit(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = "Score = " + score.ToString();
        ScoreReturn();
    }

    public int ScoreReturn() { return score; }
}