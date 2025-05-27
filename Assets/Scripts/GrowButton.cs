using UnityEngine;

public class GrowButton : MonoBehaviour
{
    Vector3 originalScale;
    Vector3 growScale;
    Vector3 targetScale;
    Vector3 currentVelocity = Vector3.zero;
    float smoothTime = 0.1f;
    bool isScaling = false;

    void Start()
    {
        originalScale = transform.localScale;
        growScale = originalScale * 99f;
        targetScale = originalScale;
    }

    void Update()
    {
        if (isScaling)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref currentVelocity, smoothTime);

            // Stop when we're close enough to the target scale
            if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
            {
                transform.localScale = targetScale;
                isScaling = false;
                currentVelocity = Vector3.zero;
            }
        }
    }

    public void Interact()
    {
        targetScale = growScale;
        isScaling = true;
        Invoke(nameof(ResetScale), 0.2f); // delay before shrinking back
    }

    void ResetScale()
    {
        targetScale = originalScale;
        isScaling = true;
    }
}
