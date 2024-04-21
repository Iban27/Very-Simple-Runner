using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Food[] _foodPrefabs;

    [SerializeField] private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFood()
    {
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (_gameManager.isGameOver == false)
        {
            float randomX = Random.Range(-5, 5);
            Vector3 randomPosition = new Vector3(randomX, 2, 69);
            int randomFood = Random.Range(0, _foodPrefabs.Length);
            //Instantiate(_foodPrefabs[randomFood], randomPosition, Quaternion.identity);
            Food newFood = Instantiate(_foodPrefabs[randomFood], randomPosition, Quaternion.identity);
            newFood.Initialize(_gameManager);
            yield return new WaitForSeconds(2);
        }
    }
}
