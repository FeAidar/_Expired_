using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    [SerializeField] private AudioSource abrindo;


    //is entry or an exit door
    [SerializeField]
    GameObject DoorType;

    //track the state of the dor
    int stateOfDoor = 1;
    bool abriu;


    void Start()
    {
        anim = GetComponent<Animator>();

          
       

    }


    //function to lock the door and se it's state
    public void LockDoor()
    {
 
            anim.SetFloat("DoorState", 1);
            stateOfDoor = 1;
 
    }

    public void OpenDoor()
    {
    
            anim.SetFloat("DoorState", 2);
            stateOfDoor = 2;
        
        if (!abriu)
        {
            abrindo.Play();
            abriu = true;
        }

    }

    public void SetDoorState(int state)
    {
        if (state == 1)
            LockDoor();
        if (state == 2)
            OpenDoor();
    }

    public int GetDoorState()
    {
        return stateOfDoor;
    }
}

