
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    
    private GameObject SniperCatPF;
    private GameObject ShooterCatPF;
    private GameObject player;

    public EnemySpawner(GameObject player, GameObject snipercat, GameObject shootercat)
    {
        this.player = player;
        SniperCatPF = snipercat;
        ShooterCatPF = shootercat;
    }

    public void SpawnWave()
    {
        //spawning in enemies (can change spawning mechanics later
        for (int i = 0; i < 3; i++)
        {
            GameObject tempSniperCat = Instantiate(SniperCatPF);
            tempSniperCat.GetComponent<SniperCatScript>().Player = player;
            GameObject tempShooterCat = Instantiate(ShooterCatPF);
            tempShooterCat.GetComponent<ShooterCatScript>().Player = player;
            tempSniperCat.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
            tempShooterCat.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
        }

    }
}
