using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Score : MonoBehaviour {

    public int Puntaje = 1;

    private void OnDestroy()
    {
        Enemy3Controller.Score -= Puntaje++;
    }
}
