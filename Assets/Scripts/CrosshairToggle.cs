using UnityEngine;
using System.Collections;

public class CrosshairToggle: MonoBehaviour
{
    public GameObject Crosshair;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        bool isAimingAtCarriable = Physics.Raycast(ray, out _, Carrier.CarryReach, 1 << LayerMask.NameToLayer("Carryable"));
        bool isAimingAtButton = Physics.Raycast(ray, out _, ButtonPresser.ButtonReach, 1 << LayerMask.NameToLayer("Button"));

        Crosshair.SetActive(isAimingAtButton || isAimingAtCarriable);
    }
}
