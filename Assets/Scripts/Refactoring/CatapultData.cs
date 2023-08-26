using UnityEngine;

public class CatapultData : MonoBehaviour
{
    [SerializeField] private GameObject _projectileInCatapult;

    [SerializeField] private Transform _startPosition;

    [SerializeField] private Rigidbody _beamRigidBody;

    [SerializeField] private float _timeToRecharge;

    public GameObject ProjectileInCatapult
    {
        get { return _projectileInCatapult; }
    }

    public Transform StartPosition
    { 
        get { return _startPosition; } 
    }

    public Rigidbody BeamRigidBody
    {
        get { return _beamRigidBody; }
    }

    public float TimeToRecharge
    { 
        get { return _timeToRecharge; } 
    }
}
