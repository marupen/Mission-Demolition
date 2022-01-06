using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine2 : MonoBehaviour
{
    static public ProjectileLine2 S;
    private LineRenderer line;

    void Awake()
    {
        S = this; // ���������� ������ �� ������-��������
        // �������� ������ �� LineRenderer
        line = GetComponent<LineRenderer>();
        // ��������� LineRenderer, ���� �� �� �����������
        line.enabled = false;
    }

    public void SetPositions(List<Vector3> newPoints)
    {
        if (newPoints == null || newPoints.Count == 0)
        {
            line.enabled = false;
        }
        else
        {
            line.positionCount = newPoints.Count;
            for (int i = 0; i < newPoints.Count; i++)
            {
                line.SetPosition(i, newPoints[i]);
            }
            line.enabled = true;
        }
    }
}
