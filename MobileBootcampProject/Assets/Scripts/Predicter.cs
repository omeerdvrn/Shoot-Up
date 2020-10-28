using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predicter : MonoBehaviour
{
    #region Singleton
    private static Predicter _instance;

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

    public static Predicter GetInstance()
    {
        return _instance;
    }
    #endregion

    #region Variables
    
    public LineRenderer _lineRenderer;
    public RaycastHit hit; 
    public GameObject _predicterObject;
    [SerializeField] [Range(1, 30)] private float _rotationSpeedX;
    [SerializeField] [Range(1, 30)] private float _rotationSpeedY;
    public GameObject hitPoint;

    #endregion
    private void Start()
    {
        hitPoint.SetActive(false);
        _lineRenderer.SetPosition(0,_predicterObject.transform.position);
    }

    #region Public Methods

    public void CalculateXAxisMovement(Vector3 initial, Vector3 last)
    {
        if ((_predicterObject.transform.localRotation.x < 0) && (_predicterObject.transform.localRotation.x > -50))
        {
            if ((initial.x > last.x)&&((initial.x-last.x)>10))
            {
                _predicterObject.transform.Rotate(Vector3.up, _rotationSpeedX * Time.deltaTime);
            }
            else if ((initial.x < last.x)&&((last.x-initial.x)>10))
            {
                _predicterObject.transform.Rotate(Vector3.down, _rotationSpeedX * Time.deltaTime);
            }
        }
        else
        {
            return;
            //_predicterObject.transform.localRotation = Quaternion.identity;
        }
        
    }
    
    public void CalculateYAxisMovement(Vector3 initial, Vector3 last)
    {
        if ((_predicterObject.transform.localRotation.y < 30) && (_predicterObject.transform.localRotation.x > -30))
        {
            if ((initial.y > last.y)&&((initial.y-last.y)>10))
            {
                _predicterObject.transform.Rotate(Vector3.left, _rotationSpeedY * Time.deltaTime);
            }
            else if ((initial.y < last.y)&&((last.y-initial.y)>10))
            {
                _predicterObject.transform.Rotate(Vector3.right, _rotationSpeedY * Time.deltaTime);
            }
        }
        else
        {
            return;
            //_predicterObject.transform.localRotation = Quaternion.identity;
        }
        
    }

    public void DrawRaycast()
    {
        if (Physics.Raycast(_predicterObject.transform.position, _predicterObject.transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            Debug.DrawRay(_predicterObject.transform.position,_predicterObject.transform.TransformDirection(Vector3.forward)*hit.distance,Color.blue);
            hitPoint.transform.position = hit.point;
        }
        else
        {
            hitPoint.SetActive(false);
        }
    }

    #endregion

    
    
}