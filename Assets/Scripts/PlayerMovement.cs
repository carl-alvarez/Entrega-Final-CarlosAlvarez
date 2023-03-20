using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;   
    float horizontalInput;

    public float speedIncreasePerPoint = 1f;

    bool alive = true;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }



    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.GetChild(0).transform.Rotate(speed, 0, 0, Space.Self);

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        speed = 0;
        Invoke("Restart", 2);
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
