using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    int score;
    Text scoreText;

    [SerializeField] int scorePerFrame = 1;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreHit(int hitScore)
    {
        score += hitScore;
        scoreText.text = score.ToString();
    }
}
