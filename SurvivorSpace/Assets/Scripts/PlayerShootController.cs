using Cinemachine;
using StarterAssets;
using UnityEngine;

public class PlayerShootController : MonoBehaviour {
    public GameObject CameraMain;
    public GameObject CameraAim;
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    
    private StarterAssetsInputs _input;

    private void Start() {
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update() {
        CinemachineVirtualCamera.Follow = _input.aim ? CameraAim.transform : CameraMain.transform;
        CinemachineVirtualCamera.LookAt = _input.aim ? CameraAim.transform : CameraMain.transform;
    }
}
