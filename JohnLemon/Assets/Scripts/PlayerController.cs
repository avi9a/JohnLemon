using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 45;
    private float turnSpeed = 10;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource audioSource;
    private GameMaster gameMaster;
    void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gameMaster.lastCheckPointPosition;
    }
    void FixedUpdate() {
        Movement();
        MovementAnim();
    }
    public void Movement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        playerRb.AddForce(Vector3.forward * speed * verticalInput);

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize();

        Vector3 directionToward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(directionToward);
    }
    void MovementAnim() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(verticalInput, 0);
        bool hasVerticalInput = !Mathf.Approximately(horizontalInput, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        playerAnim.SetBool("IsWalking", isWalking);
        if (isWalking) {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }
    public void FreezePosition() {
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
    }
}





