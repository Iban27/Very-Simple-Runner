using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDetector : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            int scorePrice = collision.gameObject.GetComponent<Food>().scorePrice;
            _gameManager.AddScore(scorePrice);
            Destroy(collision.gameObject);
        }
    }
}
