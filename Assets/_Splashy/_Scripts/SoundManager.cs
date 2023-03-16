using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Splashy
{
    public class SoundManager : MonoBehaviour
    {
        
        [Header("AudioSource references")]
        public AudioSource fxSource;
        public AudioSource uiSource;
        
        
        [Tooltip("List of clip to use if we want bounce variations")]
        public AudioClip[] randomBounceClips;
        
        public AudioClip gemCollectClip;
        public AudioClip bonusClip;
        public AudioClip bounceClip;
        public AudioClip looseClip;
        public AudioClip winClip;
        private AudioClip _lastBounceClip;


        private void Start()
        {
            ScoreManager.Instance.BounceEvent += PlayBounceClip;
            ScoreManager.Instance.GemEvent += PlayGemCollect;
            ScoreManager.Instance.BonusEvent += PlayBonus;
            ScoreManager.Instance.LoseEvent += PlayLoseClip;
            ScoreManager.Instance.WinEvent += PlayWinClip;
        }

        public void OnDisable()
        {
            ScoreManager.Instance.BounceEvent -= PlayBounceClip;
            ScoreManager.Instance.GemEvent -= PlayGemCollect;
            ScoreManager.Instance.BonusEvent -= PlayBonus;
            ScoreManager.Instance.LoseEvent -= PlayLoseClip;
            ScoreManager.Instance.WinEvent -= PlayWinClip;
        }
        
        
        public void PlayRandomBounce()
        {
            PlayASound(RandomBounce(), fxSource, false);
        }
        public void PlayBounceClip()
        {
            if(!fxSource.isPlaying)
             PlayASound(bounceClip,fxSource);
        }

        public void PlayLoseClip()
        {
            if(fxSource.isPlaying)fxSource.Stop();
                PlayASound(looseClip,fxSource);
        } 
        
        public void PlayWinClip()
        {
            if(fxSource.isPlaying)fxSource.Stop();
                PlayASound(winClip,fxSource);
        }

        public void PlayGemCollect()
        {
            PlayASound(gemCollectClip,uiSource);
        }
        public void PlayBonus()
        {
            PlayASound(bonusClip,uiSource);
        }
        private static void PlayASound(AudioClip clip, AudioSource source, bool isLoop = false)
        {
            if (source == null) return;
            source.clip = clip;
        
            if (isLoop)
            {
                source.loop = true;
                source.Play();
            }else
                source.PlayOneShot(clip);
        }
        
        AudioClip RandomBounce()
        {
            int attempts = 5;
            AudioClip newClip = randomBounceClips[Random.Range(0, randomBounceClips.Length)];

            while (newClip == _lastBounceClip && attempts > 0) 
            {
                newClip = randomBounceClips[Random.Range(0, randomBounceClips.Length)];
                attempts--;
            }

            _lastBounceClip = newClip;
            return newClip;
        }

    }
}
