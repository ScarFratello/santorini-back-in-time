using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    public float LifeTime;
    public Coroutine Destroyer;
    public GameObject PowerupObject;

    public abstract sbyte Attack(EntityStatus enemy);

    public abstract sbyte Defend();

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
