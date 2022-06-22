using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts
{
    public class RagdollManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;

        private void OnCollisionEnter(Collision collision)
        {
            ActivateGravity(true);
        }

        private void Start()
        {
            MakeKinematic(true);
            ActivateGravity(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MakeKinematic(false);
            }
        }

        private void MakeKinematic(bool state)
        {
            for (var i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].isKinematic = state;
                _rigidbodies[i].WakeUp();
                
            }
        }

        public void ActivateGravity(bool state)
        {
            for (var i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].useGravity = state;
            }
        }

    }
}