using UnityEngine;

public class PuzzleEscape : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] GameObject winScreenCanvas;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject canvas1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winScreenCanvas.SetActive(true);
            winText.SetActive(true);
            canvas1.SetActive(false);
            audioSource.Play();
        }
    }
}
