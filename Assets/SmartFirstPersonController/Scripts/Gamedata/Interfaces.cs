/*******************************************************
 * 													   *
 * Asset:		 Smart First Person Controller 		   *
 * Script:		 Interfaces.cs                         *
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

namespace SmartFirstPersonController
{
    // IFootstepSFXManager
    public interface IFootstepSFXManager
    {
        void PlayJumpingSound( RaycastHit hit );
        void PlayLandingSound( RaycastHit hit );
        void PlayFootStepSound( RaycastHit hit );
    }

    // ILadder
    public interface ILadder
    {
        Transform m_Transform { get; }

        void AssignAudioSource( AudioSource m_Audio );

        void PlayLadderFootstepSound();
    }
}
