using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    #region Singleton
private static FillBar _instance;
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
public static FillBar GetInstance()
{
    return _instance;
}
#endregion,

    #region Variables
    
    public Image _fillBar;
    [Header("fillBar changes from minFillAmount to maxFillAmount")]
    [SerializeField]private float _minFillAmount = 0;
    [SerializeField] private float _maxFillAmount = 1;
    [Range(1,1000)] public float _magnitude;
    public bool mustMove;

    #endregion

    #region Public Methods

    public void FillBarPingPong()
    {
        if (mustMove)
        {
            _fillBar.fillAmount = Mathf.PingPong(_minFillAmount, _maxFillAmount); 
            _minFillAmount += Time.deltaTime;
        }
        else
        {
            return;
        }
    }
    public float CalculateShootingForce(Image image,float magnitude)
    {
        var a = image.fillAmount;
        return a * magnitude;
    }

    #endregion
    


}
