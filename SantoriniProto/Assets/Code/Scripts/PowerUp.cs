using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    public float LifeTime;

    public abstract byte Attack(EnemyStatus enemy);

    public abstract byte Defend();
    void FixedUpdate()
    {
        if (LifeTime >= 0f) LifeTime -= Time.deltaTime;
        else
        {
            gameObject.GetComponent<PlayerStatus>().ActivePowerup = null;
            Destroy(this);
        }
    }

}
