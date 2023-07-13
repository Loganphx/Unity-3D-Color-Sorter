using System;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject ballPrefab;
    
    [SerializeField] private Box RedBox;
    [SerializeField] private Box GreenBox;
    [SerializeField] private Box BlueBox;
    
    [SerializeField] private Text _redText;
    [SerializeField] private Text _greenText;
    [SerializeField] private Text _blueText;
    [SerializeField] private Text _colorText;
    
    [SerializeField] private GameObject ballPreview;

    
    [Header("Settings")]
    [SerializeField] private float moveAmount = 1f;
    
    [SerializeField] private int redScore;
    [SerializeField] private int greenScore;
    [SerializeField] private int blueScore;
    
    [SerializeField] private Color scoreColor;
    
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
        var redHex = (int)Mathf.Round(redScore / totalScore * 255);
        var greenHex = (int)Mathf.Round(greenScore / totalScore * 255);
        var blueHex = (int)Mathf.Round(blueScore / totalScore * 255);
        scoreColor = new Color(redHex, greenHex, blueHex);


        _redText.text = $"R: {redHex}";
        _greenText.text = $"G: {greenHex}";
        _blueText.text = $"B: {blueHex}";
        var hex = $"#{redHex:X2}{greenHex:X2}{blueHex:X2}";
        _colorText.text = $"Hex: <color={hex}>{hex}</color>";
    }
}