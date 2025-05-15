using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1_Anim : MonoBehaviour
{
    public float rotationSpeed = 50f; // H�z
    public float maxAngle = 45f;      // En fazla ka� derece sa�a/sola d�necek

    private float angle = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        if (rotatingRight)
        {
            angle += rotationSpeed * Time.deltaTime;
            if (angle >= maxAngle)
                rotatingRight = false;
        }
        else
        {
            angle -= rotationSpeed * Time.deltaTime;
            if (angle <= -maxAngle)
                rotatingRight = true;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
