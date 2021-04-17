using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    private void Update()
    {
        Vector3 input = Vector3.right * Input.GetAxis("Vertical") + Vector3.up * Input.GetAxis("Horizontal");

        transform.Rotate(input * speed * Time.deltaTime);
    }

}
