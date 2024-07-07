using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 10;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpaawnAtRuntime");
        AddRigidbody();
    }

     void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
       

    }
    void ProcessHit()
    {
        GameObject vtx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vtx.transform.parent = parentGameObject.transform;
        hitPoints--;    
       
    }
    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vtx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vtx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    
}
