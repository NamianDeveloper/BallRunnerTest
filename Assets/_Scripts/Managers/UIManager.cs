using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] elementsUI;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private TextMeshProUGUI endGameMessage;

    public int TryCount
    {
        get => PlayerPrefs.GetInt("TryCount", 0);
        set => PlayerPrefs.SetInt("TryCount", value);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public void StartGame()
    {
        levelManager.GenerateLevel();

        elementsUI[0].SetActive(false);
        elementsUI[1].SetActive(false);
        elementsUI[2].SetActive(false);
        elementsUI[3].SetActive(true);

        PlayerCollisionController.Collision += EndGame; //Переподписка при рестарте игры
    }

    private void EndGame()
    {
        elementsUI[1].SetActive(true);
        elementsUI[3].SetActive(false);

        TryCount++;

        endGameMessage.text = $"Вы продержались: {TimeManager.gameTimer.CurrentTime()}\r\nЭто ваша {TryCount} попытка";
    }
}