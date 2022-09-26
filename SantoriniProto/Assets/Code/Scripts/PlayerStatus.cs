using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public IPowerUp ActivePowerup;
    public byte LifePoints;
    private byte AttackPoints;

    public PlayerStatus()
    {
        ActivePowerup = null;
    }
    public void TakeDamage(byte damage)
    {
        if (ActivePowerup == null)  LifePoints -= damage;
        else                        ActivePowerup.Activate();

    }
    public void DoDamage(EnemyStatus enemy)
    {
        if (ActivePowerup == null)  enemy.TakeDamage(1);
        else                        enemy.TakeDamage(ActivePowerup.Activate());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
