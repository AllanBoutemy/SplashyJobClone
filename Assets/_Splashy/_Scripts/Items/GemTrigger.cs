using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
    public class GemTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            ScoreManager.Instance.OnGemEvent();  Debug.Log("Wow desactivate gem ");
            // gameObject.SetActive(false);
        }
    }
}
