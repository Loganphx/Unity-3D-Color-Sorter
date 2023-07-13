using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject ballPrefab;
    
    [SerializeField] private Box RedBox;
    [SerializeField] private Box GreenBox;
    [SerializeField] private Box BlueBox;
    [SerializeField] private GameObject ballPreview;

    [Header("Settings")]
    [SerializeField] private float moveAmount = 1f;
    
    private int redScore;
    private int greenScore;
    private int blueScore;
    
    private Color scoreColor;
    
    public void Awake()
    {
        RedBox.OnBallEntered += OnRedScore;
        GreenBox.OnBallEntered += OnGreenScore;
        BlueBox.OnBallEntered += OnBlueScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBall();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveCraneLeft();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveCraneRight();
        }
    }

    private void DropBall()
    {
        Instantiate(ballPrefab, ballPreview.transform.position, Quaternion.identity);
    }
    private void MoveCraneLeft()
    {
        ballPreview.transform.position = new Vector3(ballPreview.transform.position.x, ballPreview.transform.position.y, ballPreview.transform.position.z - (moveAmount * Time.deltaTime) );
    }
    
    private void MoveCraneRight()
    {
        ballPreview.transform.position = new Vector3(ballPreview.transform.position.x, ballPreview.transform.position.y, ballPreview.transform.position.z + (moveAmount * Time.deltaTime));
    }

    private void OnDestroy()
    {
        RedBox.OnBallEntered -= OnRedScore;
        GreenBox.OnBallEntered -= OnGreenScore;
        BlueBox.OnBallEntered -= OnBlueScore;
    }

    private void OnRedScore()
    {
        redScore++;
        HandleScoreChanged();
    }


    private void OnGreenScore()
    {
        greenScore++;
        HandleScoreChanged();
    }


    private void OnBlueScore()
    {
        blueScore++;
        HandleScoreChanged();
    }

    private void HandleScoreChanged()
    {
        float totalScore = redScore + greenScore + blueScore;
        scoreColor = new Color(redScore / totalScore * 255, greenScore / totalScore * 255, blueScore / totalScore * 255);
        Camera.main.backgroundColor = scoreColor;

    }
}