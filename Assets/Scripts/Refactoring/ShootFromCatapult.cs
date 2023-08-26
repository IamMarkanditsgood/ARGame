using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromCatapult : MonoBehaviour, IShoot
{
    private CatapultData _catapultData;
    private Vector3 diractionOfProjectile;
    private bool _isCharged = true;
    private Coroutine _timerCoroutine;

    private void Start()
    {
        _catapultData = GetComponent<CatapultData>();
    }
    private void OnDestroy()
    {
        StopCoroutine(_timerCoroutine); 
    }

    public void ShootFromGun(LevelData levelData, GameObject catapult)
    {
        if (_isCharged)
        {
            _catapultData.BeamRigidBody.AddForce(_catapultData.BeamRigidBody.transform.up * 5, ForceMode.Impulse);

            diractionOfProjectile = -transform.forward * levelData.ForceForCatapult + transform.up * 2;

            GameObject obj = Instantiate(levelData.CatapultProjectile, _catapultData.StartPosition.position, _catapultData.StartPosition.rotation);
            obj.GetComponent<Rigidbody>().AddForce(diractionOfProjectile, ForceMode.Impulse);
            _isCharged = false;
            _catapultData.ProjectileInCatapult.SetActive(false);

            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }
    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(_catapultData.TimeToRecharge);
        RechargeCatapult();
    }
    private void RechargeCatapult()
    {
        _isCharged = true;
        _catapultData.ProjectileInCatapult.SetActive(true);
    }
}
