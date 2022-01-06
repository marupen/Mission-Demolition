using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberLine : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Vector3 SlingshotPoint = Vector3.zero;

    private LineRenderer line;
    public static GameObject poi;

    void Awake()
    {
        // �������� ������ �� LineRenderer
        line = GetComponent<LineRenderer>();
        // ���������� ������ �����
        line.SetPosition(0, SlingshotPoint);
        // ��������� LineRenderer, ���� �� �� �����������
        line.enabled = false;
    }

    void FixedUpdate()
    {
        // ���� �������� poi �������� ������ ��������, ����� ������������ ������
        if (poi != null)
        {
            if (poi.tag == "Projectile")
            {
                Vector3 ProjectilePoint = poi.transform.position - SlingshotPoint;
                ProjectilePoint.z = 0;
                ProjectilePoint.Normalize();
                ProjectilePoint = poi.transform.position + ProjectilePoint * poi.GetComponent<SphereCollider>().radius;
                ProjectilePoint.z = SlingshotPoint.z;
                line.SetPosition(1, ProjectilePoint);
                line.enabled = true;
            }
            else
            {
                line.enabled = false;
                return; // �����, ���� ������������ ������ �� ������
            }
        }
        else
        {
            line.enabled = false;
            return; // �����, ���� ������������ ������ �� ������
        }
    }
}
