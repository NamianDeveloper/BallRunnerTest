using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    [SerializeField]  private Vector3 offset;  
    [HideInInspector] public static Transform target;
    void LateUpdate() //Перенес в LateUpdate для перемещения камеры после просчета движения персонажа
    {
       if(target) transform.position = target.position + offset;
    }
}
