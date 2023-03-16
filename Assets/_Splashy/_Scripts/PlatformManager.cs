
using UnityEngine;

namespace Splashy
{
    public class PlatformManager : MonoBehaviour
    {

        public GameObject bonus,spike,gem,platform;
        public bool hasBonus;
        [SerializeField]
        private Animator animator;
        private static readonly int Hit = Animator.StringToHash("Hit");

        public void PlayHitAnim()
        {
            animator.SetTrigger(Hit);
        }
        public void SetSpike()
        {
            hasBonus = true;
            spike.SetActive(true);
            //TODO place spike randomly on the platform
        }
        public void ActivateBonus()
        {
            bonus.SetActive(true);
        }
        public void ActivateGem()
        {
            gem.SetActive(true);
            hasBonus = true;
        }
    }
}
