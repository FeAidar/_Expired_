using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class gerenciador : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animatorplayer;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private bool fim_de_cena;
    public GameObject acabou;
    public string levelName = SAME_SCENE;
   public const string SAME_SCENE = "0";

    private RuntimeAnimatorController controller;
    public bool concertado =false;
    
    void Awake()
    {
        
        director = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        controller = animatorplayer.runtimeAnimatorController;
        animatorplayer.runtimeAnimatorController = null;
    }

    void Update()
    {
        if (player != null)
        {
            if (director.state != PlayState.Playing && !concertado)
            {
                if (acabou.active)
                    StartCoroutine(fix());

            }

            if (director.state == PlayState.Playing && !concertado)
                player.GetComponent<Character2DController>().Controlavel = false;
            player.GetComponent<Animator>().applyRootMotion = false;
        }

    }

    IEnumerator fix()
    {
        
        player.GetComponent<Animator>().applyRootMotion = true;
        
               
        yield return new WaitForSeconds(0.2f);
        animatorplayer.runtimeAnimatorController = controller;
        player.GetComponent<Character2DController>().Controlavel = true;
        concertado = true;
    if(!fim_de_cena)
        Destroy(gameObject);
        else
        {
            mudacena();

        }

    }

    public void mudacena()
    {
        if (levelName == SAME_SCENE)
        {
            //just restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        else
        {
            //load another scene
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }

    }
}
