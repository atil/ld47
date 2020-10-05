using UnityEngine;
using System.Collections;

public class ButtonPresser: MonoBehaviour
{
    public const float ButtonReach = 2f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;


        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, ButtonReach, 1 << LayerMask.NameToLayer("Button")))
            {
                Button button = hit.transform.GetComponent<Button>();
                if (button.IsPressed)
                {
                    return;
                }
                button.IsPressed = true;

                if (button.PlayEarthquake)
                {
                    Sfx.Instance.Earthquake();
                    FindObjectOfType<PlayerMotor>().IsShaking = true;
                    StartCoroutine(StopCameraShakeCoroutine());
                }

                Sfx.Instance.Button();
                StartCoroutine(button.PlayPressAnim());

                foreach (var timedExecuter in button.ConnectedExecuters)
                {
                    StartCoroutine(timedExecuter.Init());
                }
            }
        }
    }

    private IEnumerator StopCameraShakeCoroutine()
    {
        yield return new WaitForSeconds(17f);
        FindObjectOfType<PlayerMotor>().IsShaking = false;
    }
}
