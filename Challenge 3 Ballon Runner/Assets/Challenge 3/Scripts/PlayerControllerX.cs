using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float topBound = 15.0f;
    public bool gameOver;
    private bool isHightBound;

    public float downForce;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 30, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        //Determina si exede los limites del techo
        //Esta es otra manera de comprobar un booleano si es verdadero o falso, en este caso si es verdadero se cumple la condición igualada, de otro mdo va a ser falso.

        isHightBound = (transform.position.y > topBound);
        
        if (isHightBound)
        {
            playerRb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            //Se destruye después de 1 segundos
            Destroy(this.gameObject, 0.8f);
        } 

        // if player collides with money, fireworks
        else if (other.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerAudio.PlayOneShot(boingSound, 1.0f);
        }
    }

    /* private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Foe"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    } */

}
