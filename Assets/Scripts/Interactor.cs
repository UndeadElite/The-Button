using UnityEngine;
using TMPro;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public GameObject PickUpText;
    public TextMeshProUGUI PickUpTextUI;

    void Update()
    {
        Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange, Color.green);

        // Handle E key for interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                // Check if looking at SmallBaby and holding the rattle
                SmallBaby baby = hitInfo.collider.GetComponent<SmallBaby>();
                if (baby != null && PickUp.playerIsHolding && PickUp.CurrentHeld != null && PickUp.CurrentHeld.CompareTag("Rattle"))
                {
                    baby.OnRattleGiven();
                    PickUp.CurrentHeld.GiveToSmallBaby();
                    
                    return;
                 
                }

                // Default interactable logic
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }

        // Handle UI prompt for what the player is looking at
        Ray r2 = new Ray(InteractorSource.position, InteractorSource.forward);
        RaycastHit hitInfo2;

        if (Physics.Raycast(r2, out hitInfo2, InteractRange))
        {
            // Check if looking at SmallBaby and holding the rattle
            SmallBaby baby = hitInfo2.collider.GetComponent<SmallBaby>();
            if (baby != null && PickUp.playerIsHolding && PickUp.CurrentHeld != null && PickUp.CurrentHeld.CompareTag("Rattle"))
            {
                PickUpText.SetActive(true);
                PickUpTextUI.text = "Press E to give the rattle to the baby!";
            }
            else if (hitInfo2.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (hitInfo2.collider.CompareTag("Key"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to pick up the key!";
                }
                else if (hitInfo2.collider.CompareTag("Rattle"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to pick up the rattle!";
                }
                else if (hitInfo2.collider.CompareTag("Hammer"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to pick up the hammer!";
                }
                else if (hitInfo2.collider.CompareTag("Buttom"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to press the Buttom!";
                }
                else
                {
                    PickUpText.SetActive(false);
                }
            }
            else
            {
                PickUpText.SetActive(false);
            }
        }
        else
        {
            PickUpText.SetActive(false);
        }

        // Handle Q key for dropping held item
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (PickUp.playerIsHolding && PickUp.CurrentHeld != null)
            {
                PickUp.CurrentHeld.Drop();
            }
        }
        if (PickUp.playerIsHolding && PickUp.CurrentHeld != null)
        {
            PickUpText.SetActive(true);
            PickUpTextUI.text = "Press Q to drop!";
        }
    }
}