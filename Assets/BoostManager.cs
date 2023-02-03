using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


namespace Behaviors{

    [System.Serializable]
    public struct BoostAugment {
        [SerializeField] public Sprite _SpriteAugment;
        [SerializeField] public string _NameAugment;
        [SerializeField] public int _IndexAugment;
    }

    public class BoostManager : MonoBehaviour
    {
        public List<Image> BoostSlot;
        public List<BoostAugment> ActiveBoosts;
        public List<BoostAugment> allBoost;
        public Sprite BaseSprite;
        private int currentIndex=0;
        // Start is called before the first frame update
        void Start()
        {
            GameManager.OnRestart -= Restart;
            GameManager.OnRestart += Restart;
            ResetBoostSlot();
        }

        void Restart(){
            ResetBoostSlot();
            currentIndex = 0;
        }

        public bool AddBoostToPlayer(int index){
            if(currentIndex < BoostSlot.Count ){
                ActiveBoosts.Add(allBoost[index]);
                BoostSlot[currentIndex].sprite = allBoost[index]._SpriteAugment;
                switch (index){
                    case 0:
                        GetComponent<PlayerActionsBehaviour>().moveSpeed *=1.5f;
                        break;
                    case 1:
                        GetComponent<PlayerActionsBehaviour>()._lightComponent.range *= 2;
                        break;
                    case 2:
                        GetComponent<HealthSystem>().DelayDamage *=1.5f;
                        break;
                }
                currentIndex++;
                return true;
            }
            
            return false;
        }


        public void ResetBoostSlot(){
            foreach (var boost in BoostSlot)
            {
                boost.sprite = BaseSprite;
            }
        }
    }
}

