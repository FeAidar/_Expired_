
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Teleportation : MonoBehaviour
{

	public GameObject Portal;
	public GameObject Player;
	public GameObject Efeito;
	public bool portalativado;
	private bool tanaarea;
	[SerializeField] private AudioSource Teleporta;


	// Use this for initialization
	void Start()
	{
	}


	void Update()
	{
		if (tanaarea == true)
			if (Player.GetComponent<playerpush>().segurando == false)
			{
				
					if (Input.GetKeyDown(KeyCode.E))
					{
						if (portalativado == false)
						{											

								Invoke("Teleport", 0.5f);

							
						}
					}
				
			}


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		tanaarea = true;
	}

    void OnTriggerExit2D(Collider2D collision)
    {
		tanaarea = false;
    }




    void Teleport()

	{
		if (portalativado == false)
		{
			Teleporta.Play();
			portalativado = true;
			Portal.GetComponent<Teleportation>().portalativado = true;
			Efeito.SetActive(true);
			Invoke("Efeitos", 0.3f);
		}
	}

	void Efeitos()
    {
		
		Player.transform.position = Portal.transform.position;
		Invoke("Tempo", 1.4f);

	}

	void Tempo()
	{
		
		Portal.GetComponent<Teleportation>().portalativado = false;
		this.GetComponent<Teleportation>().portalativado = false;
		

	}


}



