using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnEnemyJump : MonoBehaviour
{
    [SerializeField] private MovementInputSystem mis;
    [SerializeField] private float stepOnJumpForce = 1f;
    [SerializeField]
    private LayerMask enemyMask;
    private RaycastHit enemyHit;

    private void Update()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, out enemyHit, .3f, enemyMask))
        {
            mis.vSpeed = stepOnJumpForce;
        }
    }
}
