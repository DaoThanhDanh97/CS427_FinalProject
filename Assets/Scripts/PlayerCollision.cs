using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject deathSfx;

    [SerializeField] float levelFloatDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        SendMessage("OnPlayerDeath");
        deathSfx.SetActive(true);
        Invoke("ReloadScreen", levelFloatDelay);
    }

    void ReloadScreen() {
        SceneManager.LoadScene(1);
    }
}
