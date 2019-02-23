using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Genetics : MonoBehaviour
{
    public float speed;
    public float directionAngle;
    public float hue;
    public MeshRenderer myRenderer;

    public void Mutation()
    {
        // hue 0-359
        // +- 10

        float hueDiv = Random.Range(-60, 61);
        // Debug.Log(hueDiv);
        hue += hueDiv;
        hue %= 360f;

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

        ChangeColor();
    }

    public void ChangeColor()
    {
        Color newColor = getRGB();
        myRenderer.material.SetColor("ActiveColor", newColor);
    }
    

    public Vector3 getMoveVector()
    {
        float angle = Random.Range(0, directionAngle+1);

        float z = Mathf.Sin(angle / (2 * Mathf.PI)) * speed;
        float x = Mathf.Cos(angle / (2 * Mathf.PI)) * speed;

        float dir = Random.Range(0, 2);

        if (dir < 0.5)
        {
            x = x * -1;
        }

        Vector3 velocity = new Vector3(x, 0, z);

        return velocity;      
    }

    public Color getRGB()
    {
        Color rgb = Color.HSVToRGB(hue / 360f, 1, 1);
        Debug.Log(rgb);

        return rgb;
    }

    public float getDamage(float enemy_hue)
    {

        float h = Mathf.Abs(hue - enemy_hue) % 360;

        float dmg = Mathf.Min(Mathf.Abs(h), Mathf.Abs(360 - h)) / 90;
        return dmg;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Mutation();
    }
}
