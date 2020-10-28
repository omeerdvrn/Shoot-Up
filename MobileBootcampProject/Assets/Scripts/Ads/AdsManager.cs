#define TEST
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    #if UNITY_IOS
    private string _gameId = "1234567";
    #elif UNITY_ANDROID
    private string _gameId = "1234567";
    #else
    private string _gameId = "1234567";
    #endif

    #if TEST
    private bool isTest = true;
    #else
    private bool isTest = true;
    #endif


    private void Start()
    {
        Advertisement.Initialize(_gameId, true);

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            ShowInterstitialAd();
        }
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Havuz Boş");
        }
    }




}
