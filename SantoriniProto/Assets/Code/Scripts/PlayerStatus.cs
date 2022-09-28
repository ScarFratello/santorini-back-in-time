using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus : MonoBehaviour
{
    public PowerUp ActivePowerup;
    public LayerMask EnemyLayerMask;
    public byte LifePoints;
    private byte AttackPoints;
    


    public PlayerStatus()
    {
        ActivePowerup = null;
    }
    public void TakeDamage(byte damage)
    {
        StartCoroutine(AnimationManager.HitAnimationCoroutine(gameObject, Vector3.up));
        if (ActivePowerup == null)
            if ((LifePoints -= damage) == 0) Destroy(gameObject);
        else                        ActivePowerup.Defend();
    }
    public void DoDamage(EnemyStatus enemy)
    {
        if (ActivePowerup == null) enemy.TakeDamage(1);
        else enemy.TakeDamage(ActivePowerup.Attack(enemy));
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
