using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public GameObject PickUpText;
    PickUp pickUpObject;

    void Update()
    {
        // Draw the ray in the Scene view for debugging
        Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange, Color.green);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                Debug.Log($"[E Pressed] Raycast hit: {hitInfo.collider.gameObject.name} at {hitInfo.point}, distance: {hitInfo.distance:F2}");
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
            else
            {
                Debug.Log("[E Pressed] Raycast did not hit anything.");
            }
        }

        Ray r2 = new Ray(InteractorSource.position, InteractorSource.forward);
        RaycastHit hitInfo2;

        if (Physics.Raycast(r2, out hitInfo2, InteractRange))
        {
            Debug.Log($"[Looking] Raycast hit: {hitInfo2.collider.gameObject.name} at {hitInfo2.point}, distance: {hitInfo2.distance:F2}");
            if (hitInfo2.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (hitInfo2.collider.CompareTag("Key"))
                {
                    PickUpText.SetActive(true);
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
            Debug.Log("[Looking] Raycast did not hit anything.");
            PickUpText.SetActive(false);
        }
    }


}
