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
    [SerializeField] private GameObject[] NPCS;

    public void pullNPCS()
    {
        NPCS = GameObject.FindGameObjectsWithTag("NPC"); // Adds NPCs into a list by searching them with a tag called "NPC"

        
    }
}
