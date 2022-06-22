using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class RagdollManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Rigidbody _pelvisRb;
        // [SerializeField] private Rigidbody _rootRB;
        [SerializeField] private float _forcePelvis;
        // [SerializeField] private float _forceRoot;
        [SerializeField] private ForceMode _forceMode;

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
                // _rootRB.AddForce(-transform.forward * _forceRoot, _forceMode);
                _pelvisRb.AddForce(-transform.forward * _forcePelvis, _forceMode);
            }
        }

        private void MakeKinematic(bool state)
        {
            for (var i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].isKinematic = state;
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