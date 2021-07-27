using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimationScript : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 0f);
    public float movementFactor;

    [SerializeField] float period = 4;

    Vector3 currentposition;
    Vector3 startingpos;

    public float SpinSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentposition = transform.position;
    }

    void FixedUpdate()
    {
        if (period <= 0f) { return; }

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float RawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = RawSineWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = currentposition + offset;

        transform.Rotate(Vector3.up, SpinSpeed * Time.deltaTime);
    }
}
