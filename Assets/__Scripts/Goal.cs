using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Goal : MonoBehaviour
{
    [Header("Set in Inspector")]
    public double MaxImpuls = 45.0;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();
    }

    // ����������� ����, ��������� ������ ������� ����
    static public bool goalMet = false;
    void OnCollisionEnter(Collision other)
    {
        double totalImpuls = Sqrt(Pow(other.impulse.x, 2) + Pow(other.impulse.y, 2));
        print(totalImpuls);
        // ����� � ������� �������� �������� �������� ���-��, �������� ������� ��������������
        if (totalImpuls > MaxImpuls)
        {
            // ���� ��� ������, ��������� ���� goalMet �������� true
            Goal.goalMet = true;
            // ���������� ����
            Destroy(this.gameObject);
        }
    }
}
