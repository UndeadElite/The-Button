using UnityEngine;

public class BrokenButton : MonoBehaviour
{
    [SerializeField] Rigidbody childRb;
    public void Start()
    {

        if (childRb != null)
        {
            childRb.isKinematic = true; // Keep it off at the start
        }
    }
    public void Interact()
    {
        if(childRb != null)
        {
            childRb.isKinematic = false;

            childRb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
        }
    }
}
