using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garra : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private GameObject Field;
    public GameObject Mira;
 
    private Vector3 Miraposition;
    

    // Start is called before the first frame update
    void Start()
    {
        Field.SetActive (true);
        Mira.SetActive(true);
        Miraposition = Mira.transform.position;
        fieldOfView.SetAimDirection(Miraposition);


    }

    // Update is called once per frame
    void Update()
    {
        Miraposition = Mira.transform.position;
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(Miraposition);
    }
}
