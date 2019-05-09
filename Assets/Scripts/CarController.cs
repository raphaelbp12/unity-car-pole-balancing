using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float w = 1f;
    public float amplitude = 10f;
    public GameObject poleGO;

    public float joinAngle;
    public float joinAngleSpeed;
    public float distance;

    Rigidbody r;
    HingeJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();

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
        float force = Mathf.Sin(w * Time.realtimeSinceStartup) * amplitude;

        r.AddForce(Vector3.forward * force);

        joinAngle = joint.angle;
        joinAngleSpeed = joint.velocity;

        distance = Vector3.Distance(transform.position, Vector3.zero);
    }
}
