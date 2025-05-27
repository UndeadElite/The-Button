using System;
using UnityEngine;

public class GlowingPuzzleButton : MonoBehaviour
{
    [NonSerialized] public PuzzleGlowingButtons puzzleGlowingButtons;
    [NonSerialized] public int indexInPuzzle;
    
    [SerializeField] private MeshRenderer buttonMesh;
    [SerializeField] private Material glowMaterial;
    private Material ogMaterial;
    public bool IsGlowing { get; private set; }
    public ButtonEvent buttonEvent { get; private set; }
    private void Awake()
    {
        ogMaterial = buttonMesh.material;
        buttonEvent = GetComponent<ButtonEvent>();
    }

    public void SetGlow(bool active)
    {
        IsGlowing = active;
        if (active)
            buttonMesh.material = glowMaterial;
        else
            buttonMesh.material = ogMaterial;

    }

    public void ButtonPress()
    {
        puzzleGlowingButtons.ButtonPressed(indexInPuzzle);
    }
}
