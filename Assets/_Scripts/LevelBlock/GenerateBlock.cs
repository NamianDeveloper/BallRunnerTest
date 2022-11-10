using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    [SerializeField] private GameObject blockObject;

    public void GenerateBarrier() //Создание преграды на случайной высоте посередине чанка
    {
         Instantiate(blockObject, new Vector3(transform.position.x, Random.Range(-2, 5f), transform.position.z), new Quaternion(), transform);
    }
}
