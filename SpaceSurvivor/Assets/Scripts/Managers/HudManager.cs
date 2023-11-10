using StarterAssets;
using UnityEngine;

namespace SurvivorSpace.Managers {


    public class HudManager : MonoBehaviour {

        public GameObject PlayerCrossHair;

        private void Awake() {
            StarterAssetsInputs.AimEvent += Aim;
        }
        

        private void OnDestroy() {
            StarterAssetsInputs.AimEvent -= Aim;
            
        }
        
        private void Aim(bool isAiming) {
            PlayerCrossHair.SetActive(isAiming);
        }
        
    }
}