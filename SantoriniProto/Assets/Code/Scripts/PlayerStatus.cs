using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus : EntityStatus
{
    public PowerUp ActivePowerup;
    public LayerMask EnemyLayerMask;
    public bool isHit;
    
    public PlayerStatus()
    {
        ActivePowerup = null;
    }
    override public void TakeDamage(sbyte damage)
    {
        if (isHit) return;

        StartCoroutine(AnimationManager.PlayerHitAnimationCoroutine(this));
        if (ActivePowerup == null)
        {
            if ((LifePoints -= damage) <= 0)
            {
                StopAllCoroutines();
                StartCoroutine(AnimationManager.DestroyCoroutine(gameObject));
            }
        }
        else ActivePowerup.Defend();
    }
    override public void DoDamage(EntityStatus enemy)
    {
        if (ActivePowerup == null) enemy.TakeDamage(1);
        else enemy.TakeDamage(ActivePowerup.Attack(enemy));
    }

    public void RecoverHealth()
    {
        if (LifePoints < MaxLifePoints) LifePoints++;
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
