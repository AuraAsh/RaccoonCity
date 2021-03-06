﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    private bool isDead = false;
    public Text scoreText;
    public DeathMenu deathMenu;
    public static int numberOfFish;
    public Text fishText;
    public GameObject RewardPanel;

    void Start()
    {
        numberOfFish = 0;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (score >= scoreToNextLevel)
            LevelUp();

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
        fishText.text = "Fish: " + numberOfFish;
    }
    
    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }
    
    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }

    public void ReceiveReward()
    {
        numberOfFish = 100;
    }
}
