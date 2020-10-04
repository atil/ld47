using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const float TimeLimit = 130f;

    private float _gameTimer = 0f;
    private float _timerAfterTrigger;

    private Ui _ui;
    private bool _isDead;

    private void Start()
    {
        _ui = FindObjectOfType<Ui>();
    }

    public void OnTimerTrigger()
    {
        _timerAfterTrigger = 0f;
    }

    public void OnFallDown()
    {
        StartCoroutine(FallDownCoroutine());
    }

    private IEnumerator FallDownCoroutine()
    {
        _isDead = true;
        StartCoroutine(_ui.FallDownCoroutine(2f));
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("GameScene");
    }

    public void OnSquished()
    {
        StartCoroutine(SquishCoroutine());
    }

    private IEnumerator SquishCoroutine()
    {
        _isDead = true;
        FindObjectOfType<PlayerMotor>().enabled = false;
        StartCoroutine(_ui.SquishCoroutine(3f));
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("GameScene");
    }

    public void OnEnd()
    {
        StartCoroutine(EndCoroutine());
    }

    private IEnumerator EndCoroutine()
    {
        _isDead = true;
        FindObjectOfType<PlayerMotor>().enabled = false;
        StartCoroutine(FindObjectOfType<Ui>().EndCorutine(5f));
        yield return new WaitForSeconds(5.1f);
        SceneManager.LoadScene("EndScene");
    }

    private void Update()
    {
        if (_isDead)
        {
            return;
        }

        _timerAfterTrigger += Time.deltaTime;
        _gameTimer += Time.deltaTime;
        _ui.SetTriggerTimerText(_timerAfterTrigger);

        _ui.SetGameTimer(_gameTimer / TimeLimit);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}