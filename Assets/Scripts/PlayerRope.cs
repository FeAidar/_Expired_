using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRope : MonoBehaviour
{

    public Rigidbody2D rb;
    private HingeJoint2D hj;
    public float hjump = 1;
    public float vjump =1;
    public float detachforce = 10f;

    public float pushForce = 10f;
    public bool attached = false;
    public Transform attachedTo;
    private GameObject disregard;
    private bool Naovaiesquerda = false;
    private bool Naovaidireita = false;
    private bool naovaiL = false;
    private bool naovaiR = false;
    private float contagemL;
    private float contagemR;
    public bool podepegar;
    public bool pegou;


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }
    
    void Update()
    {
        CheckKeyboardInputs();
        if (!attached)
        {
            naovaiL = false;
            naovaiR = false;
    contagemR = 0;
            contagemL = 0;
        }


       
    }

    void CheckKeyboardInputs()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (attached)
            {
                if (contagemL <= 20)
                {
                    if (!naovaiL)
                    {
                        rb.AddForce(new Vector3(-1, 0, 0) * 4 * pushForce, ForceMode2D.Force);
                        Debug.Log("L" + (contagemL));
                        contagemR = 0;
                        naovaiR = false;
                        contagemL++;
                    }
                    else
                        contagemL++;
                }
                else
                {
                    Naovaiesquerda = true;
                    
                }
            }
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
        {
           if(contagemL > 0 && contagemL <20)
            { naovaiL = true; }

            if (Naovaiesquerda)
            {
                contagemL = 0;
                naovaiL = false;
                Naovaiesquerda = false;
            }
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (attached)
            {
                if (contagemR <= 20)
                {
                    if (!naovaiR)
                    {
                        rb.AddForce(new Vector3(1, 0, 0) * 4 * pushForce, ForceMode2D.Force);
                        Debug.Log((contagemR));
                        contagemL = 0;
                        naovaiL = false;
                    contagemR++;
                    }
                    else
                        contagemR++;
                }
                else
                {
                    Naovaidireita = true;

                }
            }
        }

        if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
        {

            if (contagemR > 0 && contagemR < 20)
            { naovaiR = true; }

            if (Naovaidireita)
            {
                contagemR = 0;
                naovaiR = false;
                Naovaidireita = false;
            }
        }

        //if ((Input.GetKeyDown("w")|| Input.GetKeyDown("up"))&&attached)
        // {
        //      Slide(1);
        // }

        //  if ((Input.GetKeyDown("s")|| Input.GetKeyDown("down"))&&attached)
        //  {
        //      Slide(-1);
        //   }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(attached)
                Detach();
        }



    }


    public void Attach(Rigidbody2D ropeBone)
    {
        ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        hj.connectedBody = ropeBone;
        hj.enabled = true;
        attached = true;
        attachedTo = ropeBone.gameObject.transform.parent;
     
    }

    void Detach()
    {

            hj.connectedBody.gameObject.GetComponent<RopeSegment>().isPlayerAttached = false;
        rb.AddRelativeForce(new Vector2(hjump, vjump) * detachforce, ForceMode2D.Impulse);
            attached = false;
            hj.enabled = false;
        pegou = false;
        hj.connectedBody = null;

        StartCoroutine(Time());
            


    }

    public void Slide(int direction)
    {
        RopeSegment myConnection = hj.connectedBody.gameObject.GetComponent<RopeSegment>();
        GameObject newSeg = null;
        if(direction > 0)
        {
            if(myConnection.connectedAbove != null)
            {
                if(myConnection.connectedAbove.gameObject.GetComponent<RopeSegment>() != null)
                {
                    newSeg = myConnection.connectedAbove;
                }
            }
        }
        else
        {
            if(myConnection.connectedBelow != null)
            {
                newSeg = myConnection.connectedBelow;
            }
        }
        if(newSeg != null)
        {
            transform.position = newSeg.transform.position;
            myConnection.isPlayerAttached = false;
            newSeg.GetComponent<RopeSegment>().isPlayerAttached = true;
            hj.connectedBody = newSeg.GetComponent<Rigidbody2D>();
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (GetComponent<playerpush>().segurando == false)
        {

            if (!attached)
            {
                podepegar = true;
                if (!pegou)
                {
                    if (podepegar == true)
                    {
                        if (col.gameObject.tag == "Rope")
                        {
                            if (attachedTo != col.gameObject.transform.parent)
                            {
                                if (disregard == null || col.gameObject.transform.parent.gameObject != disregard)
                                {
                                    Attach(col.gameObject.GetComponent<Rigidbody2D>());
                                    pegou = true;
                                }
                            }
                        }
                    }
                }



            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (!attached)
        {
            podepegar = false;



        }
    }


    IEnumerator Esquerda()
    {
       
            yield return new WaitForSeconds(2.0f);
            
            
      
    }

    IEnumerator Direita()
    {
        
            yield return new WaitForSeconds(5.0f);

        }

    IEnumerator Time()
    { yield return new WaitForSeconds(1.0f);
        disregard = null;
        attachedTo = null;
    }

}
