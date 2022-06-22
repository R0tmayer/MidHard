using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts
{
    public class RagdollManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Rigidbody _pelvisRb;
        [SerializeField] private float _forcePelvis;
        [SerializeField] private ForceMode _forceMode;
        [SerializeField] private Transform _spear;
        [SerializeField] private float _lerpRate;

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
            }
        }

        public void ActivateGravity(bool state)
        {
            for (var i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].useGravity = state;
            }
        }

        private IEnumerator PushCoroutine()
        {
            _pelvisRb.AddForce(-transform.forward * _forcePelvis, _forceMode);
            float lerp = 0;

            while (true)
            {
                var toVector = _spear.transform.position + new Vector3(0, 0, -0.5f);
                toVector.y = transform.position.y;

                print("Lerp");
                lerp += Time.deltaTime * _lerpRate;
                transform.position = Vector3.Lerp(transform.position, toVector, lerp);
                yield return null;
            }
        }

        public void StickToWall()
        {
            StopCoroutine(PushCoroutine());
            _pelvisRb.constraints = RigidbodyConstraints.FreezePositionX |
                                    RigidbodyConstraints.FreezePositionY |
                                    RigidbodyConstraints.FreezePositionZ;
        }

        public void Push()
        {
            StartCoroutine(PushCoroutine());
        }
    }
}