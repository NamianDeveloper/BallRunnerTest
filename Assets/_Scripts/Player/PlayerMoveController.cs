using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private int minYpos;
    [SerializeField] private int maxYpos;
    
    public static float speed;
    
    private Rigidbody _rigidbody;

    private bool isCanMove = true;
    void Start()
    {
        speed = 0.12f;
        _rigidbody = GetComponent<Rigidbody>();
        
        PlayerCollisionController.Collision += StopPlayer;
    }

    void Update()
    {
        if(!isCanMove) return;
        
        float addValueY = Input.GetKey(KeyCode.W) ? speed : -speed - 0.03f;

        Vector3 finaly = new Vector3(0,Mathf.Clamp(transform .position.y +addValueY,minYpos ,maxYpos), 0);
        
         transform.position = finaly;
    }

    private void StopPlayer() => isCanMove = false;
}