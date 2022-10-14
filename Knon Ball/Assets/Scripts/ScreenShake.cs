using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.3f;
    private float dampingSpeed = 2f;

    Vector3 initialPosition = new Vector3(0, 0, -10);
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void AddShake(float shakeAmount)
    {
        shakeDuration += shakeAmount;
    }

}
