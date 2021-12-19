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

    void Update()
    {
        if (inputs.accel && speed < 10) speed += Time.deltaTime;
        if (inputs.decel && speed > 0)
        {
            speed -= Time.deltaTime;
            if (speed < 0) speed = 0;
        }
        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 input = inputs.arrow;//arrowは取得するたびに計算するため、キャッシュする
        transform.Rotate(new Vector3(-input.y, input.x, 0) * Time.deltaTime * 10);
    }
}
