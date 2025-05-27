using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PuzzleMovingButtons : MonoBehaviour
{
    [System.Serializable]
    struct ButtonAndIndex
    {
        public int index;
        public MovingButton button;
    }
    [SerializeField] private ButtonAndIndex[] buttonSolutions;
    [SerializeField] private UnityEvent onSolved;
    [SerializeField] private UnityEvent onSolvedToUnsolved;
    private bool solved;

    private void Start()
    {
        foreach (var buttonSolution in buttonSolutions)
        {
            buttonSolution.button.onFinishedMoving.AddListener(CheckForSolution);
        }
    }

    public void CheckForSolution()
    {
        foreach (var buttonSolution in buttonSolutions)
        {
            if (buttonSolution.button.index != buttonSolution.index)
            {
                if (solved)
                {
                    solved = false;
                    onSolvedToUnsolved.Invoke();
                }
                return;
            }
        }
        
        if (solved)
            return;

        solved = true;
        onSolved.Invoke();
    }

    public void DisableButtonsMovement()
    {
        foreach (var buttonSolution in buttonSolutions)
        {
            buttonSolution.button.isDisabled = true;
        }
    }

    public void PlayCompleteSound()
    {
        SoundManager.instance.PlayWinSound(gameObject);
    }
}
