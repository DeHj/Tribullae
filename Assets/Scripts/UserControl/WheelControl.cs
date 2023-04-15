using Unity.Mathematics;
using UnityEngine;

namespace UserControl
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WheelControl : MonoBehaviour
    {
        //public float maxSpeed;
        public float acceleration;

        public string axis;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var input = Input.GetAxis(axis);
            if (math.abs(input) > math.EPSILON)
                //&& math.abs(_rigidbody2D.angularVelocity) < maxSpeed)
            {
                _rigidbody2D.angularVelocity -= acceleration * input;
            }
        }
    }
}