using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private GameMaster gameMaster;
    void Start() {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gameMaster.lastCheckPointPosition = transform.position;
        }
    }
}