using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public bool roundOn;

    public float roundTime;

    public int HowManyTogOn()
    {
        int result = 0;
        Procreation[] orgs = FindObjectsOfType<Procreation>();
        foreach(Procreation org in orgs)
        {
            if (org.toggleOn)
            {
                result++;
            }
        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(Round());
    }

    bool canProcreate = false;

    IEnumerator Round()
    {
        Time.timeScale = 1f;
        canProcreate = false;
        yield return new WaitForSeconds(roundTime);
        Time.timeScale = 0.05f;
        canProcreate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canProcreate)
        {
            int togsOn = HowManyTogOn();
            if(togsOn == 3)
            {
                LetProcreate();
                StartCoroutine(Round());
            }
            
        }

        if (Input.GetKeyDown("s"))
        {
            Procreation[] orgs = FindObjectsOfType<Procreation>();
            foreach (Procreation org in orgs)
            {
                if (!org.stats.enabled)
                {
                    org.ToggleStatsOn();
                } else
                {
                    org.stats.enabled = false;
                }
            }
            
        }
    }

    void LetProcreate()
    {
        Procreation[] orgs = FindObjectsOfType<Procreation>();
        foreach (Procreation org in orgs)
        {
            if (org.toggleOn)
            {
                org.Procreate();

            } else
            {
                GameObject.Destroy(org.gameObject);
            }
        }
    }



}
