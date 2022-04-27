using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Playables;

public class arte : MonoBehaviour
{
    public GameObject Arte;
    public GameObject Fim;
    private bool Valendo = false;
    private bool liberado = false;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Character2DController>().pause == false)
        {
            if (Valendo)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Time.timeScale == 1)
                    {
                        Invoke("ativa", 0.1f);
                    }
                    else if (Time.timeScale == 0)
                    {
                        Fim.SetActive(true);
                        Time.timeScale = 1;
                        Invoke("espera", 2f);


                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Valendo)
        if(collision.tag=="Player")
        {
            Valendo = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (Valendo)
            if (collision.tag == "Player")
                Valendo = false;
    }

    void ativa()
    {
        if (!liberado)
        {
            Fim.SetActive(false);
            Time.timeScale = 0;
            Arte.SetActive(true);
            this.GetComponent<PlayableDirector>().Stop();
            this.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
            liberado = true;

        }
    }



    void espera()
    {
        liberado = false;
    }


}
