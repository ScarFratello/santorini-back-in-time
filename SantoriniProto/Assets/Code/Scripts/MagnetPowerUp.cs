using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class MagnetPowerUp : PowerUp
{
    public float MagnetForce;
    public float MagnetRadius;
    public LayerMask ItemsLayerMask;
    private Collider[] ToAttract;


    public MagnetPowerUp()
    {
        LifeTime = 10f;
    }
    override public byte Attack(EnemyStatus enemy)
    {
        throw new NotSupportedException("This powerup has no defensive effect");
    }

    override public byte Defend()
    {
        throw new NotSupportedException("This powerup has no defensive effect");
    }
    private void Awake()
    {
        LifeTime = 10f;
        MagnetForce = 2f;
        MagnetRadius = 3f;
        ItemsLayerMask = (1 << LayerMask.NameToLayer("Coins")) | (1 << LayerMask.NameToLayer("Collectables"));
        PowerupObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        PowerupObject.tag = "MagnetPowerup";
        PowerupObject.GetComponent<SphereCollider>().isTrigger = true;
        PowerupObject.GetComponent<SphereCollider>().radius = MagnetRadius;
        PowerupObject.transform.parent = gameObject.transform;
        PowerupObject.transform.localPosition = Vector3.zero;
        PowerupObject.transform.localScale = 2f * MagnetRadius * Vector3.one;
        Destroy(PowerupObject.GetComponent<MeshRenderer>());
        enabled = true;
        Destroyer = StartCoroutine(DestroyPowerupCoroutine(LifeTime));
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // controlla gli oggetti nelle vicinanze da attrarre
        ToAttract = Physics.OverlapSphere(gameObject.transform.position, MagnetRadius, ItemsLayerMask, QueryTriggerInteraction.Collide);
        Debug.Log("Attracting " + ToAttract.Length + " items");

        if (ToAttract.Length > 0)
        {
            foreach (Collider c in ToAttract)
            {
                StartCoroutine(MagnetCoroutine(c.gameObject));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, MagnetRadius);
    }

    private IEnumerator MagnetCoroutine(GameObject item)
    {
        while (item != null)
        {
            Debug.Log(item.name);
            item.transform.position = Vector3.MoveTowards(  item.transform.position, gameObject.transform.position, 
                                                            MagnetForce * Time.deltaTime);
            yield return null;
        }
    }

}
