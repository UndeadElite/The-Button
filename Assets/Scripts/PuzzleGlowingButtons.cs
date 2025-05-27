using System.Collections.Generic;
using UnityEngine;

public class PuzzleGlowingButtons : MonoBehaviour
{
    [SerializeField] private GlowingPuzzleButton[] buttons;
    private List<int> buttonsRemaining = new List<int>();
    public void ButtonPressed(int index)
    {
        if (buttons[index].IsGlowing == false || buttonsRemaining.Contains(index) == false)
            return;

        buttonsRemaining.Remove(index);
        if (buttonsRemaining.Count == 0)
        {
            //Done
        }
    }

    void RestButtonsRemaining()
    {
        buttonsRemaining.Clear();
        for (int i = 0; i < buttons.Length; i++)
            buttonsRemaining.Add(i);
    }
}
