using UnityEngine;

public class ExplosionButton : MonoBehaviour
{
    public GameObject Explosion;

    public void Start()
    {
        Explosion.SetActive(false);
    }

    public void interact()
    {
        Explosion.SetActive(true);
    }
}
