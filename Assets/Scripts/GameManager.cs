using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _goodEndingPanel;
    [SerializeField] private GameObject _badEndingPanel;
    [SerializeField] private int _winScorePrice;
    [SerializeField] private int _loseScorePrice;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scorePrice)
    {
        _score += scorePrice;
        _scoreText.text = "Score: " + _score;
        CheckEndgame();
    }

    public void RemoveScore(int scorePrice)
    {
        _score -= scorePrice;
        _scoreText.text = "Score: " + _score;
        CheckEndgame() ;
    }

    private void CheckEndgame()
    {
        if (_score >= _winScorePrice)
        {
            _goodEndingPanel.SetActive(true);
            isGameOver = true;
        }
        else if (_score <= _loseScorePrice)
        {
            _badEndingPanel.SetActive(true);
            isGameOver = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}