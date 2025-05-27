using Unity.VisualScripting;
using UnityEngine;

public class PlankController1 : MonoBehaviour
{
    [SerializeField] Animation plank1Animation;
    bool BabyKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BabyKey = GetComponent<SmallBabyWin>();

    }

    // Update is called once per frame
    void Update()
    {
        if(BabyKey == true)
        {
            MovePlank1();
        }
    }
    void MovePlank1()
    {
        plank1Animation.Play();
    }
}
