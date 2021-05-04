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
    public GameObject ZombieCatPF;
    public GameObject TreePF;

    private EnemyManager enemyManager;
    private SoundManager soundManager;


    void Start()
    {

        Time.timeScale = 1f;
        spawnTreeline();
	
        soundManager = new SoundManager(gameObject);
        soundManager.startCombatLoop();
        enemyManager = new EnemyManager(Player, SniperCatPF, ShooterCatPF, ZombieCatPF);
	enemyManager.spawnWave();
	//StartCoroutine(waveSpawning());
        StartCoroutine(manageEnemies());
    }
    void spawnTreeline() { //-24.5, 17.5,  -7 
        int currOrder = 1;
        float numRows = 5;
        float maxY = 17.5f;
        float minY = 5.5f;
        float maxX = -9f;
        float minX = -29.5f;
        int numCols = (int)((maxX - minX) / 5f);
        float spacing = (maxY - minY)/numRows;
        float curY = 17.5f;
	for (int i = 0; i < numRows; i++) { 
            float curX = minX;
            for (int j = 0; j < numCols; j++) {
		GameObject temp = (GameObject)Instantiate(TreePF);
		temp.transform.position = new Vector3(curX,curY,0);
                temp.GetComponent<SpriteRenderer>().sortingOrder = currOrder;
                curX += 5f;
            }
            curY -= spacing;
            currOrder++;
        } 
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

    IEnumerator waveSpawning()
    {
	int difficulty = 2;
        while (true)
        {	
	    Debug.Log("spawning wave");
            yield return new WaitForSeconds(30f);
            enemyManager.spawnWave();
	    difficulty += 2;
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
