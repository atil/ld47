using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Carrier : MonoBehaviour
    {
        public Transform CarrySlot;

        private Transform _currentCarryable;

        void Update()
        {
            const float reach = 3f;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            if (_currentCarryable != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 pos;
                    if (Physics.Raycast(ray, out hit, reach, 1 << LayerMask.NameToLayer("Default")))
                    {
                        pos = hit.point;
                    }
                    else
                    {
                        pos = ray.GetPoint(reach);
                    }

                    _currentCarryable.transform.SetParent(null);
                    _currentCarryable.transform.position = pos;
                    _currentCarryable.GetComponent<Rigidbody>().isKinematic = false;
                    _currentCarryable.GetComponent<BoxCollider>().enabled = true;
                    _currentCarryable = null;
                }
                return;
            }

            Debug.DrawRay(ray.origin, ray.direction);
            if (!Physics.Raycast(ray, out hit, reach, 1 << LayerMask.NameToLayer("Carryable")))
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _currentCarryable = hit.transform;
                _currentCarryable.GetComponent<Rigidbody>().isKinematic = true;
                _currentCarryable.GetComponent<BoxCollider>().enabled = false;
                _currentCarryable.transform.SetParent(CarrySlot);
                _currentCarryable.transform.localPosition = Vector3.zero;
                _currentCarryable.transform.localRotation = Quaternion.identity;
            }

        }
    }
}
