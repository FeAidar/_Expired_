using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explodeonenemy : MonoBehaviour
{

	private Explodable _explodable;
	public GameObject Player;
	public GameObject Campodevisaodagarra;


		
		
	void Start()
	{
		_explodable = Player.GetComponent<Explodable>();
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {

	}
    void Update()

	{
		if (PlayerPrefs.GetInt("GOD") == 0)
		{
			if (Campodevisaodagarra.GetComponent<FieldOfView>().peguei == true)
				_explodable.explode();
		}
		//Debug.Log("era pra morrer");



	}

}

