using UnityEngine;

public class MainDoor : MonoBehaviour
{
    [Header("Animators")]
    public Animator plank1Animator;
    public Animator plank2Animator;
    public Animator doorAnimator;  

    [Header("Keys")]
    public bool babykey = false;
    public bool doneKey = false;

    private bool plank1Removed = false;
    private bool plank2Removed = false;
    private bool doorOpened = false;


    public int PlanksRemoved
    {
        get
        {
            int count = 0;
            if (plank1Removed) count++;
            if (plank2Removed) count++;
            return count;
        }
    }
    public void OpenDoorWithHammer()
    {
        if (!doorOpened && plank1Removed && plank2Removed)
        {
            doorAnimator.SetTrigger("DoorOpen1");
            doorOpened = true;
            Debug.Log("Door opened with hammer!");
        }
    }




    void Update()
    {
       
        if (babykey && !plank1Removed)
        {
            plank1Animator.SetTrigger("PlankRemove");
            plank1Removed = true;
        }


        if (doneKey && !plank2Removed)
        {
            plank2Animator.SetTrigger("RemovePlank2");
            plank2Removed = true;
        }
    }
}
