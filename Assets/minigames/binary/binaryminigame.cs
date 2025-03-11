using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class binaryminigame : MonoBehaviour
{
    private List<int> binarynumbers = new List<int>();
    private int total;
    private int getto;
    
    public UnityEvent onWin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getto = Random.Range(0, 32);
    }

    // Update is called once per frame
    void Update()
    {
        total = 0;
        for (int i = 0; i < binarynumbers.Count; i++)
        {
            total += binarynumbers[i];
        }
        if (total == getto)
        {
            onWin.Invoke();
            getto = Random.Range(0, 32);
        }
        //Debug.Log(total);
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
