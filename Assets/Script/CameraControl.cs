using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CameraControl : MonoBehaviour
    {
        public float c_Speed = 10;
        private Vector3 c_Move;

        private void Start()
        {
        }


        void Update()
        {
            float x = 0;
            float z = 0;

            if (Input.GetKey(KeyCode.D))
            {
                x += c_Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                x -= c_Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                z += c_Speed * Time.deltaTime;

            }
            if (Input.GetKey(KeyCode.S))
            {
                z -= c_Speed * Time.deltaTime;
            }

            transform.position += new Vector3(x, 0, z);
        }
    }
}
