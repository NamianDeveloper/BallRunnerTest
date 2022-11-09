using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    [SerializeField] private GameObject blockObject;
    void Start()
    {
        Instantiate(blockObject, new Vector3(transform.position.x, Random.Range(0, 4f), transform.position.z), new Quaternion(), transform);
    }
    
}
