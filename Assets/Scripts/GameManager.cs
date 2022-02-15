using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject ballHandler;
    [SerializeField] private TMP_Text _pointsText = null;
    /*private Button restartButton;*/
    public int score;
    public bool restart;
    public bool runningGame;
    private int highestScore;
    void Start()
    {
        Instantiate(blockPrefab, new Vector3(0, 4.3f, 0), Quaternion.identity);
        runningGame = true;
        restart = false;
        score = 0;
        highestScore = 0;

/*        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        Vector3 pos = restartButton.transform.position;
        Debug.Log(pos.y);
        pos.y -= 50f;*/


    }

    // Update is called once per frame
    void Update()
    {
        if (runningGame)
        {
            _pointsText.text = score.ToString();
        } else
        {
            if(score > highestScore)
            {
                highestScore = score;
                if(highestScore > 0)
                {
                    PlayerPrefs.SetInt("topScore", highestScore);
                    PlayerPrefs.Save();
                }
                
            }
            _pointsText.text = "Game Over! \n Score: " + score + "\n Highest Score: " + PlayerPrefs.GetInt("topScore");
            if(!restart)
            {
                Invoke(nameof(RestartGame), 2.0f);
                restart = true;
            }
            
        }

    }
    private void RestartGame()
    {
        runningGame = true;
        score = 0;
        Instantiate(blockPrefab, new Vector3(0, 4.3f, 0), Quaternion.identity);
        ballHandler.GetComponent<BallHandler>().SpawnBall();
        return;
    }
}
