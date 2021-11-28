using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy3Controller : MonoBehaviour
{

    public static int Score = 0;
    public string ScoreString = "Score";
    public int ScoreValue;

    public Text TextScore;
    public static Enemy3Controller Gamecontroller;

    private void Awake()
    {
        Gamecontroller = this;
    }

    void Start()
    {
        Score = ScoreValue;
    }


    void Update()
    {
        if (TextScore != null)
        {
            TextScore.text = ScoreString + Score;

        }
    }
}