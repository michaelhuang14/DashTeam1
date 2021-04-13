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

    private EnemyManager enemyManager;
    private SoundManager soundManager;


    void Start()
    {

        soundManager = new SoundManager(gameObject);
        soundManager.startCombatLoop();
        enemyManager = new EnemyManager(Player, SniperCatPF, ShooterCatPF);
        enemyManager.spawnWave();
        StartCoroutine(manageEnemies());
    }

    void Update()
    {
        
    }

    IEnumerator manageEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            enemyManager.spin();
        }
    }

    public void dashPlanStart() {
        soundManager.slowDownCombatLoop();
        Time.timeScale = 0.4f;
    }


    public void dashPlanEnd()
    {
        soundManager.defaultCombatLoop();
        Time.timeScale = 1f;
    }
}
