using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine2 : MonoBehaviour
{
    static public ProjectileLine2 S;
    private LineRenderer line;

    void Awake()
    {
        S = this; // Установить ссылку на объект-одиночку
        // Получить ссылку на LineRenderer
        line = GetComponent<LineRenderer>();
        // Выключить LineRenderer, пока он не понадобится
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
