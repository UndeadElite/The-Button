using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PuzzleGlowingButtons : MonoBehaviour
{
    [SerializeField] private UnityEvent onSolved;
    [SerializeField] private UnityEvent onLost;
    [SerializeField] private float buttonGlowTime;
    [SerializeField] private GlowingPuzzleButton[] buttons;
    private List<int> buttonsRemaining = new List<int>();

    private Interactor interactor;
    private float ogInteractorRange = 2;

    private void Awake()
    {
        interactor = FindFirstObjectByType<Interactor>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].indexInPuzzle = i;
            buttons[i].puzzleGlowingButtons = this;
        }
    }

    public void ButtonPressed(int index)
    {
        if (buttons[index].IsGlowing == false || buttonsRemaining.Contains(index) == false)
            return;

        buttons[index].SetGlow(false);
        buttonsRemaining.Remove(index);
        if (buttonsRemaining.Count == 0)
        {
            interactor.InteractRange = ogInteractorRange;
            onSolved.Invoke();
            return;
        }

        int newIndex = buttonsRemaining[Random.Range(0, buttonsRemaining.Count)];
        Debug.Log(newIndex+" : "+buttons[newIndex].name);
        buttons[newIndex].SetGlowTimer(buttonGlowTime);
    }

    public void TriggerLost()
    {
        interactor.InteractRange = ogInteractorRange;
        onLost.Invoke();
    }
    public void RestPuzzle()
    {
        buttonsRemaining.Clear();
        for (int i = 0; i < buttons.Length; i++)
            buttonsRemaining.Add(i);

        foreach (var button in buttons)
        {
            button.SetGlow(false);
        }
    }
    public void StartPuzzle()
    {
        ogInteractorRange = interactor.InteractRange;
        interactor.InteractRange = 100;
        RestPuzzle();
        int newIndex = buttonsRemaining[Random.Range(0, buttonsRemaining.Count)];
        buttons[newIndex].SetGlowTimer(buttonGlowTime);
    }
}
