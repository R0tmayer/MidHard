using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class BoneCollisionChecker : MonoBehaviour
    {
        [SerializeField] private RagdollManager _ragdollManager;
        
        private void OnCollisionEnter(Collision collision)
        {
            _ragdollManager.ActivateGravity(true);
        }
    }
}