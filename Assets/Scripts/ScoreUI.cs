using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour {

    
    private int counter = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    public int maxScore = 8;
    public UnityEvent onMaxScore;

    private void Awake()
    {
        Coin.onTestCoin += OnTestCoin;
    }

    private void OnDisable()
    {
        Coin.onTestCoin -= OnTestCoin;
    }

    private void OnTestCoin(object sender, EventArgs e)
    {
        CompareScoreToMax();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = counter.ToString();
        
    }

    public void AddScore(int score)
    {
        counter += score;
    }
    
    public void RemoveScore(int score)
    {
        counter -= score;
    }

    private void CompareScoreToMax()
    {
        if (counter == maxScore)
        {
            onMaxScore.Invoke();
            Debug.Log("Maxed");
        }
    }

    
}
