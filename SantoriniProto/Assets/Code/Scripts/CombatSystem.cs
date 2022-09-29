using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private MovementInputSystem mis;
    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerStatus player;
    private Controls controls;
    public LayerMask EnemyLayer;
    public LayerMask ObstacleLayer;
    public UnityEvent OnKick;
    public UnityEvent OnPunch;
    
    private void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Enable();
        controls.Gameplay.Punch.performed += Punch;
        controls.Gameplay.Kick.performed += Kick;
    }

    private IEnumerator ChargeAttackCoroutine(InputAction.CallbackContext context, RaycastHit hit)
    {
        float normalHit = Vector3.Dot(transform.forward, hit.normal);
        float frames = 0f;
        if (controls.FindAction("Punch") == context.action) frames = 15f;
        else if (controls.FindAction("Kick") == context.action) frames = 35f;
        else yield return null;
        yield return new WaitForSeconds(frames / 30f);
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Debug.Log("Enemy kicked!");
            EnemyStatus enemy = hit.collider.gameObject.GetComponent<EnemyStatus>();
            player.DoDamage(enemy);
        }
        else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            player.TakeDamage(1);
        }

    }
    public void Punch(InputAction.CallbackContext context)
    {
        //context.performed è quando premiamo il tasto
        if (context.performed)
        {
            if (controls.FindAction("Punch") == context.action)
                Debug.Log(context.action);
            else Debug.Log("pippo " + controls.FindAction("Punch"));

            OnPunch.Invoke();
            if (Physics.Raycast(gameObject.transform.position + new Vector3(0,controller.height/2, 0), gameObject.transform.forward, out RaycastHit hit, controller.radius * 3, EnemyLayer))
            {
                Debug.Log("Punched something");
                StartCoroutine(ChargeAttackCoroutine(context, hit));
                //normalHit = hit.normal.x + hit.normal.z;
                //float normalHit = Vector3.Dot(transform.forward, hit.normal);

                //if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemies"))
                //{
                //    Debug.Log("Enemy punched!");
                //    EnemyStatus enemy = hit.collider.gameObject.GetComponent<EnemyStatus>();
                //    player.DoDamage(enemy);
                //}
                //else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
                //{
                //    player.TakeDamage(1);
                //}
            }
        }
    }
    public void Kick(InputAction.CallbackContext context)
    {
        //context.performed è quando premiamo il tasto
        if (context.performed)
        {
            OnKick.Invoke();
            if (Physics.Raycast(gameObject.transform.position + new Vector3(0, controller.height / 4, 0), gameObject.transform.forward, out RaycastHit hit, controller.radius * 5, EnemyLayer))
            {
                Debug.Log("Kicked something");
                StartCoroutine(ChargeAttackCoroutine(context, hit));
                //normalHit = hit.normal.x + hit.normal.z;
                //float normalHit = Vector3.Dot(transform.forward, hit.normal);

                //if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemies"))
                //{
                //    Debug.Log("Enemy kicked!");
                //    EnemyStatus enemy = hit.collider.gameObject.GetComponent<EnemyStatus>();
                //    player.DoDamage(enemy);
                //}
                //else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
                //{
                //    player.TakeDamage(1);
                //}
            }
        }
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
