using System;
using UnityEngine;

namespace Configuration
{
    [Serializable]
    public class SpringConfiguration
    {
        public float maxLength;
        public float minLength;
        public float attackLength;

        public float frequency;
        public float dampingRatio;

        
    }
}