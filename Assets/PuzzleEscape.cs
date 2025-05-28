using UnityEngine;

public class PuzzleEscape : MonoBehaviour
{
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
        }
    }
}
