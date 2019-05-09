using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class GameRules : MonoBehaviour
{
    Population pop;

    public GameObject carPrefab;

    public int popSize = 10;

    public int numInputs = 4;
    public int numOuputs = 1;

    public List<CarController> cars = new List<CarController>();

    // Start is called before the first frame update
    void Start()
    {
        pop = new Population(popSize, numInputs, numOuputs);
        GenerateCars();
    }

    // Update is called once per frame
    void Update()
    {
        int a = 0;
    }

    void GenerateCars()
    {
        cars = new List<CarController>();
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < popSize; i++)
        {
            GameObject carGO = Instantiate(carPrefab, Vector3.zero, Quaternion.identity);
            CarController car = new CarController();

            car = carGO.GetComponent<CarController>();
            car.genome = pop.population[i];

            cars.Add(car);

        }
    }
}
