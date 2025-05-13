using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyManager enemyManagerGun; //setting up an enemy manager component within this document only

    private float enemyHealth = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            enemyManagerGun.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) //the reason "damage" is in the brackets is because we are calling the variable from 
    //the 'gun' document
    {
        enemyHealth -= damage;
    }
}
