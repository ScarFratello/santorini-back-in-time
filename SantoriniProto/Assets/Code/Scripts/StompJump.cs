using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompJump : MonoBehaviour
{
    [SerializeField] private MovementInputSystem mis;
    [SerializeField]
    private LayerMask enemyMask;
    [SerializeField]
    private float stompJumpForce = 1.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, .3f, enemyMask))
        {
            mis.vSpeed = stompJumpForce;
        }
    }
}
