using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystems
{
    public class MainMenuPanelController : GenericUIPanelController
    {


        [SerializeField]
        private Button _startGameButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _creditsButton;
       


        private void Start()
        {
            _startGameButton.onClick.AddListener(StartButtonFunction);
            _settingsButton.onClick.AddListener(SettingsButtonFunction);
            _creditsButton.onClick.AddListener(CreditsButtonFunction);

            UIManager.Instance().currentUIPanelController = this;
        }


        #region Button Functions
        private void StartButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.gamePanel, true);
        }

        public void SettingsButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.settingsPanel, true);

        }

        private void CreditsButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.creditsPanel, true);

        }
        #endregion

        public override void ClosePanel()
        {
            this.gameObject.SetActive(false);
        }

        public override void OpenPanel()
        {
            this.gameObject.SetActive(true);
        }
    }
}

