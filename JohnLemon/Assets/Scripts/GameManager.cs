using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool soundIsPlayed;
    public float timer;
    public float fadeDuration = 1f;
    public void EndLevel(CanvasGroup canvas, bool restart, AudioSource sound) {
        if (!soundIsPlayed) {
            sound.Play();
            soundIsPlayed = true;
        }
        timer += Time.deltaTime / 2;
        canvas.alpha = timer / fadeDuration;
        if (timer > fadeDuration) {
            if (restart) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else {
                Application.Quit();
            }
        }
    }
}
