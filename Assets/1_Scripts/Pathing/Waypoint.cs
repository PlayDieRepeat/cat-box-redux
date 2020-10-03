﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD47.Pathing
{
    public class Waypoint : MonoBehaviour
    {
        [Header("Waypoint Rotation")]
        [SerializeField] float degreesPerSecond = 15.0f;
        [SerializeField] float amplitude = 0.5f;
        [SerializeField] float frequency = 1f;

        Vector3 posOffset = new Vector3();
        Vector3 tempPos = new Vector3();

        // Start is called before the first frame update
        void Awake()
        {
            posOffset = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Rotate();
            OscillateVertically();
        }
        
        void OscillateVertically()
        {
            tempPos = posOffset;
            tempPos.y += (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + amplitude;

            transform.position = tempPos;
        }

        void Rotate()
        {
            transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        }
    }
}