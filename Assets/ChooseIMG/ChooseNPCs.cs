using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine.Events;

public class ChooseNPCs: MonoBehaviour
{
    //If time = 0
    //Pull npcs to main screen
    //Click button to choose one of the npcs

    
    [SerializeField] private GameObject[] NPCS;
    
    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void pullNPCS()
    {
        NPCS = GameObject.FindGameObjectsWithTag("NPC"); // Adds NPCs into a list by searching them with a tag called "NPC"

        
    }
}
