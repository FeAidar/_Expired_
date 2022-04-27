using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour
{
	
	private Explodable _explodable;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(this.tag == "Player")
		{
		if (PlayerPrefs.GetInt("GOD") == 0)
            {
				if (other.gameObject.tag == "Bomba")
				{
					_explodable.explode();
				}
			}

		}

		else
					if (other.gameObject.tag == "Bomba")
		{
			_explodable.explode();
		}


	}

}


