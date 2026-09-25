using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMeun : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainScene";

    EnemyAudio aud;

    UI_FadeScreen fadeScreen;

    private void Start()
    {
        aud = GetComponentInChildren<EnemyAudio>();
        fadeScreen = GetComponentInChildren<UI_FadeScreen>();
    }


    public void StartGame()
    {
        StartCoroutine(LoadGameWaitFadeEffect(1.5f));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayBGM()
    {
        aud.PlaySFX(0);
    }

    IEnumerator LoadGameWaitFadeEffect(float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
    }
}
