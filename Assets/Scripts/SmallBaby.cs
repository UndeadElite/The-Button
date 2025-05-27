using UnityEngine;

public class SmallBaby : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign your button prefab in the Inspector
    public Transform spawnPoint;    // Optional: assign a transform for spawn location
    public GameObject raffleInHand; // Assign the raffle GameObject in the Inspector
    public AudioSource babycryAudioSource; // Assign in Inspector or get in Awake
    public AudioSource babyhappyAudioSource;
    void Start()
    {
     
        if (babycryAudioSource != null && !babycryAudioSource.isPlaying)
        {
            babycryAudioSource.loop = true;
            babycryAudioSource.Play();
        }
    }


    public void OnRattleGiven()
    {
        if (buttonPrefab != null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.up;
            Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;
            Instantiate(buttonPrefab, position, rotation);
        }

        if (raffleInHand != null)
        {
            raffleInHand.SetActive(true);
        }

        if (babycryAudioSource != null && babycryAudioSource.isPlaying)
        {
            babycryAudioSource.Stop();
        }

        if (babyhappyAudioSource != null && !babyhappyAudioSource.isPlaying)
        {
            babyhappyAudioSource.loop = true;
            babyhappyAudioSource.Play();
        }
    }

}
