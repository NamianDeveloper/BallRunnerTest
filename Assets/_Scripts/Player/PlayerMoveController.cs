using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.W)) _rigidbody.AddForce(Vector3.up * 20);
        //Vector3 addValue = Input.GetKey(KeyCode.W) ? new Vector3(0, 0.1f, 0) : new Vector3(0, -0.1f, 0);
        
        float addValueY = Input.GetKey(KeyCode.W) ? 0.1f : -0.1f;

        Vector3 finaly = new Vector3(0,Mathf.Clamp(transform .position.y +addValueY,-2 ,5), 0);
        
         transform.position = finaly;
    }
}