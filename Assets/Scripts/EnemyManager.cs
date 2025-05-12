using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>(); //this is creating a list 

    public void AddEnemy(Enemy enemy) //these are functions that we can call to add or remove "enemy" from the list 
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }
}
