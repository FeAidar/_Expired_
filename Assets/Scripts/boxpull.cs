using UnityEngine;
using System.Collections;

public class boxpull : MonoBehaviour
{

	public float defaultMass;
	public float imovableMass;
	public bool beingPushed =false;
	public int mode= 1;
	public int colliding;
	// Use this for initialization
	void Start()
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		if (mode == 0)
		{
			if (beingPushed == false)
			{
				GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
				

			}
			else
						  
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		


		}
		else if (mode == 1)
		{

			if (beingPushed == false)
			{

				
				GetComponent<Rigidbody2D>().mass = imovableMass;
				GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;

			}
			else
			{
		
				GetComponent<Rigidbody2D>().mass = defaultMass;
				GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
			}

		}
	}







}

