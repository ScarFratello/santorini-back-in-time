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
    public GameObject PlayerToFollow;
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
        ItemsLayerMask = (1 << LayerMask.NameToLayer("Coins")) | (1 << LayerMask.NameToLayer("Collectables"));        
    }
    void Start()
    {
        PlayerToFollow = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // controlla gli oggetti nelle vicinanze da attrarre
        ToAttract = Physics.OverlapSphere(gameObject.transform.position, MagnetRadius, ItemsLayerMask, QueryTriggerInteraction.Ignore);
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
        
    }

    private IEnumerator MagnetCoroutine(GameObject item)
    {
        while (item != null)
        {
            item.transform.position = Vector3.MoveTowards(  item.transform.position, PlayerToFollow.transform.position, 
                                                            MagnetForce * Time.deltaTime);
            yield return null;
        }
    }

}
