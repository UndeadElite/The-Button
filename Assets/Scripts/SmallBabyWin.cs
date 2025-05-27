using UnityEngine;

public class SmallBabyWin : MonoBehaviour
{
    bool BabyKey = false;

    public void Interact()
    {
        Debug.Log("You done baby section!");
        BabyKey = true;
        
        // You can add more logic here as needed
    }
}