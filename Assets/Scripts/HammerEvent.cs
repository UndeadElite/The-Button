using UnityEngine;

public class HammerEvent : MonoBehaviour
{
    [SerializeField] GameObject hammerPrefab;
    [SerializeField] Transform spawnPoint;

    private GameObject spawnedHammer;

    public void Start()
    {
        
    }
    public void Interact()
    {

        spawnedHammer = Instantiate(hammerPrefab, spawnPoint.position, spawnPoint.rotation);

        // Enable BoxCollider if it's disabled
        BoxCollider box = spawnedHammer.GetComponent<BoxCollider>();
        if (box != null)
        {
            box.enabled = true;
        }
    }
}
