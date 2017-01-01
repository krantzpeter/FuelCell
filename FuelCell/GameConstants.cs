// Copyright (C) Microsoft Corporation. All rights reserved.

using System;

namespace FuelCell
{
    class GameConstants
    {
        //camera constants
        public const float NearClip = 1.0f;
        public const float FarClip = 1000.0f;
        public const int FrameRate = 120;

        // Camera view angle in degrees.
        public const float DefaultViewAngle = 35f; // View angle of half screen height viewport.
        public const float FullHeightViewAngle = 45f; // View angle of full screen height viewport.

        //num players
        public const int NumPlayers = 2;
        public const Boolean topBottomTwoPlayerScreenSplit = false;

        //ship constants
        public const float Velocity = .75f; //0.75F //2f
        public const float TurnSpeed = 0.001f; //0.025
        public const float MaxTurnAmount = 70;
        public const float ElevationMultiplier = 0.01f;
        public const Boolean zeroGMovementMode = true;
        public const float MaxFwdSpeedInZeroGMode = 2.0f;
        public const float ZeroGModeFwdInc = 0.01f;

        public const Boolean AllowUndergroundDriving = false;

        // public const float TurnAccelInc = 0.001f;//0.005f

        // Maximum extend of ground terrain X and Z coordinates.  (set to 98 for normal).
        public const int DefaultMaxRange = 98;
        public const int MaxRange = 200; //118;  //218; //118;  //98
        public const int ExtraBorderToAvoidOverlook = 0;

        public const float SkyboxHeight = 0f; //-0.3f;

        // Range of board posiitons in which game objects will be generated.
        public const int MinDistance = 10;
        public const int MaxDistance = MaxRange - 8; //210;//110; //90

        public const float BulletSpeed = .05f; //1.75f; //.05f; //2.0f; //3.0f; //2.0
        public const float BulletStartOffset = 4.0f;  //4.0f was 3.5f
        public const float BulletHeight = 0.65f; //0.8
        public const bool ShowBulletTrack = true;
        public const float PlacedCubeOffset = 8.0f;

        public const double secondsDestroyedDelay = 3.0f;
        public const double secondsVibrateTime = 0.6f;
        public const double secondsVibrateAdjust = secondsDestroyedDelay - secondsVibrateTime;

        public const double secondsFlashDelay = 0.2f;

        public const Boolean DrawBoundingSpheres = false;
        public const Boolean DrawCameraBoundingFrustrums = false;

        // Gamepad constants
        public const float ThumbstickXMultiplier = 19.0f; // 30.0f; // Multiplier to use for turning using gamepad thumbstick
        public const float ThumbstickYMultiplier = 1.1f; // 1.5f;    //Multiplier to use for forward and backward movement using gamepad thumbstick
        public const float ThumbstickSidewaysMultiplier = 0.75f;  // Multiplier to use of sideways movement using the left gamepad thumbstick
        public const float ThumbstickMinRegistrationVal = 0.05f;
        public const float ThumbstickSmallIncrementThreshhold = 0.05f;
        public const float ThumbstickSmallIncrementVal = 0.005f;
        // public const float MinGamepadTurnToAvoidDrift = 0.1f;
        public const float ScopedGamepadTurnFactor = 5.0f;

        // Set to true if you want the ThumbStick control on a gamepad to move players sideways.
        public const bool allowSidewaysGamePadMovement = false;

        //general
        public const bool BulletsBounce = true;  //true if bullets bounce off barriers.
        //public const int MaxRangeTerrain = 98;
        public const int NumBarriers = 70; //70; //120; //70;
        public const int InitialNumFuelCells = 0; //30
        public const int StartBulletCountPerPlayer = 0;
        public const int ExtraBulletsEarntPerFuelCell = 10;
        public const double SecondsBetweenAdditionOfEachFuelCell = 30.0 / NumPlayers;
        public const double SecondsToAdditionOfFirstFuelCell = 5.0;
        
        public static readonly TimeSpan RoundTime = TimeSpan.FromSeconds(599); //599 //45.25
        public const string StrTimeRemaining = "Time Remaining: ";
        public const string StrCellsFound = "Fuel Cells Retrieved: ";
        public const string StrGameWon = "Game Won !";
        public const string StrGameLost = "Game Lost !";
        public const string StrPlayAgain = 
            "Press Enter/Start to play again or Esc/Back to quit";
        public const string StrInstructions1 = 
            "Retrieve all Fuel Cells before time runs out.";
        public const string StrInstructions2 = 
            "Control left ship using A, D, W, S keys or the left thumbstick and right ship using arrow keys or right thumbstick.";

        //bounding sphere scaling factors
        public const float FuelCarrierBoundingSphereFactor = 0.7f; // .8f;
        public const float FuelCellBoundingSphereFactor = .5f;
        public const float BarrierBoundingSphereFactor = .6f; //0.7f
        public const float BulletBoundingSphereFactor = 0.5f;  //0.1f
        public const float CubeBoundingSphereHeightOffset = -1f;
        public const float FuelCarrierBoundingSphereHeightOffset = 1f;
    }
}
