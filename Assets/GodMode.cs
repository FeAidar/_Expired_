using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodMode : MonoBehaviour
{
    private int check;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
       check = PlayerPrefs.GetInt("GOD");
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()

    {
        check = PlayerPrefs.GetInt("GOD");
        if (check == 1)
            text.text = "GOD MODE LIGADO";
        else
            text.text = "";
        
    }
}
