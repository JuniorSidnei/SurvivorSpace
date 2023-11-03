using StarterAssets;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    public StarterAssetsInputs StarterAssetsInputs;
    public FirstPersonController FirstPersonController;
    
    private Animator _animator;
    private static readonly int VelocityHorizontal = Animator.StringToHash("velocity_horizontal");
    private static readonly int VelocityVertical = Animator.StringToHash("velocity_vertical");
    private static readonly int IsRunning = Animator.StringToHash("is_running");
    private static readonly int IsGround = Animator.StringToHash("is_ground");

    private bool _isFalling;
    
    private void Awake() {
        FirstPersonController.JumpEvent += AnimateJump;
        FirstPersonController.FallEvent += AnimateFall;
    }

    private void OnDestroy() {
        FirstPersonController.JumpEvent -= AnimateJump;
        FirstPersonController.FallEvent -= AnimateFall;
    }
    
    private void AnimateFall() {
        if(_isFalling) return;

        _isFalling = true;
        _animator.CrossFade("Jump_Air", 0.1f);
    }

    private void AnimateJump() {
        _isFalling = false;
        _animator.CrossFade("Jump_Start", 0.1f);
    }

    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        _animator.SetFloat(VelocityHorizontal, Mathf.Abs(StarterAssetsInputs.move.y));
        _animator.SetBool(IsRunning, StarterAssetsInputs.sprint);
        _animator.SetBool(IsGround, FirstPersonController.Grounded);
        _animator.SetFloat(VelocityVertical, FirstPersonController.PlayerVelocity.y);

        if (FirstPersonController.PlayerVelocity.y <= 0.0f && FirstPersonController.Grounded) {
            _isFalling = false;
        }
    }
}
