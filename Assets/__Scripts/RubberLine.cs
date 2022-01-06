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
        // Получить ссылку на LineRenderer
        line = GetComponent<LineRenderer>();
        // Установить первую точку
        line.SetPosition(0, SlingshotPoint);
        // Выключить LineRenderer, пока он не понадобится
        line.enabled = false;
    }

    void FixedUpdate()
    {
        // Если свойство poi содержит пустое значение, найти интересующий объект
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
                return; // Выйти, если интересующий объект не найден
            }
        }
        else
        {
            line.enabled = false;
            return; // Выйти, если интересующий объект не найден
        }
    }
}
