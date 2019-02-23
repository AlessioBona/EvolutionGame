using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Procreation : MonoBehaviour
{


    public bool toggleOn = false;
    public TextMeshProUGUI togOn;
    public TextMeshProUGUI stats;
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
        if (stats.enabled || togOn.enabled)
        {
            thisCanvas.transform.rotation = Quaternion.Euler(90, 0, 0);
            thisCanvas.transform.position = gameObject.transform.position + thisGuiPosition;
        }
    }

    public void Procreate()
    {
        toggleOn = false;
        togOn.enabled = false;
        stats.enabled = false;

        GameObject firstChild = Instantiate(gameObject);
        firstChild.transform.position -= new Vector3(0f, 0f, 1f);
        firstChild.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        firstChild.GetComponent<Genetics>().Mutation();
        gameObject.GetComponent<Genetics>().Mutation();
        //firstChild.GetComponent<Rigidbody>().velocity = firstChild.GetComponent<Genetics>().getMoveVector();
        //gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Genetics>().getMoveVector();
    }

    public void ToggleStatsOn()
    {
        stats.enabled = true;

        Genetics genetics = gameObject.GetComponent<Genetics>();
        stats.text = "speed: " + genetics.speed +  "\n color: " + genetics.hue; // HERE we should put ATTACK!!!
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

                toggleOn = true;
                togOn.enabled = true;
               
            }
        }
        

        

        
    }

}
