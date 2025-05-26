using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;

    bool ButtomUp = true;

    public void Interact()
    {
        if (ButtomUp)
        {
            ButtomUp = false;
            onInteract?.Invoke(); // Trigger event(s) assigned in inspector
        }
    }
}
