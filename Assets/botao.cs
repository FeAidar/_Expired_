using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
    [SerializeField]
    GameObject switchOn;
    [SerializeField] GameObject Player;
    [SerializeField] bool no_chao;

    [SerializeField]
    GameObject switchOff;

    public GameObject cutscenemanager;

    [SerializeField] private AudioSource sombotao;
    public bool isOn = false;
    bool podeapertar = false;

    void Start()
    {
        //set the switch to off sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff.GetComponent<SpriteRenderer>().sprite;
    }

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
            gameObject.GetComponent<SpriteRenderer>().sprite = switchOn.GetComponent<SpriteRenderer>().sprite;
            if (no_chao)
            {
                Player.GetComponent<Character2DController>().botaochao();
            }
            else
                Player.GetComponent<Character2DController>().botaoparede();

            yield return new WaitForSeconds(0.4f);
            //set the isOn to true when triggered
            isOn = true;
            sombotao.Play();
            cutscenemanager.SetActive(true);


            yield return new WaitForSeconds(0.5f);
        }
    }
}
