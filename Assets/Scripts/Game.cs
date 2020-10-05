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
    private int _subjectNumber;

    public bool IsDead { get; private set; }

    private IEnumerator Start()
    {
        _subjectNumber = UnityEngine.Random.Range(1000000, 9999999);
        _ui = FindObjectOfType<Ui>();
        _ui.SetSubjectText(_subjectNumber);

        yield return StartCoroutine(_ui.FadeInCoroutine(1f));
        yield return StartCoroutine(_ui.RunTextCoroutine());

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
        IsDead = true;

        string consoleText = $"> subject #{_subjectNumber} terminated itself. fetching the next subject";

        yield return StartCoroutine(_ui.FallDownCoroutine(2f));
        yield return StartCoroutine(_ui.ConsoleTextCoroutine(consoleText, false));
        yield return StartCoroutine(_ui.GlitchCoroutine(0.5f));

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("GameScene");
    }

    public void OnSquished()
    {
        StartCoroutine(SquishCoroutine());
    }

    private IEnumerator SquishCoroutine()
    {
        if (IsDead)
        {
            yield break;
        }
        IsDead = true;

        string consoleText = $"> subject #{_subjectNumber} terminated itself. fetching the next subject";

        FindObjectOfType<PlayerMotor>().InputEnabled = false;
        Sfx.Instance.Squish();
        yield return StartCoroutine(_ui.SquishCoroutine(2f));
        yield return StartCoroutine(_ui.ConsoleTextCoroutine(consoleText, false));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene");
    }

    public void OnEnd()
    {
        StartCoroutine(EndCoroutine());
    }

    private IEnumerator EndCoroutine()
    {
        IsDead = true;
        
        string consoleText = $"> subject #{_subjectNumber} passed the routine #40293847. preparing routine #91237894 ";

        FindObjectOfType<PlayerMotor>().InputEnabled = false;
        //yield return StartCoroutine(_ui.EndCorutine(1f));
        yield return StartCoroutine(_ui.ConsoleTextCoroutine(consoleText, false));
        yield return new WaitForSeconds(0.1f);

        const string errorConsoleText = "> loading routine 0x000000 ERROR: MEMORY CORRUPTION\n CASUALTY: 74092387 SUBJECTS\n RELOADING THE SAME ROUTINE TO PREVENT FURTHER VIOLATIONS";
        Sfx.Instance.Glitch();
        yield return StartCoroutine(_ui.GlitchCoroutine(1f));
        yield return StartCoroutine(_ui.ConsoleTextCoroutine(errorConsoleText, true));
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("GameScene");
    }

    private void Update()
    {
        if (IsDead)
        {
            return;
        }

        _timerAfterTrigger += Time.deltaTime;
        _gameTimer += Time.deltaTime;
        _ui.SetTriggerTimerText(_timerAfterTrigger);

        _ui.SetGameTimer(_gameTimer / TimeLimit);

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
#endif
    }
}