using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalfinal : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public GameObject cutscenemanager;
    public bool isOn = false;
    bool podeapertar = false;

   
    void Update()
    {
        if (podeapertar && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(aperta());
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {


        //set the switch to on sprite
        if (col.tag == "Player")

        {
            podeapertar = true;

        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            podeapertar = false;

        }
    }


    IEnumerator aperta()
    {
        if (!isOn)
        {
                    
            yield return new WaitForSeconds(0.4f);
            //set the isOn to true when triggered
            isOn = true;
            cutscenemanager.SetActive(true);


            yield return new WaitForSeconds(0.5f);
        }
    }
}
