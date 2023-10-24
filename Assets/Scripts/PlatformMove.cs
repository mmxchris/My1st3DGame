using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public float speed;
    public Vector3 moveOffSet;
    private Vector3 targetPos;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }
    // Update is called once per frame
    // 
   void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (transform.position == targetPos)
        {
            if (targetPos == startPos)
            {
                targetPos = startPos + moveOffSet;
            }
            else
            {
                    targetPos = startPos;
            }            
        }
    }
    
}