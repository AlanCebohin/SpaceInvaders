using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        EnemyMoveController.instance.IsMoving = false;
        EnemyAttackController.instance.IsAttacking = false;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
