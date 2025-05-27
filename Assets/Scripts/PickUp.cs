using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public GameObject ObjectOnPlayer;
    public static bool playerIsHolding = false;
    public static PickUp CurrentHeld = null;

    public void Interact()
    {
        if (!playerIsHolding)
        {
            // Not holding anything, pick up this item
            PickUpItem();
        }
        else if (CurrentHeld == this)
        {
            // Interacting with the held item, drop it
            Drop();
        }
        else
        {
            // Holding a different item, drop it first, then pick up this one
            if (CurrentHeld != null)
            {
                CurrentHeld.Drop();
            }
            PickUpItem();
        }
    }

 

    private void PickUpItem()
    {
        playerIsHolding = true;
        CurrentHeld = this;
        ObjectOnPlayer.SetActive(true); // Show in hand
        gameObject.SetActive(false);    // Hide in world
    }

    public void Drop()
    {
        playerIsHolding = false;
        CurrentHeld = null;
        ObjectOnPlayer.SetActive(false); // Hide in hand
        // Place item in front of player
        Transform playerTransform = Camera.main.transform; // Or use a reference to your player
        Vector3 dropPosition = playerTransform.position + playerTransform.forward * 1.5f;
        gameObject.transform.position = dropPosition;
        gameObject.SetActive(true); // Show in world
    }
}