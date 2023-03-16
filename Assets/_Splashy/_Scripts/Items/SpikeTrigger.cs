using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
    public class SpikeTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            ScoreManager.Instance.OnLoseEvent();  Debug.Log("Wow desactivate spike ");
            // gameObject.SetActive(false);
        }
    }
}
