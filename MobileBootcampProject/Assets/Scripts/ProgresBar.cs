using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text _scoretext;
    
    public float currentCheckPoint= 20;
    private void Start()
    {
        
        PrepareGame();
    }
    
    private void PrepareGame()
    {
    }
    
    private void Update()
    {
        CheckBox();
    }
    public void CheckBox()
    {
        int enableBoxs = 0;
        BoxCollider[] boxColliders = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider box in boxColliders)
        {
            if (box.enabled == true)
            {
                enableBoxs += 1;
            }
    
        }
        currentCheckPoint = enableBoxs;
        float progressValue = (float)currentCheckPoint / 20 * 100;
        _progressBar.value = progressValue;
        Debug.Log(progressValue);
        if (progressValue <= 30)
        {
            _progressBar.value = 0;
            _scoretext.text = "500";
            UIManager.Instance().OpenPanel(UIPanelTypes.scoreBoard);
        }
    }
   
    

}
