/*******************************************************
 * 													   *
 * Asset:		 Smart First Person Controller 		   *
 * Script:		 CameraHeadBob.cs                      *
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
    public class CameraHeadBob : MonoBehaviour
    {
        // Fields for parameters

        [Range( 1f, 3f )]
        [SerializeField]
        private float headBobFrequency = 1.5f;

        [Range( .1f, 2f )]
        [SerializeField]
        private float headBobHeight = .35f;

        [Range( .1f, 2f )]
        [SerializeField]
        private float headBobSwayAngle = .5f;

        [Range( .01f, .1f )]
        [SerializeField]
        private float headBobSideMovement = .075f;

        [Range( .1f, 2f )]
        [SerializeField]
        private float bobHeightSpeedMultiplier = .35f;

        [Range( .1f, 2f )]
        [SerializeField]
        private float bobStrideSpeedLengthen = .35f;

        [Range( .1f, 5f )]
        [SerializeField]
        private float jumpLandMove = 2f;

        [Range( 10f, 100f )]
        [SerializeField]
        private float jumpLandTilt = 35f;

        [Range( .1f, 4f )]
        [SerializeField]
        private float springElastic = 1.25f;

        [Range( .1f, 2f )]
        [SerializeField]
        private float springDampen = .77f;

        // Fields for calculation
        private float springPos, springVelocity, headBobFade;
        private Vector3 velocity, velocityChange, prevPosition, prevVelocity;
        private Transform m_Transform = null;

        // Fields for internal access
        public static float headBobCycle { get; private set; }
        public static float xPos { get; private set; }
        public static float yPos { get; private set; }
        public static float xTilt { get; private set; }
        public static float yTilt { get; private set; }

        // Awake
        void Awake()
        {
            m_Transform = transform;
        }

        // OnEnable
        void OnEnable()
        {
            headBobCycle = 0f;
            xPos = yPos = 0f;
            xTilt = yTilt = 0f;
        }

        // FixedUpdate
        void FixedUpdate()
        {
            float deltaTime = Time.fixedDeltaTime;

            velocity = ( m_Transform.position - prevPosition ) / deltaTime;
            velocityChange = velocity - prevVelocity;
            prevPosition = m_Transform.position;
            prevVelocity = velocity;

            if( !FirstPersonController.isClimbing )
                velocity.y = 0f;

            springVelocity -= velocityChange.y;
            springVelocity -= springPos * springElastic;
            springVelocity *= springDampen;
            springPos += springVelocity * deltaTime;
            springPos = Mathf.Clamp( springPos, -.32f, .32f );

            if( Mathf.Abs( springVelocity ) < .05f && Mathf.Abs( springPos ) < .05f )
                springVelocity = springPos = 0f;

            float flatVelocity = velocity.magnitude;

            if( FirstPersonController.isClimbing )
                flatVelocity *= 4f;
            else if( !FirstPersonController.isClimbing && !FirstPersonController.isGrounded )
                flatVelocity /= 4f;

            float strideLengthen = 1f + flatVelocity * bobStrideSpeedLengthen;
            headBobCycle += ( flatVelocity / strideLengthen ) * ( deltaTime / headBobFrequency );

            float bobFactor = Mathf.Sin( headBobCycle * Mathf.PI * 2f );
            float bobSwayFactor = Mathf.Sin( headBobCycle * Mathf.PI * 2f + Mathf.PI * .5f );
            bobFactor = 1f - ( bobFactor * .5f + 1f );
            bobFactor *= bobFactor;

            if( velocity.magnitude < .1f )
                headBobFade = Mathf.Lerp( headBobFade, 0f, deltaTime );
            else
                headBobFade = Mathf.Lerp( headBobFade, 1f, deltaTime );

            float speedHeightFactor = 1f + ( flatVelocity * bobHeightSpeedMultiplier );

            xPos = -headBobSideMovement * bobSwayFactor * headBobFade;
            yPos = springPos * jumpLandMove + bobFactor * headBobHeight * headBobFade * speedHeightFactor;
            xTilt = springPos * jumpLandTilt;
            yTilt = bobSwayFactor * headBobSwayAngle * headBobFade;
        }
    }
}