using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    float speed;
    PlayerInputs inputs;
    void Start()
    {
        inputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.accel && speed < 10) speed += Time.deltaTime;
        if(inputs.decel && speed > 0)
        {
            speed -= Time.deltaTime;
            if (speed < 0) speed = 0;
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(getRotate() * Time.deltaTime * 10);
    }
    Vector3 getRotate()
    {
        Vector3 input = inputs.arrow;
        return new Vector3(input.y, input.x, 0);
    }
}
