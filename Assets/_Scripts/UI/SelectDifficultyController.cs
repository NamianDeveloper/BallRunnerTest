using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficultyController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void SelectDifficulty(int difficultyLevel)
    {
        LevelManager.LevelSpeed = difficultyLevel * 0.1f;
        PlayerPrefs.SetInt("DifficultyLevel", difficultyLevel);
    }

    public void ShowPanel(bool status = false)
    {
        panel.SetActive(status);
    }
}
