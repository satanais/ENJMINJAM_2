using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCalculator : MonoBehaviour
{
    public static WaveCalculator current;

    private void Start()
    {
        current = this;
    }

    public float WaveHeight(float x, float y, float time)
    {
        return Mathf.Sin(x + Time.time);
    }
    public float WaveHeight(Vector3 pos, float time)
    {
        // return Mathf.Sin(pos.x + time) * Mathf.Sin(pos.z + time);
        return 0;
    }
}
