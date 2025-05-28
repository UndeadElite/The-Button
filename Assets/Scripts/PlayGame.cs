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
        if(Button != null)
        {
            if(animator != null )
            {
                animator.Play("ButtomDownNew",0);
            }
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
        SceneManager.LoadSceneAsync(1);
    }

    void explode()
    {
        audioSource.Play();
        Explosion.SetActive(true);
    }
}
