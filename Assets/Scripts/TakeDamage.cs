using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Organism")
        {
            GetDamaged(collision.gameObject);
        }
    }

    private void GetDamaged(GameObject organism)
    {
        Debug.Log(organism.tag);
    }
}
