using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public PlayerController playerController;
    public bool playerInRange;
    private void OnTriggerEnter(Collider other) {
        if (other.transform == player) {
            playerInRange = true;
            playerController.FreezePosition();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.transform == player) {
            playerInRange = false;
        }
    }
    private void Update() {
        if (playerInRange) {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.green);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider.transform == player) {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
