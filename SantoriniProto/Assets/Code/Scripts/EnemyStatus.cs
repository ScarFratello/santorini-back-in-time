using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : EntityStatus
{
    public int PointsIfKilled;
    public LayerMask PlayerLayerMask;
    public bool IsStompable;
    public bool IsHittable;
    [SerializeField] private bool IsEnemy;
    [SerializeField] private bool IsAllied;

    private void Awake()
    {
        IsEnemy = true;
        IsAllied = !IsEnemy;
        LifePoints = 2;
    }

    override public void TakeDamage(sbyte damage) 
    {
        StartCoroutine(AnimationManager.HitAnimationCoroutine(gameObject));
        if ((LifePoints -= damage) <= 0)
        {
            StopAllCoroutines();
            StartCoroutine(AnimationManager.DestroyCoroutine(gameObject));
        }
            
    }

    override public void DoDamage(EntityStatus player)
    {
        player.TakeDamage(AttackPoints);

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
