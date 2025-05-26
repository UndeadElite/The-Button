using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    public bool intractable = true;
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] private float intractableAfterResetDelay = -1; // if < 0 dont reset
    [SerializeField] private float animationSpeed = 1;
    [SerializeField] Animator animator;

    bool ButtomUp = true;
    private static readonly int UpAnimator = Animator.StringToHash("ButtomUp");
    private static readonly int SpeedAnimator = Animator.StringToHash("Speed");
    private static readonly int AutoResetAnimator = Animator.StringToHash("IsAutoReset");

    void Awake()
    {
        // Get Animator from children if not assigned in Inspector
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void Start()
    {
        animator.SetFloat(SpeedAnimator,animationSpeed);
        animator.SetBool(AutoResetAnimator,intractableAfterResetDelay >= 0);
    }

    public void Interact()
    {
        if (intractable == false)
            return;
        
        if (animator != null)
        {
            // Play the animation state directly
            animator.SetBool(UpAnimator, false);
        }

        if (ButtomUp)
        {
            ButtomUp = false;
            onInteract?.Invoke(); // Trigger event(s) assigned in inspector
            if (intractableAfterResetDelay >= 0)
                StartCoroutine(RestButtonCoroutine());
        }
    }

    IEnumerator RestButtonCoroutine()
    {
        yield return null;
        animator.SetBool(UpAnimator, true);
        yield return new WaitForSeconds(intractableAfterResetDelay);
        ButtomUp = true;
    }
}