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

    private int tryCount;
    public void StartGame()
    {
        levelManager.GenerateLevel();
        elementsUI[0].SetActive(false);
        elementsUI[1].SetActive(false);
        elementsUI[2].SetActive(false);
        elementsUI[3].SetActive(true); 
        PlayerCollisionController.Collision += EndGame;
    }

    private void EndGame()
    {
        elementsUI[1].SetActive(true);
        elementsUI[3].SetActive(false);
        tryCount = PlayerPrefs.GetInt("TryCount", 0);
        tryCount++;
        PlayerPrefs.SetInt("TryCount", tryCount);

        endGameMessage.text = $"Вы продержались: {TimeManager.gameTimer.CurrentTime()}\r\nЭто ваша {tryCount} попытка";
    }
}
