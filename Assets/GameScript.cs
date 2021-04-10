using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    // This class will contain Game Management behavior, and integrate various 
    // subsystems such as enemy spawning, UI effects on gamestate, level transitions, etc.
    
    public GameObject Player;
    public GameObject SniperCatPF;
    public GameObject ShooterCatPF;

    private EnemySpawner enemySpawner;
    void Start()
    {
        enemySpawner = new EnemySpawner(Player, SniperCatPF, ShooterCatPF);
        enemySpawner.SpawnWave();
        
    }

    void Update()
    {
        
    }
}
