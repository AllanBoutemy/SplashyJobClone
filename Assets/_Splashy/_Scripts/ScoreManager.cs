using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Splashy
{
    public class ScoreManager : MonoBehaviour
    {

        public static ScoreManager Instance;
        [SerializeField] 
        private TextMeshProUGUI bouncesCount;
        [SerializeField] 
        private TextMeshProUGUI gemsCount;

        private int bounceCount, gemCount, bonusFactor;

        public delegate void EventVoid();

        public event EventVoid BounceEvent;
        public event EventVoid GemEvent;
        public event EventVoid BonusEvent;
        public event EventVoid LoseEvent;
        public event EventVoid WinEvent;
        private void Awake()
        {
            if(Instance!=null) Destroy(Instance);
            Instance = this;

            bonusFactor = 1;
        }

        public virtual void OnBounceEvent()
        {
            BounceEvent?.Invoke();
            UpdateBounceCount();
        }

        public virtual void OnLoseEvent()
        {
            GameManager.Instance.Lose();
            LoseEvent?.Invoke();
        } 
        
        public virtual void OnWinEvent()
        {
            GameManager.Instance.Win();
            WinEvent?.Invoke();
        }

        public virtual void OnGemEvent()
        {
            GemEvent?.Invoke();
            UpdateGemCount();
        }

        public virtual void OnBonusEvent()
        {
            BonusEvent?.Invoke();
            bonusFactor += 1;
        }

        private void UpdateBounceCount()
        {
            bounceCount += bonusFactor;
            bouncesCount.text = bounceCount.ToString();
        }

        private void UpdateGemCount()
        {
            gemCount ++;
            gemsCount.text = gemCount.ToString();
        }
        
    }
}
