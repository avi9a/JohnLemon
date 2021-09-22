using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private GameManager gameManager;
    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gameManager.lastCheckPointPosition = transform.position;
        }
    }
}