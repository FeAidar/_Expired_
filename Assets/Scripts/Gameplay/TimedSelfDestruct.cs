using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Timed Self-Destruct")]
public class TimedSelfDestruct : MonoBehaviour
{

	// After this time, the object will be destroyed
	public float timeToDestruction;

	
	float conta;

	void Start ()
	{
		float number = Random.Range(0.0f, 3.0f);

		conta = timeToDestruction + number;

		Invoke("DestroyMe", conta);

	}


	// This function will destroy this object :(
	void DestroyMe()
	{
		Destroy(gameObject);

		// Bye bye!
	}
}
