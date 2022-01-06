using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Glass : MonoBehaviour
{
    [Header("Set in Inspector")]
    public double MaxImpuls = 20;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();
    }

    void OnCollisionEnter(Collision other)
    {
        double totalImpuls = Sqrt(Pow(other.impulse.x, 2) + Pow(other.impulse.y, 2));
        if (totalImpuls > MaxImpuls)
        {
            // уничтожить цель
            Destroy(this.gameObject);
        }
    }
}
