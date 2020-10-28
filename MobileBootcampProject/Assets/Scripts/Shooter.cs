using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shooter : MonoBehaviour
{
    #region Singleton

    private static Shooter _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public static Shooter GetInstance()
    {
        return _instance;
    }

    #endregion
    
    #region Variables
    
    public GameObject _objPrefab;
    [SerializeField] private GameObject _camera;
    private Vector3 _originalCameraPosition;
    [SerializeField] private Transform _shootPoint;

    #endregion

    #region Public Methods

    public void ThrowBall(RaycastHit _hit)
    {
        Vector3 pos = _hit.point;
        GameObject ball = Instantiate(_objPrefab,_shootPoint.position,Quaternion.identity);//Instantiated our real ball.
        ball.tag = "ball";//Set tag to ball.
        ball.GetComponent<Rigidbody>().AddForce((pos - Predicter.GetInstance()._predicterObject.transform.position)*FillBar.GetInstance().CalculateShootingForce(FillBar.GetInstance()._fillBar, FillBar.GetInstance()._magnitude));
    }

    public IEnumerator CameraShake(float magnitude, float duration)
    {

        _originalCameraPosition = _camera.transform.position;
        _camera.transform.DOShakePosition(duration, magnitude, 10, 90f);
        yield return new WaitForSeconds(duration);
        _camera.transform.position = _originalCameraPosition;
    }

    #endregion
    
}
