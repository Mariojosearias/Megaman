using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudCounters : MonoBehaviour
{

    public static HudCounters instanciar;
    public GameObject Counters;
    
    public static bool disabled = false;

    private void Awake()
    {
        instanciar = this;
    }
    void Start()
    {

    }

    public void Display()
    {
        if (disabled)
        {
            Counters.SetActive(false);
        }
        else
        {
            Counters.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HudCounters.instanciar.Display();

        }
    }
}
    

