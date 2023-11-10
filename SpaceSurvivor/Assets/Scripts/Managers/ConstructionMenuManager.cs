using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

namespace SurvivorSpace.Managers {

    public class ConstructionMenuManager : MonoBehaviour {

        [Header("Menu objects")]
        public GameObject ConstructionPanel;

        private bool _isMenuOpen;
        
        private void Awake() {
            StarterAssetsInputs.ConstructionUIMenuEvent += OpenConstructionMenu;
        }

        private void OnDestroy() {
            StarterAssetsInputs.ConstructionUIMenuEvent -= OpenConstructionMenu;
        }


        private void OpenConstructionMenu() {
            if (_isMenuOpen) {
                ConstructionPanel.SetActive(false);
                _isMenuOpen = false;
            }
            else {
                _isMenuOpen = true;
                ConstructionPanel.SetActive(true);
            }
        }
    }
}