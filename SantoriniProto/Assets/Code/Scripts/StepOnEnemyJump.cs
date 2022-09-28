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
        Vector3 down = transform.TransformDirection(Vector3.down);
<<<<<<< Updated upstream


=======
        RaycastHit enemyHit;
        EnemyStatus enemyStatus;
>>>>>>> Stashed changes
        if (Physics.Raycast(transform.position, down, out enemyHit, .3f, enemyMask))
        {
            mis.vSpeed = stepOnJumpForce;
            enemyStatus = enemyHit.collider.gameObject.GetComponent<EnemyStatus>();
            if (enemyStatus.IsStompable)    player.DoDamage(enemyStatus);
            else                            enemyStatus.DoDamage(player);
        }
    }
}
