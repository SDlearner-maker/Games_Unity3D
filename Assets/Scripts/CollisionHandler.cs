using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//to make the script look neat
//the only script which is responsible for loading scenes
public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
        print("Player triggered something");
    }
    private void ReloadScene() // string referenced
    {
        SceneManager.LoadScene(1);

    }
    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath"); //actor model of sending messages
    }
}
