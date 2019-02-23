using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Procreation : MonoBehaviour
{


    public bool toggleOn = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Procreate()
    {
        
        GameObject firstChild = Instantiate(gameObject);
        firstChild.GetComponent<Genetics>().Mutation();
    }

    

    private void OnMouseDown()
    {
        toggleOn = !toggleOn;
        if (GetComponentInChildren<TextMeshProUGUI>())
        {
            TextMeshProUGUI togOn = GetComponentInChildren<TextMeshProUGUI>();
            togOn.enabled = !togOn.enabled;
        }

        Procreate();

        
    }

}
