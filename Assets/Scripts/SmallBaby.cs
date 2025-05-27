using UnityEngine;

public class SmallBaby : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign your button prefab in the Inspector
    public Transform spawnPoint;    // Optional: assign a transform for spawn location
    public GameObject raffleInHand; // Assign the raffle GameObject in the Inspector

    // Call this when the rattle is given to the baby
    public void OnRattleGiven()
    {
        if (buttonPrefab != null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.up;
            Instantiate(buttonPrefab, position, Quaternion.identity);
        }

        // Unhide the raffle in hand
        if (raffleInHand != null)
        {
            raffleInHand.SetActive(true);
        }
    }
}