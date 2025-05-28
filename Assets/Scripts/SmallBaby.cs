using UnityEngine;
using UnityEngine.Serialization;

public class SmallBaby : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign your button prefab in the Inspector
    public Transform spawnPoint;    // Optional: assign a transform for spawn location
    public GameObject raffleInHand; // Assign the raffle GameObject in the Inspector
    public AudioSource babycryAudioSource; // Assign in Inspector or get in Awake
    public AudioSource babyhappyAudioSource;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject completeButton;
    private static readonly int BabyHappy = Animator.StringToHash("BabyHappy");

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
        animator.SetTrigger(BabyHappy);
        if (buttonPrefab != null)
        {
            completeButton.SetActive(true);
            //Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.up;
            //Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;
            //Instantiate(buttonPrefab, position, rotation);
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
