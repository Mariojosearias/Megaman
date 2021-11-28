using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Score : MonoBehaviour {

    public int Puntaje = 1;

    public void OnDestroy()
    {
        Enemy1Controller.Score -= Puntaje++;
    }
}
