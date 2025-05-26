using UnityEngine;

public class HammerEvent : MonoBehaviour
{
    [SerializeField] GameObject hammerPrefab;
    [SerializeField] Transform spawnPoint;

    public float explosionMinForce = 5f;
    public float explosionMaxForce = 10f;
    public float explosionForceRadius = 5f;

    private GameObject spawnedHammer;
    private bool hasExploded = false;

    public void Start()
    {
        
    }
    public void Interact()
    {
        if (hasExploded) return;

        spawnedHammer = Instantiate(hammerPrefab, spawnPoint.position, spawnPoint.rotation);

        // Enable BoxCollider if it's disabled
        BoxCollider box = spawnedHammer.GetComponent<BoxCollider>();
        if (box != null)
        {
            box.enabled = true;
        }

        Rigidbody rb = spawnedHammer.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float force = Random.Range(explosionMinForce, explosionMaxForce);
            rb.isKinematic = false;
            rb.AddExplosionForce(force, spawnPoint.position, explosionForceRadius);
        }

        hasExploded = true;
    }


}
