using UnityEngine;

public class SmallBabyWin : MonoBehaviour
{
    public Animator otherObjectAnimator;
    public MainDoor mainDoor;
    public void Interact()
    {
        Debug.Log("You done baby section!");
        
        if (mainDoor != null)
        {
            mainDoor.babykey = true; 
        }
    }

    //gör samma med den andra lösnignen
    // om vi inte hinner med en till lösningewn så har vi bara två

}