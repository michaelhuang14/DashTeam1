﻿
using System.Collections.Generic;
using UnityEngine;

// Responsible for spawning, keeping track of, and Destroying all enemies
public class EnemyManager : MonoBehaviour
{
    
    private GameObject SniperCatPF;
    private GameObject ShooterCatPF;
    private GameObject player;

    private List<GameObject> activeEnemies = new List<GameObject>();

    // Pass in all enemy prefabes at instantiation
    public EnemyManager(GameObject player, GameObject snipercat, GameObject shootercat)
    {
        this.player = player;
        SniperCatPF = snipercat;
        ShooterCatPF = shootercat;
    }

    public void spawnWave()
    {
        //spawning in enemies (can change spawning mechanics later)
        for (int i = 0; i < 3; i++)
        {
            GameObject tempSniperCat = Instantiate(SniperCatPF);
            tempSniperCat.GetComponent<SniperCatScript>().Player = player;
            GameObject tempShooterCat = Instantiate(ShooterCatPF);
            tempShooterCat.GetComponent<ShooterCatScript>().Player = player;
            tempSniperCat.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
            tempShooterCat.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);

            activeEnemies.Add(tempShooterCat);
            activeEnemies.Add(tempSniperCat);
        }

    }

    public void spin()
    {
        int deathcounter = 0;
        for ( int i = activeEnemies.Count -1; i >= 0; i--) 
        {
            GameObject enemy = activeEnemies[i];
            Enemy ts = null;
            switch (enemy.tag) {
                case "ShooterCat":
                    ts = enemy.GetComponent<ShooterCatScript>();
                    break;
                case "SniperCat":
                    ts = enemy.GetComponent<SniperCatScript>();
                    break;
                default:
                    Debug.Log("Unkown Enemy Type");
                    break;
            }
            
            if (ts != null && ts.isDead) {
                activeEnemies.RemoveAt(i);
                Destroy(enemy);
                deathcounter++;
            }
        }
        if (deathcounter > 1) {
            Debug.Log("C-C-C-Combo!!!");
        }
    }
}