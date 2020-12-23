using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 600f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("w") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            Debug.Log($"Score: {score}");
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log($"Health: {health}");
        }
    }
}
