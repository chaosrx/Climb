/*******************************************************
 * 													   *
 * Asset:		 Advanced Shooter Kit        		   *
 * Script:		 MenuElements.cs                       *
 * 													   *
 * Copyright(c): Victor Klepikov					   *
 * Support: 	 http://bit.ly/vk-Support			   *
 * 													   *
 * mySite:       http://vkdemos.ucoz.org			   *
 * myAssets:     http://u3d.as/5Fb                     *
 * myTwitter:	 http://twitter.com/VictorKlepikov	   *
 * 													   *
 *******************************************************/


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SmartFirstPersonController
{
    public class MenuElements : MonoBehaviour
    {
        public Slider
            lookSens,
            masterVol, musicVol, SFXVol, voiceVol;

        public Toggle
            invLookX, invLookY;

        public enum EFirstPanel { Gameplay, Audio }
        public EFirstPanel firstPanel = EFirstPanel.Gameplay;

        public GameObject gameplayPanel, audioPanel;

        private static MenuElements instance = null;
        private GameObject playerBody = null;


        // SetActive
        public static void SetActive( bool value )
        {          
            if( value )
                SmartInputManager.UnblockCursor();            
            else
                SmartInputManager.BlockCursor();            

            instance.gameObject.SetActive( value );
        }

        // Awake
        internal void AwakeMENU( GameObject parent )
        {
            instance = this;
            playerBody = parent.GetComponentInChildren<Animation>().gameObject;
        }

        // Start
        void Start()
        {
            if( firstPanel == EFirstPanel.Audio )
                gameplayPanel.SetActive( false );
            else
                audioPanel.SetActive( false );
        }

        // OnEnable
        void OnEnable()
        {
            if( !Application.isPlaying )
                return;

            invLookX.isOn = GameSettings.InvertLookX;
            invLookY.isOn = GameSettings.InvertLookY;
            //
            lookSens.value = GameSettings.LookSensitivity;
            //
            masterVol.value = GameSettings.MasterVolume;
            musicVol.value = GameSettings.MusicVolume;
            SFXVol.value = GameSettings.SFXVolume;
            voiceVol.value = GameSettings.VoiceVolume;
        }

        // Set InvLookX IsOn
        public void SetInvLookXIsOn( bool value )
        {
            GameSettings.InvertLookX = value;
        }
        // Set InvLookY IsOn
        public void SetInvLookYIsOn( bool value )
        {
            GameSettings.InvertLookY = value;
        }

        // Set PlayerBody IsOn
        public void SetPBodyIsOn( bool value )
        {
            playerBody.SetActive( value );
        }


        // Set LookSens
        public void SetLookSens( float value )
        {
            GameSettings.LookSensitivity = value;
        }

        // Set MasterVolume
        public void SetMasterVolume( float value )
        {
            GameSettings.MasterVolume = value;
        }
        // Set MusicVolume
        public void SetMusicVolume( float value )
        {
            GameSettings.MusicVolume = value;
        }
        // Set SFXVolume
        public void SetSFXVolume( float value )
        {
            GameSettings.SFXVolume = value;
        }
        // Set VoiceVolume
        public void SetVoiceVolume( float value )
        {
            GameSettings.VoiceVolume = value;
        }


        // UnPause
        public void UnPause()
        {
            SmartInputManager.Pause();
        }


        // Quit Game
        public void QuitGame()
        {
            #if UNITY_EDITOR
		    UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        // Restart Level
        public void StartReloadScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene( 0 );
        }
    }
}