using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;



public class Character2DController : MonoBehaviour
{
    [SerializeField] private AudioSource Passos;
    [SerializeField] private AudioSource Pulo;
    [SerializeField] private AudioSource Puxa;
    [SerializeField] private AudioSource Empurra;
    [SerializeField] private AudioSource Morte;
    [SerializeField] private AudioSource Lancagranada;
    [SerializeField] private AudioSource objetoempurrado;
    [SerializeField] private GameObject Bala;
    public GameObject Chamapause;
    public GameObject Encerapause;

    Animator playeranima;
    public bool podeatirar;
    public bool Controlavel = false;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public bool pause;
    public bool bloqueio;
    private bool tempodeanimacao;
    private bool tempo2;

    public ProjectileBehaviour ProjectilePrefab;
    public ProjectileBehaviour BombPrefab;
    public int balas = 1;
    public Transform LaunchOffset;

    float movement = 0f;
    private Rigidbody2D _rigidbody;
    float y;
    private float maxYvel;
    bool jumping = false;
    public bool morreu = false;
    public bool nochao;
    bool andando;
    bool puxando;
    bool empurrando;
    bool tocouempurra;
    bool tocoupuxa;
    bool segurando;
    public static bool teladeteleportdopause;
    //aqui vao bools de  checkpoint
    bool chckpoint_cidade1;
    bool chckpoint_cidade2;
  bool chckpoint_cidade3;
    bool chckpoint_lab3;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playeranima = GetComponent<Animator>();
                Scene scene = SceneManager.GetActiveScene();
       AmmoText.balas = 0;
    }

    void Update()

    {
  
        if (GetComponentInChildren<detectachao>().caixanochao == false)
        {
            nochao = false;
        }
        else
            nochao = true;


        if (Controlavel == true)
        {
            if (!morreu) {
                if (Encerapause != null)
                {
                    if (Chamapause != null) { 

                        if (Input.GetButtonDown("Cancel"))
                        {

                            if(!bloqueio)

                            {
                                if (Time.timeScale == 1)
                                {
                                    if (!pause)
                                    {

                                        pause = true;
                                        Encerapause.SetActive(false);
                                        Invoke("ativapause", 0.3f);
                                        StartCoroutine("tempodecomeço");
                                    }
                                }


                                if (Time.timeScale == 0)
                                {

                                    if (pause)
                                    {


                                        StartCoroutine("tempodecomeço");
                                        StartCoroutine("desativapause");
                                    }


                                }
                            }




                        }
                } }
            }
        }

        //  if (nochao == false)
        // Debug.Log("Saiu");
        //  else
        //   Debug.Log("no chao");



        if (Controlavel == true)
        {
            if (!pause)
            {
                andando = playeranima.GetBool("Andando");
                puxando = playeranima.GetBool("Puxando");
                empurrando = playeranima.GetBool("Empurrando");
                segurando = playeranima.GetBool("Segurando");

                if (!morreu)
                {

                    movement = Input.GetAxisRaw("Horizontal");
                    y = _rigidbody.velocity.y;

                    if (!Mathf.Approximately(0, movement))
                    {
                        if (GetComponent<playerpush>().pegacaixa == false)
                        {
                            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

                        }

                        if (jumping == false)
                            playeranima.SetBool("Andando", true);
                    }



                    else
                    {
                        if (Input.GetAxisRaw("Horizontal") == 0)
                            playeranima.SetBool("Andando", false);
                        else
                            playeranima.SetBool("Andando", true);

                    }

                    if (jumping && _rigidbody.velocity.y == 0)
                    {
                        jumping = false;

                        if (PlayerPrefs.GetInt("GOD") == 0)

                        {
                            if (maxYvel <= -70 && nochao)
                            {
                                TakeFallDamage();
                            }
                        }


                    }

                    if (_rigidbody.velocity.y < maxYvel)
                        maxYvel = _rigidbody.velocity.y;



                    if (Input.GetButtonDown("Jump") && !jumping)
                    {
                        if (GetComponent<playerpush>().pegacaixa == false)
                        {

                            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                            playeranima.SetTrigger("Jump");
                            // Debug.Log(_rigidbody.velocity.y);
                            maxYvel = 0;
                            Pulo.Play();
                            jumping = true;

                        }
                    }

                    // if(Input.GetButtonDown("Fire1"))
                    //{ 
                    //  Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                    //  }
                    if (podeatirar)
                    {
                        if (AmmoText.balas > 0)
                        {
                            Bala.SetActive(true);

                            if (GetComponent<playerpush>().pegacaixa == false)
                            {
                                if (Input.GetButtonDown("Fire2"))
                                {
                                    podeatirar = false;
                                    StartCoroutine(coisa());
                                }
                            }

                        }
                        else
                            Bala.SetActive(false);
                    }


                }
                else
                    playeranima.SetBool("Andando", false);


                if (andando == true)
                {
                    if (jumping == false)
                        StartCoroutine(tempodepasso());
                }

            }
        }
    }
    void FixedUpdate()
    {
        if (!Controlavel)
        {
            playeranima.SetBool("Cutscene", true);
            
        }

        if (Controlavel == true)
        {
            if (!pause)
            {

                playeranima.SetBool("Cutscene", false);
                playeranima.applyRootMotion = true;

                if (morreu == false)

                {
                    transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
                }


                if (maxYvel <= -70 && nochao)
                {
                    if (PlayerPrefs.GetInt("GOD") == 0)
                        TakeFallDamage();
                }


                if (empurrando == true)
                {

                    if (!Empurra.isPlaying)
                    {
                        if (!tocouempurra)
                        {
                            objetoempurrado.Play();
                            Empurra.Play();
                        }
                        tocouempurra = true;
                    }
                }
                else
                {
                    Empurra.Stop();
                    tocouempurra = false;

                    if (puxando == false)
                        objetoempurrado.Stop();

                }


                if (puxando == true)
                {

                    if (!Puxa.isPlaying)
                    {
                        if (!tocoupuxa)
                        {
                            Puxa.Play();
                            objetoempurrado.Play();
                        }
                        tocoupuxa = true;
                    }
                }
                else

                {
                    Puxa.Stop();
                    tocoupuxa = false;
                    if (empurrando == false)
                        objetoempurrado.Stop();
                }


            }
        }
}

    IEnumerator tempodepasso()
    {
        if (!Passos.isPlaying)
        {
            if (!jumping)
            { Passos.Play(); }
            else
            {
                Passos.Stop();
            }

            if (GetComponent<playerpush>().pegacaixa == false)
            { Passos.Play(); }
            else
            {
                Passos.Stop();
            }
        }

        yield return new WaitForSeconds(0.6f);
       
 
    }

    IEnumerator coisa()
    {
        playeranima.SetTrigger("Granada");
        Lancagranada.Play();
                yield return new WaitForSeconds(0.2f);
        Instantiate(BombPrefab, LaunchOffset.position, transform.rotation);
     AmmoText.balas -= 1;
     podeatirar = true;
                 
    }

   
            public void TakeFallDamage()
    {

        Debug.Log("Morreu");
        morreu = true;
        playeranima.SetBool("morreu", true);
        StartCoroutine(recarregando());
    }

    IEnumerator recarregando()
    { yield return new WaitForSeconds(5.0f);


        if (chckpoint_cidade1)
        {
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene("03b - Cidade - FATIMA", LoadSceneMode.Single);
        }
        else
        if (chckpoint_cidade2)
        {
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene("03c - Cidade Predio", LoadSceneMode.Single);
        }
        else
        if (chckpoint_cidade2)
        {
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene("03d - Cidade Predio 2", LoadSceneMode.Single);
        }
else
        if (chckpoint_lab3)
        {
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene("07b - Laboratorio final", LoadSceneMode.Single);
        }
        else
        {
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }


    public void chkpointcidade01()
    {
        chckpoint_cidade1 = true;
        chckpoint_cidade2 = false;
        chckpoint_cidade3 = false;
        chckpoint_lab3 = false;
    }
    public void chkpointcidade02()
    {
        chckpoint_cidade2 = true;
        chckpoint_cidade3 = false;
        chckpoint_cidade1 = false;
        chckpoint_lab3 = false;
    }
    public void chkpointcidade03()
    {
        chckpoint_cidade3 = true;
        chckpoint_cidade1 = false;
        chckpoint_cidade2 = false;
        chckpoint_lab3 = false;
    }

    public void chkpointlab3()
    {
        chckpoint_lab3 = true;
        chckpoint_cidade1 = false;
        chckpoint_cidade2 = false;
        chckpoint_cidade3 = false;
    }

    public void botaochao()
    {
        StartCoroutine("botaonochao");
    }

 public void botaoparede()
    {
        StartCoroutine("botaonaparede");
    }

    IEnumerator botaonochao()
    {
        
        playeranima.SetTrigger("Botaochao");
        yield return new WaitForSeconds(0.4f * Time.deltaTime);
      
       
    }

    IEnumerator botaonaparede()
    {
        
        
        playeranima.SetTrigger("Botaoparede");
        yield return new WaitForSeconds(0.4f * Time.deltaTime);
        
    }

    void ativapause()
    {
        if (pause)
        {
           

                Time.timeScale = 0;
                Chamapause.SetActive(true);
                



        }
    }

    IEnumerator tempodecomeço()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        tempodeanimacao = true;
        tempo2 = true;

    }

    public IEnumerator desativapause()
    {
        if (pause)
        {
       
            if (tempodeanimacao)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                Encerapause.SetActive(true);
                Time.timeScale = 1;
                
                yield return new WaitForSecondsRealtime(1.5f);
                Debug.Log("liberou");
                pause = false;
                tempodeanimacao = false;
                yield return new WaitForSecondsRealtime(0.1f);

            }
        }
    }

}
