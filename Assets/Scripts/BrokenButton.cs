using UnityEngine;

public class BrokenButton : MonoBehaviour
{
    [SerializeField] Rigidbody childRb;
    public GameObject Smoke;
    public void Start()
    {
        Smoke.SetActive(false);

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

            childRb.AddForce(Vector3.right * 5f, ForceMode.Impulse);
        }

        Smoke.SetActive(true);
    }
}
