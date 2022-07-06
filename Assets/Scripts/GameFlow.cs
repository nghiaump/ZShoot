using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private GameObject _gameWinPanel;

    [SerializeField]
    private int _targetNumber;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if(ZombieManager.KilledZombie >= _targetNumber)
        {
            OnMissionCompleted();
        }
    }

    public void OnPlayerDead()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnMissionCompleted()
    {
        _gameWinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnQuitButtonClicked()
    {
        Time.timeScale = 1;
        ZombieManager.KilledZombie = 0;
    }
}
