using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireNumbers : MonoBehaviour
{
    //[SerializeField] int scorePerHit = 12;

    [SerializeField] int fires=0;

    Text points;

    // Use this for initialization
    void Start()
    {
        points = GetComponent<Text>();
        points.text = "Fires = " + fires.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            fires++;
            points.text = "Fires = " + fires.ToString();
        }
    }
}