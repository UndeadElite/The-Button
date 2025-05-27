using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MovingButton : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] movePositions;
    [field: SerializeField] public int index { get; private set; }
    private bool isMoving;

    public UnityEvent onFinishedMoving;
    private ButtonEvent buttonEvent;

    public bool isDisabled;

    private void Awake()
    {
        buttonEvent = GetComponent<ButtonEvent>();
    }

    private void Start()
    {
        if (movePositions.Length == 0)
            return;
        index %= movePositions.Length;
        transform.position = movePositions[index].position;
        transform.rotation = movePositions[index].rotation;
    }

    public void MoveToNextPos()
    {
        if (isDisabled || isMoving || movePositions.Length == 0)
            return;
        
        index++;
        index %= movePositions.Length;
        StartCoroutine(MoveTo(movePositions[index].GetComponentsInChildren<Transform>()));

    }

    public IEnumerator MoveTo(Transform[] nextTransforms)
    {
        isMoving = true;
        buttonEvent.intractable = false;
        for (int i = nextTransforms.Length-1; i >= 0 ; i--)
        {
            float playSoundTime = 0;
            float ogDistance = Vector3.Distance(transform.position, nextTransforms[i].position);
            float distance = ogDistance;
            Quaternion ogRotation = transform.rotation;
            while (distance > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextTransforms[i].position, speed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, nextTransforms[i].position);
                transform.rotation = Quaternion.Lerp( nextTransforms[i].rotation,ogRotation, distance / ogDistance);

                if (playSoundTime <= 0)
                {
                    AudioSource audio = SoundManager.instance.PlaySound(gameObject, SoundManager.SoundType.ButtonMove,
                        SoundManager.MixerType.Environment);
                    playSoundTime = audio.clip.length;
                }
                else
                    playSoundTime -= Time.deltaTime;
                
                yield return null;
            }
            
            transform.position = nextTransforms[i].position;
            transform.rotation = nextTransforms[i].rotation;
        }
        buttonEvent.intractable = true;
        isMoving = false;
        onFinishedMoving.Invoke();
    }

    [Header("Editor")]
    [SerializeField] private bool setButtonPosToIndex;

    private void OnValidate()
    {
        if (setButtonPosToIndex)
        {
            setButtonPosToIndex = false;
            index %= movePositions.Length;
            transform.position = movePositions[index].position;
            transform.rotation = movePositions[index].rotation;
        }
    }
}

public interface IScriptUpdate
{
    public void ScriptUpdated();
}
