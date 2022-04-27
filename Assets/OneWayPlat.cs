using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlat : MonoBehaviour
{
    public bool isUp;
    private GameObject player;

    private bool caiu;
   
  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       // float input = Input.GetAxisRaw("Vertical");

        //if (input == -1)
        //{
          //  if (escada == true)
            //    transform.parent.GetComponent<Collider2D>().enabled = false;
            //StartCoroutine(EsperaCair());

        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


            if (collision.tag == "Player")
            {
                StartCoroutine(AtivandoEscada());
             StartCoroutine(Verificador());

        }
        
    }

  

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    IEnumerator EsperaCair()
    {
        
        caiu = true;
        if (isUp == true)
        { isUp = false; }

              yield return new WaitForSeconds(0.2f);


        caiu = false;
        

    }

    IEnumerator AtivandoEscada()
    {


        if (caiu == false)
        {
            
            yield return new WaitForSeconds(0.2f);

            transform.parent.GetComponent<Collider2D>().enabled = isUp;
            
        }
    }

    IEnumerator Verificador()
    { 

            if (isUp == true)
            {
                yield return new WaitForSeconds(0.2f);
                isUp = false;
            }
            else
            {
                
                yield return new WaitForSeconds(0.2f);
                isUp = true;
            }
        
    }
}
