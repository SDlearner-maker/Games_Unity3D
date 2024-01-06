using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; //using the script of cross paltform in staandard assets folder

public class PlayerController : MonoBehaviour
{
    //[Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 1.68f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -0.03f;

    [Header("Control-throw based")]
    [SerializeField] float controlPitchFactor = 5f;
    [SerializeField] float controlRollFactor = -10f;
    //[SerializeField] float controlPitchFactor = -30f; //to put a cap on the pitch value in vertical direction to avoid sommersault situation

    float xThrow, yThrow; //declared here so that it could be accessed
    bool isControlEnabled = true;    
    void OnPlayerDeath() {
        isControlEnabled = false;
        //isControlEnabled = true; /****/

        //print("Controls frozen");
    }
    void Update()
    {        
        if (isControlEnabled) //when player collides with rocks, message got from CollisionHandler.cs
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();

        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition= transform.localPosition.y * positionPitchFactor;
        float pitchDuetoControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDuetoControlThrow;
        //float pitch = transform.localPosition.y * positionPitchFactor; //mutliplying displacement in y direction by the pitch factor//float pitch = 0f;
        float yaw =transform.position.x*positionYawFactor;
        float roll = xThrow * controlRollFactor;
        //float yaw = 0f;
        //float roll =0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

        //transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //float xOffset = xThrow * xSpeed * Time.deltaTime;
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        //transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

        //float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        //print(xOffsetThisFrame);
        //float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //print(horizontalThrow);
        //horizontal throw is the amount of how much we have thrown a object towards
    }
    
    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActivateGuns();
            print(guns.Length);
             
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true); //activate guns for firing
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}

/*[Tooltip("In m")] [SerializeField] float xRange = 5f;

// Start is called before the first frame update
void Start()
{

}
/*
private void OnCollisionEnter(Collision collision)
{
    print("Player collided with something");
}*/


// Update is called once per frame