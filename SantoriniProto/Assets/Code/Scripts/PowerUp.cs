using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    public float LifeTime;
    public Coroutine Destroyer;
    public GameObject PowerupObject;

    public abstract byte Attack(EnemyStatus enemy);

    public abstract byte Defend();

    public IEnumerator DestroyPowerupCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(PowerupObject);
        Destroy(this);
    }
    void FixedUpdate()
    {
    }

}
