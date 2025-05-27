using UnityEngine;

public class FallButton : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void Interact()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
