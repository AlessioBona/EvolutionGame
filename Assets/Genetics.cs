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
        Debug.Log("I mutate");
        speed++;
        // hier should we mutate the variables

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
