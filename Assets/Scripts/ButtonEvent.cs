using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    public bool intractable = true;
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] private float intractableAfterResetDelay = -1; // if < 0 dont reset
    [SerializeField] private float animationSpeed = 1;
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] Animator animator;
    private AudioSource audioSource;
    Vector3 originalScale;
    Vector3 growScale;
    Vector3 targetScale;
    Vector3 currentVelocity = Vector3.zero;
    float smoothTime = 0.1f;
    bool isScaling = false;

   

    bool ButtomUp = true;
    private static readonly int UpAnimator = Animator.StringToHash("ButtomUp");
    private static readonly int SpeedAnimator = Animator.StringToHash("Speed");
    private static readonly int AutoResetAnimator = Animator.StringToHash("IsAutoReset");
    private static readonly int ButtonClickedAnimator = Animator.StringToHash("ButtonClicked");

    void Awake()
    {
        // Get Animator from children if not assigned in Inspector
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        
        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    private void Start()
    {
        animator.SetFloat(SpeedAnimator,animationSpeed);
        animator.SetBool(AutoResetAnimator,intractableAfterResetDelay >= 0);

        originalScale = transform.localScale;
        growScale = originalScale * 1.2f;
        targetScale = originalScale;
    }
    
    public void Update()
    {
        if (isScaling)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref currentVelocity, smoothTime);

            // Stop when we're close enough to the target scale
            if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
            {
                transform.localScale = targetScale;
                isScaling = false;
                currentVelocity = Vector3.zero;
            }
        }
    }

    public void Interact()
    {
        if (intractable == false)
            return;

        animator.enabled = true;

        if (animator != null)
        {
            // Play the animation state directly
            animator.SetTrigger(ButtonClickedAnimator);
        }

        if (SoundEffect != null)
        {
            SoundEffect.Play();
        }

        if (ButtomUp)
        {
            ButtomUp = false;
            onInteract?.Invoke(); // Trigger event(s) assigned in inspector
            if (intractableAfterResetDelay >= 0)
                StartCoroutine(RestButtonCoroutine());
        }

        targetScale = growScale;
        isScaling = true;
        Invoke(nameof(ResetScale), 0.2f); // delay before shrinking back
    }

    IEnumerator RestButtonCoroutine()
    {
        intractable = false;
        yield return new WaitForSeconds(intractableAfterResetDelay);
        intractable = true;
        ButtomUp = true;
    }

    void ResetScale()
    {
        targetScale = originalScale;
        isScaling = true;
    }
}