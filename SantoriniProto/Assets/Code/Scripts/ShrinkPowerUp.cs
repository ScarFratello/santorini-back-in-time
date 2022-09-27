using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem.Utilities;
using System.Linq;

[Serializable]
public class ShrinkPowerUp : PowerUp
{
    private GameObject gizmoBox;
    // Start is called before the first frame update
    override public byte Attack(EnemyStatus enemy)
    {
        return enemy.LifePoints;
    }

    override public byte Defend()
    {
        throw new NotSupportedException("This powerup has no defensive effect");
    }
    private IEnumerator ShrinkingCoroutine(GameObject enemyCollider, LineRenderer magicBeam) 
    {
        while (enemyCollider.gameObject.transform.localScale.x > 0.2f)
        {
            enemyCollider.gameObject.transform.localScale -= Vector3.one * Time.deltaTime;
            magicBeam.endWidth = enemyCollider.gameObject.transform.localScale.y;
            magicBeam.SetPosition(0, gameObject.transform.position);
            magicBeam.SetPosition(1, enemyCollider.gameObject.transform.position);
            yield return null;
        }

        Destroy(magicBeam.gameObject);

    }

    private void Awake()
    {
        LifeTime = 10f;
        gizmoBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gizmoBox.transform.parent = gameObject.transform;
        gizmoBox.transform.localPosition = Vector3.zero;
        gizmoBox.transform.localScale *= 10f;
        gizmoBox.layer = LayerMask.NameToLayer("Player");
        gizmoBox.tag = "Player";
        gizmoBox.GetComponent<BoxCollider>().isTrigger = true;
        Destroy(gizmoBox.GetComponent<MeshRenderer>());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider[] nearestEnemies = Physics.OverlapBox( gizmoBox.transform.position,
                                                            gizmoBox.transform.localScale/2,
                                                            gizmoBox.transform.rotation,
                                                            gameObject.GetComponent<PlayerStatus>().EnemyLayerMask, 
                                                            QueryTriggerInteraction.Collide);
            UnityEngine.Debug.Log("Nemici trovati: " + nearestEnemies.Length);
            foreach (Collider e in nearestEnemies) UnityEngine.Debug.Log("Tipo: " + e.tag);

            if (nearestEnemies.Length > 0)
            {
                UnityEngine.Debug.Log("Nemici trovati: " + nearestEnemies.Length);
                GameObject magicBeam = new GameObject("Beam");
                magicBeam.transform.parent = gameObject.transform;
                gizmoBox.transform.localPosition = Vector3.zero;
                LineRenderer beamRenderer = magicBeam.AddComponent<LineRenderer>();

                beamRenderer.useWorldSpace = true;
                beamRenderer.positionCount = 2;
                beamRenderer.startWidth = 0.05f;
                Gradient beamColor = new();
                beamColor.mode = GradientMode.Blend;
                var gradientColorKeys = new GradientColorKey[2]
                {
                        new GradientColorKey(Color.cyan, .2f),
                        new GradientColorKey(Color.magenta, .8f)
                };

                var alphaKeys = new GradientAlphaKey[2]
                {
                        new GradientAlphaKey(1f, .2f),
                        new GradientAlphaKey(1f, .8f)
                };
                beamColor.SetKeys(gradientColorKeys, alphaKeys);
                beamRenderer.colorGradient = beamColor;
                foreach (Collider c in nearestEnemies)
                {
                    StartCoroutine(ShrinkingCoroutine(c.gameObject, beamRenderer));
                }
            }
        }
    }
}
