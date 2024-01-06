using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; //generic methods
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject); //others will destroy themselves
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    
}
