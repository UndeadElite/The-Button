using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingButton : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] movePositions;
    [field: SerializeField] public int index { get; private set; }
    private bool isMoving;

    private ButtonEvent buttonEvent;

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
        if (isMoving || movePositions.Length == 0)
            return;
        
        index++;
        index %= movePositions.Length;
        StartCoroutine(MoveTo(movePositions[index]));

    }

    public IEnumerator MoveTo(Transform nextTransform)
    {
        isMoving = true;
        buttonEvent.intractable = false;
        float ogDistance = Vector3.Distance(transform.position, nextTransform.position);
        float distance = ogDistance;
        while (distance > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextTransform.position, speed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, nextTransform.position);
            transform.rotation = Quaternion.Lerp( nextTransform.rotation,transform.rotation, distance / ogDistance);
            
            yield return null;
        }

        buttonEvent.intractable = true;
        isMoving = false;
        transform.position = nextTransform.position;
        transform.rotation = nextTransform.rotation;
    }
}
