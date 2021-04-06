using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject Player;

    public GameObject SniperCatPF;
    public GameObject ShooterCatPF;

    void Start()
    {
        //spawning in enemies (can change spawning mechanics later)
        for (int i = 0; i < 3; i++)
        {
            GameObject tempSniperCat = Instantiate(SniperCatPF);
            tempSniperCat.GetComponent<SniperCatScript>().Player = Player;
            GameObject tempShooterCat = Instantiate(ShooterCatPF);
            tempShooterCat.GetComponent<ShooterCatScript>().Player = Player;
            tempSniperCat.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
            tempShooterCat.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
        }
    }

    void Update()
    {
        
    }
}
