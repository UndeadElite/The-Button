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

                if (hitInfo.collider.CompareTag("MainDoor") && PickUp.playerIsHolding && PickUp.CurrentHeld != null && PickUp.CurrentHeld.CompareTag("Hammer"))
                {
                    MainDoor mainDoor = Object.FindFirstObjectByType<MainDoor>();
                    if (mainDoor != null && mainDoor.PlanksRemoved == 2)
                    {
                        mainDoor.OpenDoorWithHammer();
                    }
                    return;
                }

                // Default interactable logic
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }

        // Track if a custom message was set
        bool customMessageSet = false;

        // Handle UI prompt for what the player is looking at
        Ray r2 = new Ray(InteractorSource.position, InteractorSource.forward);
        RaycastHit hitInfo2;

        if (Physics.Raycast(r2, out hitInfo2, InteractRange))
        {
            // Baby Dialog
            SmallBaby baby = hitInfo2.collider.GetComponent<SmallBaby>();
            if (baby != null && PickUp.playerIsHolding && PickUp.CurrentHeld != null && PickUp.CurrentHeld.CompareTag("Rattle"))
            {
                PickUpText.SetActive(true);
                PickUpTextUI.text = "Press E to give the rattle to the baby!";
                customMessageSet = true;
            }
            else if (baby != null && PickUp.playerIsHolding && PickUp.CurrentHeld != null && PickUp.CurrentHeld.CompareTag("Hammer"))
            {
                PickUpText.SetActive(true);
                PickUpTextUI.text = "No no, don't use the hammer on the baby!";
                customMessageSet = true;
            }

            //Main Door Dialog
            else if (hitInfo2.collider.CompareTag("MainDoor") && PickUp.playerIsHolding && PickUp.CurrentHeld != null && PickUp.CurrentHeld.CompareTag("Hammer"))
            {              
                MainDoor mainDoor = Object.FindFirstObjectByType<MainDoor>();
                if (mainDoor != null)
                {
                    switch (mainDoor.PlanksRemoved)
                    {
                        case 0:
                            PickUpTextUI.text = "No No, To much to handle maybe later.";
                            break;
                        case 1:
                            PickUpTextUI.text = "One plank left! Still To much!";
                            break;
                        case 2:
                            PickUpTextUI.text = "Wow Press E to Open";
                            break;
                    }
                    PickUpText.SetActive(true);
                    customMessageSet = true;
                }
            }


            else if (hitInfo2.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (hitInfo2.collider.CompareTag("Key"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to pick up the key!";
                    customMessageSet = true;
                }
                else if (hitInfo2.collider.CompareTag("Rattle"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to pick up the rattle!";
                    customMessageSet = true;
                }
                else if (hitInfo2.collider.CompareTag("Hammer"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to pick up the hammer!";
                    customMessageSet = true;
                }
                else if (hitInfo2.collider.CompareTag("Buttom"))
                {
                    PickUpText.SetActive(true);
                    PickUpTextUI.text = "Press E to press the Buttom!";
                    customMessageSet = true;
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

        // Only show drop message if no custom message is set and player is holding something
        if (!customMessageSet && PickUp.playerIsHolding && PickUp.CurrentHeld != null)
        {
            PickUpText.SetActive(true);
            PickUpTextUI.text = "Press Q to drop!";
        }
    }
}
