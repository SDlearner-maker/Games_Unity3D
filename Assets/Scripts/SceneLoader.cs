using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadFirstScene", 2f); //load scene after 2 seconds
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
