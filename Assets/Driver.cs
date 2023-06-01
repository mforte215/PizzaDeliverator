using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 120;
    [SerializeField] float moveSpeed = 6;
    [SerializeField] float slowSpeed = 6f;
    [SerializeField] float boostSpeed = 8f;

    void Update()
    {
        float currentHorizontal = Input.GetAxis("Horizontal");
        float currentVertical = Input.GetAxis("Vertical");
        float steerAmount = currentHorizontal * steerSpeed * Time.deltaTime;
        float moveAmount = currentVertical * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            Debug.Log("Boosted!");
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, 0.1f);
        }
    }
}
