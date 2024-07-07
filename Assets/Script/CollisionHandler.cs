using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay = 1f;
    [SerializeField] ParticleSystem crachVFX;
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
        Debug.Log("BUM");

    }
    void StartCrashSequence()
    {
        crachVFX.Play();
        GameObject.Find("StartSparrow").SetActive(false);
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", LoadDelay);
    }

    
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    
}


