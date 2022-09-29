using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStatus : MonoBehaviour
{
    public sbyte LifePoints;
    public sbyte MaxLifePoints;
    public sbyte AttackPoints;
    public abstract void TakeDamage(sbyte damage);
    public abstract void DoDamage(EntityStatus damage);
}
