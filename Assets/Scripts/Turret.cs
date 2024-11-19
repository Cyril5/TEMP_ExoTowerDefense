using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _turretMount;
    [SerializeField] Transform _turretHead;
    [SerializeField] float _rotationYSpeed = 20f;
    [SerializeField] float _rotationXSpeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationYSpeed * Time.deltaTime);
        
    }
}
