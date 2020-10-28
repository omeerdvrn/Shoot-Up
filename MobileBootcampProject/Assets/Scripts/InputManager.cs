using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class InputManager : MonoBehaviour
{
    #region Singleton
    private static InputManager _instance;
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
    public static InputManager GetInstance()
    {
        return _instance;
    }
    #endregion
    
    #region Variables
    
    private bool _shouldPredict;
    private Vector3 _startPos;
    private Vector3 _currentPos;

    #endregion
    
    private void Update()
    {
        Predicter.GetInstance().DrawRaycast();
        if (Input.GetMouseButton(0))
        {
            Debug.Log("aklsdjklf");
            FillBar.GetInstance().mustMove = true;
            FillBar.GetInstance().FillBarPingPong();
            Predicter.GetInstance()._lineRenderer.SetPosition(1, Predicter.GetInstance().hit.point);
        }
        else
        {
            Debug.Log("");
        }

        if (Input.GetMouseButtonUp(0))
        {
            FillBar.GetInstance().mustMove = false;
            Shooter.GetInstance().ThrowBall(Predicter.GetInstance().hit);
            StartCoroutine(Shooter.GetInstance().CameraShake(0.5f, 1f));
        }
        else
        {
            Debug.Log("");
        }


        if (Input.touchCount <= 0) return;
        foreach (var touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    OnTouchBegan(touch);
                    break;
                case TouchPhase.Moved:
                    OnTouchMoved(touch);
                    break;
                case TouchPhase.Stationary:
                    OnTouchStationary(touch);
                    break;
                case TouchPhase.Ended:
                    OnTouchEnded();
                    break;
                case TouchPhase.Canceled:
                    OnTouchCancelled();
                    break;
                default:
                    Debug.Log("Default!!");
                    break;
            }
        }
    }
    
    #region Private Methods
    
    private void OnTouchBegan(Touch touch)
    {
        Predicter.GetInstance().hitPoint.SetActive(true);
        Predicter.GetInstance()._predicterObject.transform.localRotation = Quaternion.identity;
        Predicter.GetInstance()._lineRenderer.enabled = true;
        Predicter.GetInstance()._lineRenderer.SetPosition(1,Predicter.GetInstance().hit.point);
        FillBar.GetInstance().mustMove = true;
        _startPos = touch.position;
    }

    private void OnTouchMoved(Touch touch)
    {
        FillBar.GetInstance().FillBarPingPong();
        _currentPos = touch.position;
        Predicter.GetInstance()._lineRenderer.SetPosition(1,Predicter.GetInstance().hit.point);
        Predicter.GetInstance().CalculateXAxisMovement(_startPos,_currentPos);
        Predicter.GetInstance().CalculateYAxisMovement(_startPos,_currentPos);
    }

    private void OnTouchStationary(Touch touch)
    {
        _currentPos = touch.position;
        FillBar.GetInstance().FillBarPingPong();
        Predicter.GetInstance()._lineRenderer.SetPosition(1,Predicter.GetInstance().hit.point);
        // Predicter.GetInstance().CalculateXAxisMovement(_startPos,_currentPos);
        // Predicter.GetInstance().CalculateYAxisMovement(_startPos,_currentPos);
    }

    private void OnTouchEnded()
    {
        Predicter.GetInstance().hitPoint.SetActive(false);
        FillBar.GetInstance().mustMove = false;
        Predicter.GetInstance()._lineRenderer.enabled = false;
        _startPos = Vector3.zero;
        _currentPos = Vector3.zero;
        Shooter.GetInstance().ThrowBall(Predicter.GetInstance().hit);
        StartCoroutine(Shooter.GetInstance().CameraShake(0.5f, 1f));
    }

    private void OnTouchCancelled()
    {
        FillBar.GetInstance().mustMove = false;
        Predicter.GetInstance()._lineRenderer.enabled = false;
        _startPos = Vector3.zero;
        _currentPos = Vector3.zero;
        Shooter.GetInstance().ThrowBall(Predicter.GetInstance().hit);
    }
    
    #endregion
    
}
