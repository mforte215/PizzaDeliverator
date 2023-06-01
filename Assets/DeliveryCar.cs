using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCar : MonoBehaviour
{
    [SerializeField] Color32 hasPizzaColor = new Color32 (120,120,120,255);
    [SerializeField] Color32 noPizzaColor = new Color32 (56,56,56,255);
    [SerializeField] float destroyDelay = 0.2f;
    bool hasPizza = false;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPizzaColor;
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Crashed the car!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if ((other.tag == "Pizza") && (!hasPizza)){
            Debug.Log("Picked up Pizza!");
            hasPizza = true;
            spriteRenderer.color = hasPizzaColor;
            Destroy(other.gameObject, destroyDelay);
            
        }
        if ((other.tag == "Customer") && (hasPizza))  {
            Debug.Log("Delivered Pizza!");
            hasPizza = false;
            spriteRenderer.color = noPizzaColor;
        }
    }
}
