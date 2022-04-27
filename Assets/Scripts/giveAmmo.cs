using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveAmmo : MonoBehaviour
{
    public GameObject Player;
    public int Repo = 1;
    bool recarrega = false;
    
    void Update()
    {
        if (recarrega && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(carregar());
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            recarrega = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                recarrega = false;
                
            }

        }


        IEnumerator carregar()
        {
        Player.GetComponent<Character2DController>().botaoparede();
        yield return new WaitForSeconds(0.2f);
        AmmoText.balas = Repo;
        yield return new WaitForSeconds(0.5f);
        }



}


