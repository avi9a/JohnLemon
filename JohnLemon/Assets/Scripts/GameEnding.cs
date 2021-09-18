using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour {
    public float captureRate = 1f;
    public GameObject player;
    public CanvasGroup caughtCanvas;
    public CanvasGroup wonCanvas;
    public bool isPlayerCaught;
    public bool isPlayerTheWinner;
    public GameManager gameManager;
    public AudioSource caughtSound;
    public AudioSource winSound;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerTheWinner = true;
        }
    }
    public void CaughtPlayer() {
        isPlayerCaught = true;
    }
    private void Update() {
        if (isPlayerTheWinner) {
            gameManager.EndLevel(wonCanvas, false, winSound);
        }
        else if (isPlayerCaught) {
            StartCoroutine(Capture());
        }
    }
    private IEnumerator Capture() {
        Debug.Log("Caught");
        yield return new WaitForSeconds(captureRate);
        gameManager.EndLevel(caughtCanvas, true, caughtSound);
    }
}
