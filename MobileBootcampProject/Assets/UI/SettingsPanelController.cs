using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;

public class SettingsPanelController : GenericUIPanelController
{
    public override void ClosePanel()
    {
        UIManager.Instance().ClosePanel(UIPanelTypes.settingsPanel);
    }

    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);

    }
    public void backButton()
    {
        ClosePanel();
    }

   
}
