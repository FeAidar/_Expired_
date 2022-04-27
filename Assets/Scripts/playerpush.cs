using UnityEngine;
using System.Collections;

public class playerpush : MonoBehaviour
{
	Animator playeranima;
	public bool segurando = false;
	bool testando = false;
	GameObject box = null;
	public bool pegacaixa;

	// Use this for initialization
	void Start()
	{
		playeranima = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (segurando)
				{
					if (box != null)
					{
						box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
						box.GetComponent<FixedJoint2D>().enabled = true;
						box.GetComponent<boxpull>().beingPushed = true;
						testando = true;
						pegacaixa = true;

						if (transform.rotation.y == 0)
						{
							if (Input.GetAxisRaw("Horizontal") > 0)
							{
								playeranima.SetBool("Empurrando", true);
								playeranima.SetBool("Puxando", false);
							playeranima.SetBool("Segurando", false);
							//Debug.Log("Empurrando");
						}
							if (Input.GetAxisRaw("Horizontal") < 0)
							{
								playeranima.SetBool("Empurrando", false);
								playeranima.SetBool("Puxando", true);
							playeranima.SetBool("Segurando", false);
							//Debug.Log("Puxando");
						}

							if (Input.GetAxisRaw("Horizontal") == 0)
							{
								playeranima.SetBool("Empurrando", false);
								playeranima.SetBool("Puxando", false);
							playeranima.SetBool("Segurando", true);
								//Debug.Log("Parou");
							}
						}
						else
						{

							if (Input.GetAxisRaw("Horizontal") < 0)
							{
								playeranima.SetBool("Empurrando", true);
								playeranima.SetBool("Puxando", false);
							playeranima.SetBool("Segurando", false);
							//Debug.Log("NADA");
						}
							if (Input.GetAxisRaw("Horizontal") > 0)
							{
								playeranima.SetBool("Empurrando", false);
								playeranima.SetBool("Puxando", true);
							playeranima.SetBool("Segurando", false);

						}
							if (Input.GetAxisRaw("Horizontal") == 0)
							{
								playeranima.SetBool("Empurrando", false);
								playeranima.SetBool("Puxando", false);
							playeranima.SetBool("Segurando", true);
							//Debug.Log("Parou");
						}

						}

						StartCoroutine(coisa());

					}
				}
			}

		if (segurando && testando && Input.GetKeyUp(KeyCode.LeftShift))
		{
			box.GetComponent<FixedJoint2D>().enabled = false;
			box.GetComponent<boxpull>().beingPushed = false;
			segurando = false;
			testando = false;
			pegacaixa = false;
			playeranima.SetBool("Puxando", false);
			playeranima.SetBool("Empurrando", false);
			playeranima.SetBool("Segurando", false);
			box = null;
			StartCoroutine(coisa());
		}

		if (segurando && Input.GetKeyUp(KeyCode.LeftShift))

		{
			box.GetComponent<FixedJoint2D>().enabled = false;
			box.GetComponent<boxpull>().beingPushed = false;
			segurando = false;
			testando = false;
			box = null;
			pegacaixa = false;
			playeranima.SetBool("Puxando", false);
			playeranima.SetBool("Empurrando", false);
			playeranima.SetBool("Segurando", false);
			StartCoroutine(coisa());
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			
			
						
				segurando = false;
				testando = false;
				box = null;
				pegacaixa = false;
				playeranima.SetBool("Puxando", false);
				playeranima.SetBool("Empurrando", false);
			playeranima.SetBool("Segurando", false);
			StartCoroutine(coisa());

			


		}
	
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if (!segurando)
		{
			if (other.gameObject.tag == "pushable")
			{
				box = other.gameObject;
				segurando = true;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "pushable")
		{ if (Input.GetKeyUp(KeyCode.LeftShift))
			{

				box.GetComponent<FixedJoint2D>().enabled = false;
				box.GetComponent<boxpull>().beingPushed = false;
				pegacaixa = false;
				testando = false;
				playeranima.SetBool("Puxando", false);
				playeranima.SetBool("Empurrando", false);
				playeranima.SetBool("Segurando", false);
			}
			segurando = false;
			box = null;
		}
	}
	IEnumerator coisa()
	{
		if (box != null)
		{
			if (box.GetComponentInChildren<detectachao>().caixanochao == false)
			{
				box.GetComponent<FixedJoint2D>().enabled = false;
				box.GetComponent<boxpull>().beingPushed = false;
				pegacaixa = false;
				testando = false;
				playeranima.SetBool("Puxando", false);
				playeranima.SetBool("Empurrando", false);
				playeranima.SetBool("Segurando", false);
				segurando = false;
				box = null;
			}

		}

		if (box != null)
		{
			if (GetComponentInChildren<detectachao>().caixanochao == false)
			{
				box.GetComponent<FixedJoint2D>().enabled = false;
				box.GetComponent<boxpull>().beingPushed = false;
				pegacaixa = false;
				testando = false;
				playeranima.SetBool("Puxando", false);
				playeranima.SetBool("Empurrando", false);
				playeranima.SetBool("Segurando", false);
				segurando = false;
				box = null;
			}

		}

		if (box!= null)
		{
			if (Input.GetKeyUp(KeyCode.LeftShift))
			{

				box.GetComponent<FixedJoint2D>().enabled = false;
				box.GetComponent<boxpull>().beingPushed = false;
				pegacaixa = false;
				testando = false;
				playeranima.SetBool("Puxando", false);
				playeranima.SetBool("Empurrando", false);
				playeranima.SetBool("Segurando", false);
				segurando = false;
				box = null;
			}

		}

		yield return new WaitForSeconds(0.2f * Time.deltaTime); 
	}

}