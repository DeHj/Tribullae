using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace SegmentGeneration
{
    [RequireComponent(typeof(EdgeCollider2D))]
    public class SegmentGenerator : MonoBehaviour
    {
        public float length = 100;

        public Wave[] spectrum;

        public float step;

        //public uint seed = (uint)new System.Random().Next();

        public void Generate()
        {
            var segment = GenerateSegment();
            GetComponent<EdgeCollider2D>()
                .points = segment
                .Select(point => new Vector2(point.x, point.y))
                .ToArray();
        }

        private Point[] GenerateSegment()
        {
            //var r = new Random(seed);
            var waveFunc = new Func<float, float>(x =>
            {
                return spectrum.Sum(t => math.sin(x * 2 * math.PI / t.period) * t.amplitude);
            });

            var segmentPoints = new List<Point>((int)(length * step));
            for (float x = 0; x < length; x += step)
            {
                segmentPoints.Add(new Point(x, waveFunc(x)));
            }

            return segmentPoints.ToArray();
        }
    }
}
