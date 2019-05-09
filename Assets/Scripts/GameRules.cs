using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class GameRules : MonoBehaviour
{
    Population pop;

    public int popSize = 10;

    public int numInputs = 4;
    public int numOuputs = 1;

    // Start is called before the first frame update
    void Start()
    {
        pop = new Population(popSize, numInputs, numOuputs);
    }

    // Update is called once per frame
    void Update()
    {
        int a = 0;
    }
}
