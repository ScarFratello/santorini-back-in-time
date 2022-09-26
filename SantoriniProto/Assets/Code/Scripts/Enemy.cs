using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BoxCollider TopCollider;
    public CapsuleCollider BodyCollider;
    public LayerMask PlayerLayerMask;
    public bool IsStompable;
    public bool IsHittable;
    private InteractionManager PlayerCharacter;
    public CharacterController EnemyController;
    [SerializeField] private byte LifePoints;
    [SerializeField] private bool IsEnemy;
    [SerializeField] private bool IsAllied;

    private void Awake()
    {
        IsEnemy = true;
        IsAllied = !IsEnemy;
        LifePoints = 2;
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            if ()
                if (--LifePoints == 0) Destroy(gameObject);
        }   
    }

    private byte TakeDamage(PowerUp power = null) 
    {
        if (power == null) --LifePoints;
        else
        {

        }
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

            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
