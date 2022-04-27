using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   
    public string Cena_Creditos;
    public string Cena_Novojogo;
    public string Cena_Lab01;
    public string Cena_Lab02;
    public string Cena_Cidade01;
    public string Cena_Cidade02;
    public string Cena_Esgoto01;
    public string Cena_Esgoto02;
    public string Cena_Lab03;
    public string Cena_Lab04;
    public string Cena_Fim;
    public string Cena_LabtoCity;
    public string Cena_CitytoSewer;
    public string Cena_Menuprincipal;
    public AudioSource cheaton;
    public AudioSource cheatoff;
    public GameObject comecarjogo;
    public GameObject creditos;
    public GameObject Levels;
    public GameObject transicaolevels;
    public GameObject voltaomenu;
    private int deus;
   public bool escolheu = true;
    public GameObject player;
    private bool level;
   

    // Start is called before the first frame update
    void Start()
    {
       
        
        StartCoroutine("começo");
           
    }

    // Update is called once per frame
    void Update()
    {
        if (!level)
        {
            if (player.GetComponent<Character2DController>().pause == false)
                escolheu = false;
        }
    }

    public void StartGame()
    {
        if (!escolheu)
        {
            comecarjogo.SetActive(true);
            escolheu = true;
            Invoke("jogonovo", 4.0f);
        }
        
    }
    public void Retornar()
    {
        if (!escolheu)
        {

            player.GetComponent<Character2DController>().StartCoroutine("desativapause");
            escolheu = false;
                       Debug.Log("tentei" + player.GetComponent<Character2DController>().pause);
                       
            


        }

    }

    public void GodMode()
    {
        if (!escolheu)
        {
            StartCoroutine("GODMODE");
        }
    }

    public void LevelSelector()
    {
        if (!escolheu)
        {
            Levels.SetActive(true);
            escolheu = true;
            StartCoroutine("começo");
        }
    } 

    public void Credits()
    {
        if (!escolheu)
        {
            creditos.SetActive(true);
            escolheu = true;
            Invoke("credits", 1.9f);
            
        }
    }

    public void callMenu()
    {
        if (!escolheu)
        {
            voltaomenu.SetActive(true);
            escolheu = true;
            StartCoroutine("começo");
        }
    }


    public void Tutorial()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("tutorial");
           
        }
    }


    public void Menuprincipal()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("menuprincipal");

        }
    }
    public void Lab01()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level1");
        }
    }

    public void Lab02()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level2");
        }
    }

    public void Cidade01()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level3");
        }
    }

    public void Cidade02()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level4");
        }
    }

    public void Esgoto01()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level5");
        }
    
    }

    public void Esgoto02()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level6");
        }
    }

    public void Lab03()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level7");
        }
    }

    public void Lab04()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level8");
        }
    }

    public void Fim()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("Level9");
        }
    }

    public void labtocity()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("transicao2_3");
        }

    }

    public void citytosewer ()
    {
        if (!escolheu)
        {
            level = true;
            escolheu = true;
            transicaolevels.SetActive(true);
            player.GetComponent<Character2DController>().bloqueio = true;
            StartCoroutine("transicao4_5");
        }
    }

    public void QuitGame()
    {
        //EDITOR UNITY 
        // UnityEditor.EditorApplication.isPlaying = false;
        // JOGO COMPILADO
        Application.Quit();
    }

    IEnumerator GODMODE ()
    {
        if (PlayerPrefs.GetInt("GOD") == 0)
        {
            PlayerPrefs.SetInt("GOD", 1);
            cheaton.Play();
        }
               else
        {
            PlayerPrefs.SetInt("GOD", 0);
            cheatoff.Play();
        }

        yield return new WaitForSecondsRealtime (0.2f);

    }

    public void jogonovo()
    {
        SceneManager.LoadScene(Cena_Novojogo);
    }
   IEnumerator tutorial()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Novojogo);
    }


    public void credits()
    {
        SceneManager.LoadScene(Cena_Creditos);
    }

   IEnumerator começo()
    {
        yield return new WaitForSecondsRealtime(2.5f);
                escolheu = false; 
    
    }

    IEnumerator Level1()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Lab01);
        yield return new WaitForSecondsRealtime(0.1f);
    }

   IEnumerator Level2()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Lab02);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator Level3()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Cidade01);
        yield return new WaitForSecondsRealtime(0.1f);
    }

   IEnumerator Level4()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Cidade02);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator Level5()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Esgoto01);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator Level6()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Esgoto02);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator Level7()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Lab03);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator Level8()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Lab04);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator Level9()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Fim);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator transicao2_3()

    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_LabtoCity);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator transicao4_5()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_CitytoSewer);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator menuprincipal()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        player.GetComponent<Character2DController>().pause = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(Cena_Menuprincipal);
        yield return new WaitForSecondsRealtime(0.1f);
    }

    public void LevelSelectorpause()
    {
        if (!escolheu)
        {
            Levels.SetActive(true);
            
         
        }
    }

    public void callMenupause()
    {
        if (!escolheu)
        {
            voltaomenu.SetActive(true);
       
        }
    }


}
