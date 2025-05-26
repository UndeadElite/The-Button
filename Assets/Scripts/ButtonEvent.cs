using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] Animator animator;

    bool ButtomUp = true;

    public void Interact()
    {
        if (animator != null)
        {
            animator.SetTrigger("ButtonPressed");
        }

        if (ButtomUp)
        {
            ButtomUp = false;
            onInteract?.Invoke(); // Trigger event(s) assigned in inspector
        }
    }
}
