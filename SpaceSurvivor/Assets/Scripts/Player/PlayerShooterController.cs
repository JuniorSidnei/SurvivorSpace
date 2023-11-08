using System;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour {

    public LayerMask AimLayerCollider;
    public Transform SpawnTransform;
    public GameObject BulletPf;
    public float FireCooldown;
    public CinemachineVirtualCamera CinemachineVirtualCamera;

    private bool _isAiming;
    private Camera _camera;
    private Vector3 _mouseWorldPosition;
    private float _fireCooldownTimer;
    private bool _isFiring;
    
    private void Awake() {
        _camera = Camera.main;
        StarterAssetsInputs.AimEvent += Aim;
        StarterAssetsInputs.FireEvent += Fire;
    }
    
    private void OnDestroy() {
        StarterAssetsInputs.AimEvent -= Aim;
        StarterAssetsInputs.FireEvent -= Fire;
    }

    private void Fire(bool isFiring) {
        _isFiring = isFiring;
    }
    
    private void Aim(bool isAiming) {
        _isAiming = isAiming;
    }

    private void Start() {
        _fireCooldownTimer = 0;
    }

    private void Update() {
        _fireCooldownTimer -= Time.deltaTime;

        CinemachineVirtualCamera.gameObject.SetActive(_isAiming);

        _mouseWorldPosition = Vector3.zero;

        var screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        var ray = _camera.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        
        if (Physics.Raycast(ray, out var hit, 999f, AimLayerCollider)) {
            _mouseWorldPosition = hit.point;
            hitTransform = hit.transform;
        }
        
        if(!_isAiming) return;

        var worldAimTarget = _mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        var aimDirection = (worldAimTarget - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        
        if (_fireCooldownTimer <= 0 && _isFiring) {
            _fireCooldownTimer = FireCooldown;

            if (hitTransform) {
                Debug.Log("quem? " + hitTransform.name);
            }
        }
    }
}
