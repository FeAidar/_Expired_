using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamagarras : MonoBehaviour
{
    public GameObject Garra1;
    public GameObject Garra2;
    public GameObject Diretor1;
    public GameObject Diretor2;
    public GameObject Radar1;
    public GameObject Radar2;
    private bool ativou;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            StartCoroutine("ativagarra");

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ativou = false;
    }

    IEnumerator ativagarra()
    {
        if (!ativou)
        {
            if (Garra1.active==true)
            {
                ativou = true;
                Radar1.SetActive(false);
                Garra1.SetActive(false);
                Diretor1.SetActive(false);
                Diretor2.SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }

            if (Garra2.active == true)
            {
                ativou = true;
                Radar2.SetActive(false);
                Garra2.SetActive(false);
                Diretor2.SetActive(false);
                Diretor1.SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }

        }
    }
}
