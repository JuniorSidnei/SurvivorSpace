using UnityEngine;

public class BulletProjectile : MonoBehaviour {
    
    public float Speed;
    
    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        _rigidbody.velocity = transform.forward * Speed;
    }
}
