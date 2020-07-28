using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    //private float speed = 5.0f;

    public bool gameOver = false;
    private bool isOnGround = true;
    private Animator playerAnim;
    private bool Jump_trig;
    private bool Death_b = false;

    [SerializeField] private float jumpForce = 10f;
    public float gravityModifier;

    public ParticleSystem explosionParticles;
    public ParticleSystem dirtSplatter;

    public AudioClip coin;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    private Rigidbody rb;

    private int coinScore;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        score.text = "Coins: ";
    }

    // Update is called once per frame
    void Update()
    {
        //verticalInput = Input.GetAxis("Vertical");
        //horizontalInput = Input.GetAxis("Horizontal");

        /*Vector3 position = transform.position;
        position.x = position.x + Time.deltaTime * speed * horizontalInput;
        position.z = position.z + Time.deltaTime * speed * verticalInput;
        transform.position = position;*/

        score.text = "Coins: " + coinScore;    

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtSplatter.Stop();
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtSplatter.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            dirtSplatter.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticles.Play();
            Debug.Log("Game Over!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            playerAudio.PlayOneShot(coin, 1.0f);
            Destroy(other.gameObject);
            coinScore++;
        }
    }
}
