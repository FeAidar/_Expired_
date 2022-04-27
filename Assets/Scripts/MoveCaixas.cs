using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCaixas : MonoBehaviour
{
  
    public GameObject CaixaPassado;
    public GameObject CaixaFuturo;
    public bool Futuro=false;
    float x1, y1;
    float x2, y2;
    float xinicial1, xinicial2, yinicial1, yinicial2;
    float xfinal1, xfinal2, yfinal2, yfinal1;
   

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos1 = (CaixaPassado).transform.position;
        Vector2 pos2 = (CaixaFuturo).transform.position;
        xinicial1 = pos1.x;
        yinicial1 = pos1.y;
        xinicial2 = pos2.x;
        yinicial2 = pos2.y;

    }

    // Update is called once per frame
    public void Update()
    {

        Vector2 posnova1 = (CaixaPassado).transform.position;
        xfinal1 = posnova1.x;
        yfinal1 = posnova1.y;
        x1 = xinicial1 - xfinal1;
        y1 = yinicial1 - yfinal1;

       



    }

   private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(MoveCaixa());

        }
    }

    IEnumerator MoveCaixa()
   {

        yield return new WaitForSeconds(0.5f);
        
    if (!Futuro)
    {
     if (xfinal1 != xinicial1)
       {
        CaixaFuturo.transform.position = new Vector2(xinicial2 - x1, yfinal1);

                                                      }


    }




    }

}