using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] Animator animator;

    bool ButtomUp = true;

    void Awake()
    {
        // Get Animator from children if not assigned in Inspector
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    public void Interact()
    {
        if (animator != null)
        {
            // Play the animation state directly
            animator.SetBool("ButtomUp", false);
        }

        if (ButtomUp)
        {
            ButtomUp = false;
            onInteract?.Invoke(); // Trigger event(s) assigned in inspector
        }
    }
}