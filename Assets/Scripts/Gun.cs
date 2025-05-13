using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

public AudioSource aud;
    public float range = 20f;
    public float verticalRange = 20f;
    public float width = 0.4f;
    public float fireRate = 2f;
    private float nextTimeToFire;
    public float damage = 2f;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager; //this is just setting a variable of the type "EnemyManager"

    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(width, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
        aud = GetComponent<AudioSource>();
    }

void Update()
{
    if (Input.GetMouseButtonDown(0)&& Time.time > nextTimeToFire) // "0" represents left mouse button
    {
        Fire();
        aud.Play();
    }
}

void Fire()
{
    //damage enemies
    foreach (var enemy in enemyManager.enemiesInTrigger)
    {
        enemy.TakeDamage(damage);
    }

    nextTimeToFire = Time.time + fireRate; // reset timer for gun so that fire rate is implemented
}


    private void OnTriggerEnter(Collider other)
    {
        // add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

}
