using UnityEngine;
using UnityEngine.Serialization;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets {
	public class StarterAssetsInputs : MonoBehaviour {
		
		public delegate void AimHandler(bool isAiming);
		public static event AimHandler AimEvent;
		
		public delegate void FireHandler(bool isFiring);
		public static event FireHandler FireEvent;
		
		public delegate void ConstructionUIMenuHandler();
		public static event ConstructionUIMenuHandler ConstructionUIMenuEvent;
		
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool Jump;
		public bool Sprint;
		public bool Aim;
		public bool Fire;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value) {
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value) {
			if(cursorInputForLook) {
				LookInput(value.Get<Vector2>());
			}
		}
		
		public void OnJump(InputValue value) {
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value) {
			SprintInput(value.isPressed);
		}
		
		public void OnAim(InputValue value) {
			AimInput(value.isPressed);
			AimEvent?.Invoke(value.isPressed);
		}
		
		public void OnFire(InputValue value) {
			FireInput(value.isPressed);
			FireEvent?.Invoke(value.isPressed);
		}
		
		public void OnOpenConstructionMenu(InputValue value) {
			ConstructionUIMenuEvent?.Invoke();
		}
#endif


		public void MoveInput(Vector2 newMoveDirection) {
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection) {
			look = newLookDirection;
		}
		
		public void JumpInput(bool newJumpState) {
			Jump = newJumpState;
		}

		public void SprintInput(bool newSprintState) {
			Sprint = newSprintState;
		}
		
		public void AimInput(bool newAimState) {
			Aim = newAimState;
		}
		
		public void FireInput(bool newFireState) {
			Fire = newFireState;
		}

		private void OnApplicationFocus(bool hasFocus) {
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState) {
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}