using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectachao : MonoBehaviour
{
	public bool caixanochao = true;
	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "chao")
		{
			caixanochao = true;
			//Debug.Log("caixa ta no ch�o");
		}
	

	}

	public void OnTriggerExit2D(Collider2D other)
	{

		if (other.gameObject.tag == "chao")
		{
			caixanochao = false;
			//Debug.Log("Caixa Saiu do ch�o");
		}



	}
}
