using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;
//using System.Numerics;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector2 targetPosition;
    private bool movingToPointB = true;
   private void Start() {
    targetPosition = pointB.position;

   }
    void Update()
    {
        patrol();
    }
    void patrol(){
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,targetPosition) < 0.1f)
        {
            if (movingToPointB)
            {
                targetPosition = pointA.position;
                movingToPointB = false;
            }
            else{
                targetPosition = pointB.position;
                movingToPointB = true;
            }
        }

        if (targetPosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);  // Face right
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
    }
}
