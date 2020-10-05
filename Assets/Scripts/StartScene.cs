using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public TextMeshProUGUI ConsoleText;

    private IEnumerator Start()
    {
        Cursor.visible = false;

        string[] consoleText = 
        {
            "> booting system...\n",
            "> loading assets...\n",
            "> WARNING: missing textures detected\n",
            "> loading environment...\n",
            "> WARNING: deadends detected\n",
            "> initiating procedure...\n",
            "> fetching the next subject...\n",
        };

        foreach (string line in consoleText)
        {
            foreach (char ch in line)
            {
                ConsoleText.text += ch;
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(0.3f);
        }

        SceneManager.LoadScene("GameScene");
    }
}
