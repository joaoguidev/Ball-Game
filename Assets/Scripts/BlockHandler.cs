using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockHandler : MonoBehaviour
{
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<GameManager>().restart)
        {
            
            gameManager.GetComponent<GameManager>().restart = false;
            gameManager.GetComponent<GameManager>().runningGame = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bool gameIsPlaying = gameManager.GetComponent<GameManager>().runningGame;
        if (!other.gameObject.CompareTag("Ground") && gameIsPlaying)
        {
            gameManager.GetComponent<GameManager>().score += 1;

        } else
        {
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().runningGame = false;
        }
    }

}
