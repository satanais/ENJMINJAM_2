using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float depthBeforeSubmerged = 1;
    [SerializeField] private float displacementAmount = 1;
    [SerializeField] private int floaterCount = 1;
    [SerializeField] private float waterDrag = 5;
    [SerializeField] private float waterAngularDrag = 10;


    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaterCount,transform.position, ForceMode.Acceleration);

        float waveHeight = WaveCalculator.current.WaveHeight(transform.position, Time.time);
        if(transform.position.y < waveHeight)
        {
            float displacementMult = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(Vector3.up * Mathf.Abs(Physics.gravity.y) * displacementMult, transform.position, ForceMode.VelocityChange);
            rb.AddForce(displacementMult * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMult * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
