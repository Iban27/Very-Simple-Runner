using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private Rigidbody _rigidBody;
    public float speed;
    public float jumpForce;
    [SerializeField] private float _gravity;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        if (_gameManager.isGameOver == false)
        {
            _rigidBody.AddForce(Vector3.right * horizontal * speed, ForceMode.VelocityChange);
        }

        if(gameObject.transform.position.x >= 5)
        {
            gameObject.transform.position = new Vector3(5, transform.position.y, transform.position.z);
            _rigidBody.velocity = new Vector3(0, _rigidBody.velocity.y, _rigidBody.velocity.z);
        }

        if (gameObject.transform.position.x <= -5)
        {
            gameObject.transform.position = new Vector3(-5, transform.position.y, transform.position.z);
            _rigidBody.velocity = new Vector3(0, _rigidBody.velocity.y, _rigidBody.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.AddForce(Vector3.down * _gravity);

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
