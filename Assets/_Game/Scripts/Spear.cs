using System;
using System.Linq;
using UnityEngine;

namespace _Game.Scripts
{
    public class Spear : MonoBehaviour
    {
        [SerializeField] private FixedJoint[] _joints;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _wall;
        [SerializeField] private float _threshold;


        private bool _connected;

        private void Update()
        {
            var distance = Mathf.Abs(transform.position.z - _wall.position.z);
            
            if (distance >= _threshold)
            {
                // transform.Translate(transform.forward * _speed * Time.deltaTime);
                print(distance);
            }
            else
            {
                _speed = 0;
            }
        }

        private void OnEnable()
        {
            for (var i = 0; i < _joints.Length; i++)
            {
                _joints[i].GetComponent<JointCollision>().Collided += ConnectBone;
            }
        }

        private void OnDisable()
        {
            for (var i = 0; i < _joints.Length; i++)
            {
                _joints[i].GetComponent<JointCollision>().Collided -= ConnectBone;
            }
        }

        private void ConnectBone(Collider other, FixedJoint joint)
        {
            joint.connectedBody = other.attachedRigidbody;
        }
    }
}