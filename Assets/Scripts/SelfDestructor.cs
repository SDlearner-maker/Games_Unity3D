using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    // Start is called before the first frame update

        //use this for initialisation
    void Start()
    {
        Destroy(gameObject, 5f); // todo allow customisation
        
    }

}
