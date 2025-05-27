using UnityEngine;

public class SmallBabyWin : MonoBehaviour
{
    public bool BabyKey = false;

    Animator PlankCollider;

    private void Start()
    {
        PlankCollider = GetComponent<Animator>();
    }


    public void Interact()
    {
        Debug.Log("You done baby section!");
        BabyKey = true;
        
        // You can add more logic here as needed
    }
}