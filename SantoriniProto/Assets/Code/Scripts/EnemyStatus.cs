using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public byte LifePoints;
    public LayerMask PlayerLayerMask;
    public bool IsStompable;
    public bool IsHittable;
    public byte PrimaryAttackPoints;
    public byte SecondaryAttackPoints;
    private PlayerStatus Player;
    private RaycastHit Stomper;
    private RaycastHit Hitter;
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
        StartCoroutine(AnimationManager.HitAnimationCoroutine(gameObject, Vector3.up));
        if ((LifePoints -= damage) == 0)
        {
            StopAllCoroutines();
            StartCoroutine(DestroyCoroutine());
        }
            
    }

    public void DoDamage(PlayerStatus player)
    {
        player.TakeDamage(PrimaryAttackPoints);

    }

    private IEnumerator DestroyCoroutine()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        while(gameObject.transform.localScale.x > 0)
        {
            gameObject.transform.localScale -= 5f * Time.deltaTime * Vector3.one;
            yield return null;
        }
        Destroy(gameObject);
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
