using SurvivorSpace.Utils;
using UnityEngine;

namespace SurvivorSpace.Placement {

    public class PlacementSystem : MonoBehaviour {

        public MouseWorldPosition MouseWorldPosition;
        public GameObject MousePositionVizualizerObj;
        
        
        private void Update() {
            MousePositionVizualizerObj.transform.position = MouseWorldPosition.CurrentPosition;
        }
    }
}