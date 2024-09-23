using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    public float speed; 
    public int health;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject lostTextObject;
    private float time;

    void Start() {
        rb = GetComponent <Rigidbody>(); 
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        lostTextObject.SetActive(false);
        time = 0.0f;
    }

    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void Update() {
        time += Time.deltaTime;
    }
   
    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement);
        rb.AddForce(movement * speed); 
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            if (count < 23) {
                health -= 1;  
                SetCountText();  
            }    
        }    
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();   
        countText.text += "\n";
        countText.text += "Health: " + health.ToString(); 
        if (count >= 23) {
            winTextObject.SetActive(true);
            countText.text = "Time: " + string.Format("{0:00}:{1:00}", (int) time / 60, (int) time % 60); 
        }
        if (health == 0) {
            this.gameObject.SetActive(false);
            lostTextObject.SetActive(true);
        }
    }
}
