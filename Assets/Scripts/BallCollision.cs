using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    //[SerializeField] private GameObject gameManager;
    private GameObject gameManager;
    private bool gameIsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameIsPlaying = gameManager.GetComponent<GameManager>().runningGame;
    }

    // Update is called once per frame
    void Update()
    {
        gameIsPlaying = gameManager.GetComponent<GameManager>().runningGame;
        if (!gameIsPlaying)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        bool gameIsPlaying = gameManager.GetComponent<GameManager>().runningGame;
        if (other.gameObject.CompareTag("Ground") && gameIsPlaying)
        {
            Destroy(gameObject);
        }
    }
}
