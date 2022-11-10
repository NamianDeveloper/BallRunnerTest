using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public static GameTimer gameTimer;

    public void StartTimer()
    {
        timerText.text = "00:00";
        StopAllCoroutines();
        gameTimer = new GameTimer();
        StartCoroutine(StartTimerCoroutine());
    }

    private IEnumerator StartTimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            gameTimer.Second++;
            if (gameTimer.Second % 15 == 0 || gameTimer.Second == 0) PlayerMoveController.speed *= 1.1f; //Каждые 15 секунд ускоряю передвижение персонажа по Y

            timerText.text = gameTimer.CurrentTime();
        }
    }
}