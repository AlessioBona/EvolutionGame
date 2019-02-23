using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health = 1;
    public float hue = 0;
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
        health -= organism.GetComponent<Genetics>().getDamage(hue);
        Debug.Log(health);
        if(health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
