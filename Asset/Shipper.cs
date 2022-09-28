using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipper : MonoBehaviour
{
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float fastSpeed = 15f;
    [SerializeField] float slowSpeed = 5f;

    [SerializeField] float steerSpeed = 300f;

    float moveSpeed;

    void Start()
    {
        moveSpeed = normalSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
            moveSpeed = fastSpeed;
        else if (other.tag == "SpeedDown")
            moveSpeed = slowSpeed;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = normalSpeed;
    }
    void Update()
    {
        float keySteer = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float keySpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -keySteer);
        transform.Translate(0, keySpeed, 0);
    }
}
