using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke(); // Trigger event(s) assigned in inspector
    }
}
