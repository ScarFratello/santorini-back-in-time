using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class PowerUp : MonoBehaviour
{
    public int LifeTime;

    public PowerUp(int lifeTime)
    {
        LifeTime = lifeTime;
    }

    public abstract void Activate();
}
