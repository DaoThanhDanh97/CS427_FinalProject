using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int enemyScore;
    [SerializeField] int hpValue;

    Scoreboard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hpValue <= 0)
        {
            EnemyDestroyed();
        }
        else
        {
            hpValue--;
        }
    }

    void EnemyDestroyed()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        scoreBoard.ScoreHit(enemyScore);
        Destroy(gameObject);
    }
}
