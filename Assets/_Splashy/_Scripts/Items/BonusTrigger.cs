using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
    public class BonusTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            
            if (!other.CompareTag("Player")) return;
            Debug.Log("Wow desactivate bonus ");
            ScoreManager.Instance.OnBonusEvent();
            // gameObject.SetActive(false);
        }
    }
}
