using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Score : MonoBehaviour {

    public int Puntaje = 1;

    private void OnDestroy()
    {
        Enemy2Controller.Score -= Puntaje++;
    }
}
