using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splashy
{
    /*
     * This class take care of the bounce effect of the player & trigger the bounce & win event of ScoreManager
     */
    public class BallBounce : MonoBehaviour
    {
        public float jumpForce = 10f; 
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bouncy"))
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.velocity = new Vector2(rb.velocity.y, jumpForce);
                ScoreManager.Instance.OnBounceEvent();
                collision.transform.parent.GetComponent<PlatformManager>().PlayHitAnim();
            }

            if (collision.gameObject.CompareTag("Win"))
            {
                ScoreManager.Instance.OnWinEvent();
            }
        }
    }
}
