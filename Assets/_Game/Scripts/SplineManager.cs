using Dreamteck.Splines;
using UnityEngine;

namespace _Game.Scripts
{
    public class SplineManager : MonoBehaviour
    {
        [SerializeField] private SplineComputer _splineComputer;
        [SerializeField] private SplineFollower _splineFollower;

        private SplinePoint _middlePoint;
        private bool _isFollowing;

        private void Start()
        {
            _middlePoint = _splineComputer.GetPoint(1);
        }

        private void Update()
        {
            transform.Translate(Input.GetAxisRaw("Horizontal") * transform.right * 3 * Time.deltaTime);

            if (_isFollowing)
                return;

            _splineComputer.SetPointPosition(0, transform.position);
            _splineComputer.SetPointPosition(1, new Vector3(transform.position.x, 0, _middlePoint.position.z));

            if (Input.GetMouseButtonDown(0))
            {
                _splineFollower.enabled = true;
                _isFollowing = true;
            }
        }
    }
}