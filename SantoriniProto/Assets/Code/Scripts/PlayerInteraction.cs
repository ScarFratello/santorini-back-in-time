using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public CharacterController PlayerController;
    public PlayerStatus player;
    public LayerMask EnemyLayerMask;
    public LayerMask ObstaclesLayerMask;
    public LayerMask CollectiblesLayerMask;
    private RaycastHit EntityHit;
    private GameObject EntityGameObjectHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (Physics.BoxCast(gameObject.transform.position,
                            Vector3.one * (PlayerController.radius/1.5f),
                            Vector3.down, out EntityHit, Quaternion.identity,
                            PlayerController.height/2 + 0.1f, EnemyLayerMask, QueryTriggerInteraction.Collide))
        {
            Debug.Log("Enemy hit from up!");
            EnemyStatus enemyStatus = EntityHit.collider.gameObject.GetComponent<EnemyStatus>();
            if (enemyStatus.IsStompable)
            {
                if (EntityGameObjectHit != EntityHit.collider.gameObject)
                {
                    player.DoDamage(enemyStatus);
                    StartCoroutine(HitAnimationCoroutine(enemyStatus.gameObject, Vector3.up));
                }
            }
            else
            {
                enemyStatus.DoDamage(player);
                StartCoroutine(HitAnimationCoroutine(player.gameObject, Vector3.up));
            }
            EntityGameObjectHit = EntityHit.collider.gameObject;
        }
        else EntityGameObjectHit = null;

        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out EntityHit,
            PlayerController.radius+ 0.5f, EnemyLayerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Enemy hit from side!");
            EnemyStatus enemyStatus = EntityHit.collider.gameObject.GetComponent<EnemyStatus>();
            enemyStatus.DoDamage(player);
            StartCoroutine(HitAnimationCoroutine(player.gameObject, Vector3.back));
        }
    }

    private IEnumerator HitAnimationCoroutine(GameObject entity, Vector3 knockbackDirection)
    {
        Renderer meshRenderer = entity.GetComponent<Renderer>();
        Material entityMaterial = meshRenderer.material;
        Color originalColor = entityMaterial.color;
        float timer = 0;
        float duration = 0.5f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            entityMaterial.color = Color.Lerp(Color.red, originalColor, timer/duration);
            Debug.Log(entityMaterial.color);
            meshRenderer.material = entityMaterial;
            
            yield return null;
        }
        entityMaterial.color = originalColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
