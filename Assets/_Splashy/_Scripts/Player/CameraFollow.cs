using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform playerTransform; 
        public float followSpeed = 5f; 
        public float xOffset = 2f; 

        private void FixedUpdate()
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x + xOffset, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
    }
}
