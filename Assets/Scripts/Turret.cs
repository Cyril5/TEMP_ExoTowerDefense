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
        // Rotation sur l'axe Y uniquement (horizontal)
        Vector3 directionToTarget = _target.position - _turretMount.position;

        // Ignorer l'axe vertical en annulant la composante Y
        directionToTarget.y = 0;

        Quaternion lookAtRotationY = Quaternion.LookRotation(directionToTarget.normalized);

        _turretMount.rotation = Quaternion.Slerp(
            _turretMount.rotation,
            lookAtRotationY,
            _rotationYSpeed * Time.deltaTime
        );

        // Rotation locale cible uniquement sur X
        Vector3 dir = _target.position - _turretHead.position;
        Quaternion targetRotationX = Quaternion.LookRotation(dir);

        // Appliquer une rotation progressive à _turretHead localement
        Quaternion rot = Quaternion.Slerp(
            _turretHead.localRotation,
            targetRotationX,
            _rotationXSpeed * Time.deltaTime
        );

        //Apply the local rotation 
        _turretHead.localRotation = rot;

        // put 0 on the axys you do not want for the rotation object to rotate
        _turretHead.localEulerAngles = new Vector3(_turretHead.localEulerAngles.x, 0, 0);

    }
}
