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

    //g�r samma med den andra l�snignen
    // om vi inte hinner med en till l�sningewn s� har vi bara tv�

}