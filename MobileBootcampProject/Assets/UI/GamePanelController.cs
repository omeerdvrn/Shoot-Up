using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystems;

public class GamePanelController : GenericUIPanelController
   
{
    bool gamesettingcheck = true;
    public override void ClosePanel()
    {
        UIManager.Instance().ClosePanel(UIPanelTypes.gameSettingsPanel);
    }

    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);

    }
    public void settingsButtonFunc()
    {
        if (gamesettingcheck)
        {
            UIManager.Instance().OpenPanel(UIPanelTypes.gameSettingsPanel, true);
            gamesettingcheck = false;
        }
        else
        {
            ClosePanel();
            gamesettingcheck = true;
        }
    }
}
