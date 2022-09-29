using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputSystem : MonoBehaviour
{
    #region -Variables-
    [Header("GameObject")]
    [SerializeField] private CharacterController controller;

    [Header("InputSystem")]
    private Controls controls;

    [Header("Movement")]
    [SerializeField] private float speed;
    Vector3 moveDir;
    Vector2 direction;
    //public float speedAnim = 0f;
    [Header("FollowPath")]
    [SerializeField] private Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector3 objectPosition;
    [SerializeField] private float speedModifier = .1f;
    private float normalHit;
    private bool canCheckNormal;
    private Vector2 lastDir;

    [Header("Rotation")]
    [SerializeField] [Range(0, 1f)] private float turnSmoothTime = .1f;
    private bool canRotate = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 3f, highJumpForce = 1f;
    private float gravity = 3f;
    public float vSpeed = 0f; // current vertical velocity
    [SerializeField]
    private int howManyJump = 2;
    private int jumpCounter = 0;
    [Header("Collision")]
    private bool isHittedEnemy;
    [SerializeField]
    private float enemyPushForce = .3f;
    #endregion

    private void Awake()
    {
        routeToGo = 2;
        //il player comincia a muoversi dal secondo Control Point
        tParam = 0f;

        controls = new Controls();
        controls.Gameplay.Enable();
        controls.Gameplay.Jump.performed += Jump;
        controls.Gameplay.HighJump.performed += HighJump;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //context.performed è quando premiamo il tasto
        if (context.performed && jumpCounter < howManyJump)
        {
            vSpeed = jumpForce;
            jumpCounter++;
        }
    }

    public void HighJump(InputAction.CallbackContext context)
    {
        //context.performed è quando premiamo il tasto
        if (context.performed && jumpCounter < howManyJump)
        {
            vSpeed = jumpForce + highJumpForce;
            jumpCounter++;
        }
    }

    private void Update()
    {
        direction = new Vector2(controls.Gameplay.Move.ReadValue<Vector2>().x, transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector3 p0 = routes[routeToGo].GetChild(0).position;
        Vector3 p1 = routes[routeToGo].GetChild(1).position;
        Vector3 p2 = routes[routeToGo].GetChild(2).position;
        Vector3 p3 = routes[routeToGo].GetChild(3).position;

        #region -SetAnimation-
        
        #endregion

        if (direction.magnitude > .15f)
        {
            #region -Rotation-
            //Atan2 ci d? l'angolazione in radianti dall'asse x
            //prende l'angolazione del nostro movimento e la somma a 180
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 180;
            #endregion

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0f, 0f, direction.magnitude);

            //tParam sarebbe la posizione nella route che va da 0 a 1 (0 è l'inizio e 1 la fine)
            if (tParam <= 1 && tParam >= 0)
            {
                if ((controller.collisionFlags & CollisionFlags.Sides) == 0)
                {
                    //non stai urtando
                    //anche se andiamo avanti quando stiamo sotto si modifica perché moveDir.x cambia sempre
                    tParam += moveDir.x * speedModifier;

                    lastDir = moveDir;

                    canCheckNormal = true;

                    if (!isHittedEnemy)
                    {
                        if (!canRotate)
                        {
                            canRotate = true;
                        }
                    }
                }
                else
                {
                    //Sta urtando
                    if (Mathf.Sign(normalHit) < 0f)
                    {
                        if (isHittedEnemy)
                        {
                            if (lastDir.magnitude > .15f)
                            {
                                tParam += -lastDir.x * enemyPushForce;
                            }
                            else
                            {
                                tParam += (-moveDir.x - lastDir.x) * enemyPushForce;
                            }
                            TParamLoop();
                        }
                        else if(lastDir.x != moveDir.x)
                        {
                            canRotate = false;
                            tParam += -lastDir.x * speedModifier;
                        }
                    }
                }

                objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 *
                    Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) *
                    Mathf.Pow(tParam, 2) * p2 +
                    Mathf.Pow(tParam, 3) * p3;
            }
            else
            {
                TParamLoop();
            }
        }

        if (vSpeed > -5)
        {
            if (!controller.isGrounded)
            {
                vSpeed -= gravity * Time.deltaTime;
            }
        }

        MoveToPoint(objectPosition, vSpeed);
    }

    public void MoveToPoint(Vector3 targetPosition, float vSpeed)
    {

        Vector3 movDiff = targetPosition - transform.position;
        movDiff.y = vSpeed;

        Vector3 movRot = movDiff;

        movRot.y = 0;

        if (canRotate)
        {
            transform.rotation = Quaternion.LookRotation(movRot);
        }
        
        controller.Move(movDiff * speed * Time.deltaTime);
    }

    private void TParamLoop()
    {
        //se supera la fine di quella determinata route in cui ci troviamo
        if (tParam > 1)
        {
            tParam = 0f;

            routeToGo += 1;

            if (routeToGo > routes.Length - 1)
            {
                //vediamo che fare quando arriva alla fine
                Debug.Log("Sei alla fine della route");
            }
        }

        //se torna indietro la route si ricollega alla route precedente
        else if (tParam < 0)
        {
            tParam = 1f;

            routeToGo -= 1;

            if (routeToGo > routes.Length - routes.Length)
            {
                //vediamo che fare quando arriva all'inizio
                Debug.Log("Sei all'inizio della route");
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((controller.collisionFlags & CollisionFlags.Sides) != 0 && canCheckNormal)
        {
            //normalHit = hit.normal.x + hit.normal.z;
            normalHit = Vector3.Dot(transform.forward, hit.normal);
            if (hit.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                isHittedEnemy = true;
                StartCoroutine(CanRotate());
            }
            canCheckNormal = false;
            Debug.Log("forward " + transform.forward
                + "normal " + hit.normal + "normal hit" + normalHit);
        }

        if (controller.isGrounded)
        {
            jumpCounter = 0;
        }
    }

    IEnumerator CanRotate()
    {
        canRotate = false;
        yield return new WaitForSeconds(.3f);
        isHittedEnemy = false;
        canRotate = true;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the objectPosition position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(objectPosition, 1);
    }

    #region -Animation-
    /*private void Animate(string animName)
    {
        DisableOtherAnim(anim, animName);

        anim.SetBool(animName, true);
    }

    private void DisableOtherAnim(Animator anim, string animName)
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            if (parameter.name != "speed")
            {
                if (parameter.name != animName)
                {
                    anim.SetBool(parameter.name, false);
                }
            }

        }
    }*/
    #endregion
}
