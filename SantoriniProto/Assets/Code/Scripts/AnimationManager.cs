using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MovementInputSystem mis;
    private bool isGrounded;


    public void UpdateIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
        animator.SetBool("isGrounded", isGrounded);
        if (animator.GetBool("isFalling") == true && isGrounded) animator.SetTrigger("isLanding");
    }
    public void UpdateSpeed(float speed) 
    {
        animator.SetFloat("speed", speed);
    }
    public void UpdateIsFalling()
    {
        if (mis.vSpeed < 0 && !isGrounded) animator.SetBool("isFalling", true);
        else animator.SetBool("isFalling", false);
    }
    public void UpdateIsKicking() 
    {
        animator.SetTrigger("isKicking");
    }
    public void UpdateIsPunching()
    {
        animator.SetTrigger("isPunching");
    }
    public void UpdateIsJumping()
    {
        animator.SetTrigger("isJumping");
    }
    public void UpdateIsDoubleJumping()
    {
        animator.SetTrigger("isDoubleJumping");
    }
    public static IEnumerator PlayerHitAnimationCoroutine(PlayerStatus player) // invulnerabilità dopo essere stato colpito
    {
        player.isHit = true;
        yield return player.StartCoroutine(HitAnimationCoroutine(player.gameObject));
        player.isHit = false;
    }
    public static IEnumerator HitAnimationCoroutine(GameObject entity)
    {
        Debug.Log("Start red on " + entity.name);
        Renderer meshRenderer = entity.GetComponentInChildren<Renderer>();
        Material entityMaterial = meshRenderer.material;
        Color originalColor = entityMaterial.color;
        float timer = 0;
        float duration = 0.5f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            entityMaterial.color = Color.Lerp(Color.red, originalColor, timer / duration);
            meshRenderer.material = entityMaterial;

            yield return null;
        }
        entityMaterial.color = originalColor;
    }

    public static IEnumerator DestroyCoroutine(GameObject entity)
    {
        Destroy(entity.GetComponent<CharacterController>());
        while (entity.transform.localScale.x > 0)
        {
            entity.transform.localScale -= 5f * Time.deltaTime * Vector3.one;
            yield return null;
        }
        Destroy(entity);
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
