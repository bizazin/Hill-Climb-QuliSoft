using Core.Abstracts;
using UnityEngine;

namespace Behaviours
{
    public class VehicleBehaviour : View
    {
        [SerializeField] private Rigidbody2D frontTireRb;
        [SerializeField] private Rigidbody2D backTireRb;
        [SerializeField] private Rigidbody2D vehicleRb;

        private float _speed;
        private float _rotationSpeed;
        private float _moveInput;

        public void SetupVehicle(float speed, float rotationSpeed)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
        }
        
        public void Move(bool forward) => _moveInput = forward ? 1 : -1;

        public void StopMoving() => _moveInput = 0;

        public void SetPosition(Vector3 position) => transform.position = position;

        private void FixedUpdate()
        {
            frontTireRb.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
            backTireRb.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
            vehicleRb.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
        }
    }
}