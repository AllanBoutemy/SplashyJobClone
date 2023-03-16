using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Splashy
{
    public class PlatformGenerator : MonoBehaviour
    {
        public GameObject platformPrefab,winplatformPrefab;
        private float lastPlatformZ;
        
        [SerializeField]
        private float initialSpeed = 5f;
        [SerializeField]
        private float acceleration = 0.7f;
        [SerializeField]
        private float totalPlatform = 50;
        [SerializeField]
        private float speed;

        [SerializeField]
        private List<PlatformManager> allPlatformManagers = new List<PlatformManager>();
      
        
        private void Start()
        {  
            speed = initialSpeed;

            GameObject firstPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity); firstPlatform.transform.SetParent(transform);
            lastPlatformZ = firstPlatform.transform.position.z;
            
            for (int i = 0; i < totalPlatform; i++)
            {
                GeneratePlatform();
            }

            GeneratePlatform(true);
            
            SetItems();
        }



        //Move & accelerate the platform parent 
        private void Update()
        {
            speed += acceleration * Time.deltaTime;
            Vector3 position = transform.position;
            position.z -= speed * Time.deltaTime;
            transform.position = position;
        }
        

        /*
         * Generate platforms randomly on x & z axs, store platforms on list for items generation
         * Take a bool param for spwan the win prefab or not
         */
        void GeneratePlatform(bool win = false)
        {

            Vector3 newPosition = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y,lastPlatformZ + Random.Range(2.1f, 3f));
           
            GameObject newPlatform = Instantiate(!win ? platformPrefab : winplatformPrefab, newPosition, Quaternion.identity);
            
            PlatformManager platformManager = newPlatform.GetComponent<PlatformManager>();
            allPlatformManagers.Add(platformManager);
            
            newPlatform.transform.SetParent(transform);
          
            lastPlatformZ = newPlatform.transform.position.z;
        }
        
        /*
        * Randomly display items on platforms ( 2% spikes,5% bonus, 2% gems)
        * TODO Fix activations & refact for better optimisation
        */
        private void SetItems()
        {
            float spikeAmount = Mathf.CeilToInt((2f * totalPlatform) / 100);
            float bonusAmount = Mathf.CeilToInt((5f * totalPlatform)/ 100);
            float gemAmount = Mathf.CeilToInt((2f * totalPlatform)/ 100);
            
            
            if (spikeAmount < 1) spikeAmount = 1;
            if (bonusAmount < 1) bonusAmount = 1;
            if (gemAmount < 1) gemAmount = 1;
            
            allPlatformManagers.Shuffle();
            for (int i = 0; i < spikeAmount; i++)
            {
                allPlatformManagers[i].SetSpike();
            }
            
            allPlatformManagers.Shuffle();
            var listForBonus = allPlatformManagers.Where(p => !p.hasBonus).ToList();
            for (int i = 0; i < bonusAmount; i++)
            {
                listForBonus[i].ActivateBonus();
            }
            
            allPlatformManagers.Shuffle();
            var listForGem = allPlatformManagers.Where(p => !p.hasBonus).ToList();
            for (int i = 0; i < gemAmount; i++)
            {
                listForGem[i].ActivateGem();
            }
        }
    }
}
