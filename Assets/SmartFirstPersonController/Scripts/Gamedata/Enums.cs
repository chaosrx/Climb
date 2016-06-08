/*******************************************************
 * 													   *
 * Asset:		 Smart First Person Controller 		   *
 * Script:		 Enums.cs                              *
 * 													   *
 * Copyright(c): Victor Klepikov					   *
 * Support: 	 http://bit.ly/vk-Support			   *
 * 													   *
 * mySite:       http://vkdemos.ucoz.org			   *
 * myAssets:     http://u3d.as/5Fb                     *
 * myTwitter:	 http://twitter.com/VictorKlepikov	   *
 * 													   *
 *******************************************************/


namespace SmartFirstPersonController
{
    // Using for "InputManager.cs"
    public enum EUpdateType 
    { 
        Update = 0, 
        LateUpdate = 2, 
        FixedUpdate = 3,
        OFF = 4
    }

    // Using for "InputManager.cs"
    public enum EActionEvent 
    { 
        Down = 0, 
        Press = 1, 
        Up = 2 
    }

    // Using for "InputManager.cs"
    public enum EAxisType
    {
        Unity = 0,
        Custom = 1,
        Mixed = 2
    }

    // Using for "InputManager.cs"
    public enum EActionType
    {
        KeyCode = 0,
        Axis = 1,        
        Mixed = 2
    }

    // Using for "InputManager.cs"
    public enum EAxisState
    {
        NONE = 0,
        PositiveDown = 1, PositivePress = 2, PositiveUp = 3,
        NegativeDown = 4, NegativePress = 5, NegativeUp = 6
    }

    // Using for "InputManager.cs"
    public enum EAxisStateClamp
    {
        NotClamped = 0,
        OnlyPositive = 1,
        OnlyNegative = 2
    }

    // Using for "InputManager.cs"
    public enum EAxisSource
    {
        InputManager = 0,
        NativeInput = 1
    }
    
    // Setter VolumeType
    public enum EVolumeType
    {
        Master = 0,
        Music = 1,
        SFX = 2,
        Voice = 3
    }
}
