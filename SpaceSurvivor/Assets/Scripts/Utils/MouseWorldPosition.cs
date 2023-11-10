using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SurvivorSpace.Utils {
    
    public class MouseWorldPosition : MonoBehaviour {

        public LayerMask PlacementLayer;
        
        private Camera _mainCamera;
        private Vector3 _lastPosition;

        public Vector3 LastPosition => _lastPosition;
        public Vector3 CurrentPosition => GetMousePosition();
        public Vector3 CurrentPositionWithoutLayer => GetMousePositionWithoutLayer();
        
        private void Awake() {
            _mainCamera = Camera.main;
        }

        private Vector3 GetMousePosition() {
            var ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit,999f, PlacementLayer)) {
                _lastPosition = hit.point;
                Debug.Log("position: " + _lastPosition);
            }

            return _lastPosition;
        }
        
        private Vector3 GetMousePositionWithoutLayer() {
            var worldPoint = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            worldPoint.z = 0f;
            Debug.Log("position: " + worldPoint);
            return worldPoint;
        }
    }
}