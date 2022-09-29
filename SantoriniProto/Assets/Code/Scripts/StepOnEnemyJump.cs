using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnEnemyJump : MonoBehaviour
{
    [SerializeField] private MovementInputSystem mis;
    [SerializeField] private float stepOnJumpForce = 1f;
    [SerializeField]
    private LayerMask enemyMask;
    private PlayerStatus player;

    private void Awake()
    {
        player = gameObject.GetComponentInParent<PlayerStatus>();
    }

    private void Update()
    {
        Vector3 down = transform.TransformDirection(-transform.up);
        RaycastHit enemyHit;
        EnemyStatus enemyStatus;
        if (Physics.BoxCast(transform.position, Vector3.one* .5f, down, out enemyHit, Quaternion.identity, .2f, enemyMask))
        {
            mis.vSpeed = stepOnJumpForce;
            enemyStatus = enemyHit.collider.gameObject.GetComponent<EnemyStatus>();
            if (enemyStatus.IsStompable)    player.DoDamage(enemyStatus);
            else                            enemyStatus.DoDamage(player);
        }
    }
}
