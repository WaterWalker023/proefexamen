using System.Collections.Generic;
using UnityEngine;

public class binaryminigame : MonoBehaviour
{
    private List<int> binarynumbers = new List<int>();
    private int total;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        total = 0;
        for (int i = 0; i < binarynumbers.Count; i++)
        {
            total += binarynumbers[i];
        }
        if (total == 15)
        {
            Debug.Log("done");
        }
        Debug.Log(total);
    }

    public void addnumber(int number)
    {
        if (binarynumbers.Contains(number))
        {
            binarynumbers.Remove(number);
        }
        else
        {
            binarynumbers.Add(number);
        }
    }
}
