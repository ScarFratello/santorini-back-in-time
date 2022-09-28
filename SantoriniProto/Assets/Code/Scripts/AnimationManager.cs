using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator HitAnimationCoroutine(GameObject entity, Vector3 knockbackDirection)
    {
        Renderer meshRenderer = entity.GetComponent<Renderer>();
        Material entityMaterial = meshRenderer.material;
        Color originalColor = entityMaterial.color;
        float timer = 0;
        float duration = 0.5f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            entityMaterial.color = Color.Lerp(Color.red, originalColor, timer / duration);
            Debug.Log(entityMaterial.color);
            meshRenderer.material = entityMaterial;

            yield return null;
        }
        entityMaterial.color = originalColor;
    }
}
