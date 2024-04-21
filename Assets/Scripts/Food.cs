using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameManager _gameManager;

    private Rigidbody _rigidBody;
    public float foodSpeed;
    public int scorePrice;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.isGameOver == false)
        {
            _rigidBody.AddForce(Vector3.back * foodSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }else
        {
            _rigidBody.AddForce(Vector3.forward * foodSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (transform.position.z <= -75)
        {
            _gameManager.RemoveScore(scorePrice);
            Destroy(gameObject);
        }
    }
}
