using System;

// All enemies must implement this interface! Note that
// enemies DO NOT destroy themselves, that is the job of the EnemyManager
public interface Enemy
{
    // Enemy's status
    bool isDead { get; set; }

    // Method called upon enemy's death, i.e when player crosses them with a dash
    // Handles death animation + setting death var
    void death();

    // Attack behavior, e.g. only shoots a certain distance away from player,
    // at certain intervals, etc.
    void attack();

    // Movement behavior, e.g. runs towards the player, away from the player, etc.
    void movement();
    
}
