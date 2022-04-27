using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Lanterna : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private GameObject Field;
    public GameObject Player;

    


    // Start is called before the first frame update
    void Start()
    {
        Field.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(Player.transform.position);
    }
}