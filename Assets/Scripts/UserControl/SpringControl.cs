using Configuration;
using Unity.Mathematics;
using UnityEngine;

namespace UserControl
{
    [RequireComponent(typeof(SpringJoint2D))]
    public class SpringControl : MonoBehaviour
    {
        public SpringConfiguration springLeft;
        public SpringConfiguration springRight;
        public SpringConfiguration springDown;

        public string axis;

        private SpringJoint2D _springLeft;
        private SpringJoint2D _springRight;
        private SpringJoint2D _springDown;

        private void Start()
        {
            /*_spring = GetComponent<SpringJoint2D>();
            _spring.dampingRatio = dampingRatio;
            _spring.frequency = frequency;
            _spring.autoConfigureDistance = false;
            _spring.distance = attackLength;*/
        }

        private void Update()
        {
            var input = Input.GetAxis(axis);
        }
    }
}