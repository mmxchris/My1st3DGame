using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public float moveSpeed;
    public float jumpForce;
    public int jumpCount;
    public int numOfJumps = 2;

    private bool isGrounded;
   
    public int score;
    public TextMeshProUGUI scoreText;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y =  0;

        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount != 0)
        {
            --jumpCount;            
            rig.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);

        }
        if (transform.position.y < -5)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            jumpCount = numOfJumps;            
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void AddNumOfJumps(int amount) 
    {
        numOfJumps += amount;
        jumpCount = numOfJumps;
    }
}
