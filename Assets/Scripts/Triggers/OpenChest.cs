using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Behaviors
{

    public class OpenChest : MonoBehaviour
    {
        public Canvas SpaceBar;
        public bool IsOpen;
        public int BoostIndex;
        [SerializeField] private List<Sprite> state;
        private List<BoostAugment> _AllBoosts;
        [SerializeField] private BoostManager _BoostManager;
        
        void Start()
        {   
            GameManager.OnRestart -= Restart;
            GameManager.OnRestart += Restart;
            SpaceBar.enabled = false;
            if (_BoostManager != null) {
                _AllBoosts = _BoostManager.allBoost;
                BoostIndex = _AllBoosts[Random.Range(0,_AllBoosts.Count)]._IndexAugment;
            }
            
            GetComponent<SpriteRenderer>().sprite = state[0];
        }

        // Update is called once per frame
        void Restart()
        {
            IsOpen = false;
            SpaceBar.enabled = false;
            BoostIndex = _AllBoosts[Random.Range(0,_AllBoosts.Count)]._IndexAugment;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = state[0];
        }

        public void OnEnter(){
            SpaceBar.enabled = true;
        }

        public void OnExit(){
            SpaceBar.enabled = false;
        }
        public void Opening(){
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = state[1];
            OnExit();
            IsOpen = true;
        }
    }
}