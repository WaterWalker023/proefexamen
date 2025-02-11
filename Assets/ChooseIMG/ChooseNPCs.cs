using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ChooseNPCs: MonoBehaviour
{
    //If time = 0
    //Pull npcs to main screen
    //Click button to choose one of the npcs

    [SerializeField] public List<GameObject> NPCS;
    
    public void Start()
    {
        Debug.Log("Pulling NPCs");
    }

    public void Update()
    {
        //if (gameObject.GetComponent<Timer>().time == 0)
        {
            pullNPCS();
        }
    }

    private void pullNPCS()
    {
        NPCS.Add(GameObject.FindGameObjectWithTag("NPC"));
    }
}
