using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
    public class LoseDetection : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ScoreManager.Instance.OnLoseEvent();
            }
        }
    }
}
