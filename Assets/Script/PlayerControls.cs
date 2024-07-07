using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Setting")]
    [Tooltip("How fast ship move up anh down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("How far player moves horizontally")][SerializeField] float xRange = 10f;
    [Tooltip("How far player moves vertically")] [SerializeField] float yRange = 7f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;


    float yThrow, xThrow;
    private void FixedUpdate()
    {
        ProcessTranslation();
        processRotation();
        processFiring();
    }
    void processRotation()
    {
        float PitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float PitchDueToControlThrow = yThrow * controlPitchFactor;         

        float pitch = PitchDueToPosition + PitchDueToControlThrow ;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation =  Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * controlSpeed;
        float RanXPos = transform.localPosition.x + xoffset;
        float clampedXPos = Mathf.Clamp(RanXPos, -xRange, xRange);

        float yoffset = yThrow * Time.deltaTime * controlSpeed;
        float RanYPos = transform.localPosition.y + yoffset;
        float clampedYPos = Mathf.Clamp(RanYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos,clampedYPos, transform.localPosition.z);
        
    }
    void processFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ActiveLasers(true);
        }
        else
        {
            ActiveLasers(false);
        }
    }
    
    void ActiveLasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    
}
