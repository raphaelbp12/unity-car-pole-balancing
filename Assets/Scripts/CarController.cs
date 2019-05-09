using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float w = 1f;
    public float amplitude = 10f;
    public GameObject poleGO;
    public GameObject carGO;

    public float jointAngle;
    public float jointAngleSpeed;
    public float distance;
    public bool gameover;

    public float force;

    public Genome genome;
    public int ticks = 0;
    public int maxLifeTicks = 3000;
    public int maxDistance = 20;

    Rigidbody r;
    HingeJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        r = carGO.GetComponent<Rigidbody>();

        if(poleGO != null)
        {
            joint = poleGO.GetComponent<HingeJoint>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        ticks = ticks + 1;

        jointAngle = joint.angle;
        jointAngleSpeed = joint.velocity;
        distance = Vector3.Distance(carGO.transform.position, Vector3.zero);

        double[] inputs = { jointAngle,  jointAngleSpeed, distance};
        force = (float)genome.EvaluateNeuralNetwork(inputs)[0] * amplitude;

        r.AddForce(Vector3.forward * force);

        CalcGameover();
    }

    bool CalcGameover()
    {
        if (gameover)
        {
            return gameover;
        }

        if (distance > maxDistance)
            setGameover("maxDistance");

        if (ticks > maxLifeTicks)
            setGameover("maxLifeTimeSec");


        return gameover;
    }

    void setGameover(string reason)
    {
        Debug.Log("setGameoverCalled " + reason);
        if (!gameover)
        {
            gameover = true;
            gameObject.SetActive(false);
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
