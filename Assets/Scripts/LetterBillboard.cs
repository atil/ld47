using UnityEngine;
using System.Collections;

public class LetterBillboard: MonoBehaviour
{
    private Transform _playerTransform;
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMotor>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_playerTransform.position);
        transform.Rotate(0, 180f, 0, Space.World);
    }
}
