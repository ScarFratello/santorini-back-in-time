using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public BoxCollider TopCollider;
    public CapsuleCollider BodyCollider;
    public LayerMask PlayerLayerMask;
    public bool IsStompable;
    public bool IsHittable;
    public byte PrimaryAttackPoints;
    public byte SecondaryAttackPoints;
    private PlayerStatus Player;
    public CharacterController EnemyController;
    [SerializeField] private byte LifePoints;

    [SerializeField] private bool IsEnemy;
    [SerializeField] private bool IsAllied;

    private void Awake()
    {
        IsEnemy = true;
        IsAllied = !IsEnemy;
        LifePoints = 2;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    public void TakeDamage(byte damage) 
    {
        LifePoints -= damage;
    }

    public void Damage(PlayerStatus player)
    {
        player.TakeDamage(PrimaryAttackPoints);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(gameObject.transform.position, Vector3.up, EnemyController.height / 2 + 0.05f, PlayerLayerMask, QueryTriggerInteraction.Ignore))
        {
            if (IsStompable)
            {
                if (TakeDamage() == 0) Destroy(gameObject);
            }
            else
            {
                Damage(PlayerCharacter.gameObject)
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
