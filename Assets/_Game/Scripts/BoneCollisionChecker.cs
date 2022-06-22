using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class BoneCollisionChecker : MonoBehaviour
    {
        [SerializeField] private RagdollManager _ragdollManager;
        private bool _pushed;

        private void OnCollisionEnter(Collision collision)
        {
            _ragdollManager.ActivateGravity(true);
            _ragdollManager.StickToWall();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_pushed)
                return;

            _pushed = true;
            print("push");
            _ragdollManager.Push();
        }
    }
}