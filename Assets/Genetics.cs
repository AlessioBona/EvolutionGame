using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Genetics : MonoBehaviour
{
    public float speed;
    public float directionAngle;
    public float hue;

    public void Mutation()
    {
        // hue 0-359
        // +- 10

        float hueDiv = Random.Range(-20, 21);
        // Debug.Log(hueDiv);
        hue += hueDiv;
        hue %= 360;

        // speed +- 5
        // boundary 0; 40

        float speedDiv = Random.Range(-7, 8);
        // near the bouandry we want to move away a bit, so don't stay in the extremes
        // Debug.Log(speedDiv);
        if (speed > 36)
        {
            directionAngle = 36;
        }
        if (directionAngle < 4)
        {
            directionAngle = 4;
        }
        speed += speedDiv;
        speed = Mathf.Clamp(speed, 0, 40);




        // angle +- 3
        // boundary 0; 20

        float angleDiv = Random.Range(-3, 4);
        // Debug.Log(angleDiv);
        // near the bouandry we want to move away a bit, so don't stay in the extremes
        if (directionAngle > 17)
        {
            directionAngle = 17;
        }
        if (directionAngle < 3)
        {
            directionAngle = 3;
        }
        directionAngle += angleDiv;
        directionAngle = Mathf.Clamp(directionAngle, 0, 20);

    }

    public Vector3 getMoveVector()
    {
        float angle = Random.Range(0, directionAngle+1);

        float z = Mathf.Sin(angle) * speed;
        float x = Mathf.Cos(angle) * speed;

        float dir = Random.Range(0, 1);

        if (dir < 0.5)
        {
            x = x * -1;
        }

        Vector3 velocity = new Vector3(x, 0, z);

        return velocity;      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
