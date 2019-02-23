using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Procreation : MonoBehaviour
{


    public bool toggleOn = false;
    public TextMeshProUGUI togOn;
    Canvas thisCanvas;
    public Vector3 thisGuiPosition;

    private void Awake()
    {
        if (thisCanvas == null)
        {
            thisCanvas = togOn.GetComponentInParent<Canvas>();
            thisGuiPosition = thisCanvas.transform.position - gameObject.transform.position;
        }
    }

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
        toggleOn = false;
        togOn.enabled = false;

        GameObject firstChild = Instantiate(gameObject);
        firstChild.GetComponent<Genetics>().Mutation();
    }

    

    private void OnMouseDown()
    {
        if (toggleOn) {
            toggleOn = false;
            togOn.enabled = false;

        } else
        {
            if (FindObjectOfType<RoundManager>().HowManyTogOn() < 3)
            {
                thisCanvas.transform.rotation = Quaternion.Euler(90, 0, 0);
                thisCanvas.transform.position = gameObject.transform.position + thisGuiPosition;
                toggleOn = true;
                togOn.enabled = true;
               
            }
        }
        

        

        
    }

}
