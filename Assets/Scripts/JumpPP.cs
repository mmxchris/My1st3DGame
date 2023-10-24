using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPP : MonoBehaviour
{
    public float rotateSpeed = 180.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddNumOfJumps(1);
            Destroy(gameObject);
        }
    }


}
