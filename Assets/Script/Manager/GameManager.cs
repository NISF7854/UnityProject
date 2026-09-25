using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float RestartTime = 3.0f;
    Player player;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        player = PlayerManager.instance.player;
    }


    private void Update()
    {
        if(player.isDead)
        {
            RestartTime -= Time.deltaTime;
        }
        if(RestartTime <= 0)
        {
            RestartGame();
        }
    }

    //重启游戏
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SaveManager.instance.Delete();
        SceneManager.LoadScene(scene.name);
    }
    //暂停游戏
    public void PauseGame(bool _state)
    {
        if(_state == true)
        {
            Time.timeScale = 0f;
        }
        if(_state == false)
        {
            Time.timeScale = 1f;
        }
    }
    //退出游戏
    public void ExitGame()
    {
        Application.Quit();
    }
}
