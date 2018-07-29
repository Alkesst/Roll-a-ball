﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

	private void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
	}

	private void FixedUpdate() {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() { 
        countText.text = "Score: " + count.ToString();
        if (count >= 8) {
            winText.text = "You win!!";
            Destroy(this.gameObject);
        }
    }
}
