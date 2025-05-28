using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject Button;
    [SerializeField] Animator animator;
    [SerializeField] Animator clickAnimator;
    public GameObject Explosion;
    [SerializeField] AudioSource audioSource;


    private void Start()
    {
        animator.enabled = true;
        Explosion.SetActive(false);
    }
    public void PlayAnimation()
    {
        Debug.Log("playing animation???");
        if(Button != null)
        {
            if(animator != null )
            {
                Debug.Log("Playing Animaiton");
                animator.Play("ButtomDownNew",0);
            }
            else
            {
                Debug.Log("animator null");
            }
        }
        else
        {
            Debug.Log("button null");
        }
    }

    public void WaitBeforeChanging()
    {
        clickAnimator.SetTrigger("Click");
        PlayAnimation();
        Invoke("SceneChange", 2);
        Invoke("explode", 1.8f);
    }
    void SceneChange()
    {
        Debug.Log("Scene Change");
        SceneManager.LoadScene(1);
    }

    void explode()
    {
        audioSource.Play();
        Explosion.SetActive(true);
    }
}
