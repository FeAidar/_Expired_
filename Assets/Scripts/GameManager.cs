using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject Door;

int noOfSwitches = 0;

    void Start()
    {
       

    }


    public int GetNoOfSwitches()
    {

        int x = 0;

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<Switch>().isOn == false)
                x++;
            else if (switches[i].GetComponent<Switch>().isOn == true)
                noOfSwitches--;
        }

        noOfSwitches = x;

        return noOfSwitches;
    }

    public void GetExitDoorState()
    {
        if (noOfSwitches <= 0)
        {
            Door.GetComponent<Door>().OpenDoor();
        }
    }

    void Update()
    {
        GetNoOfSwitches();
        GetExitDoorState();
    }


}
