using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hazard : EntityStatus
{

    override public void TakeDamage(sbyte damage)
    {
        throw new NotSupportedException("This entity cannot be damaged");
    }

    override public void DoDamage(EntityStatus player)
    {
        player.TakeDamage(AttackPoints);

    }
    private void Awake()
    {
        MaxLifePoints = 1;
        AttackPoints = 2;
        LifePoints = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("Watch out!");
            hit.gameObject.GetComponent<PlayerStatus>().TakeDamage(AttackPoints);
        }
    }


}
