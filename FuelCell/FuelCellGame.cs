// Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
// using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
// using Microsoft.Xna.Framework.Net;
using ShapeRenderingSample;

namespace FuelCell
{

    public enum GameState { Loading, Running, Won, Lost }


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FuelCellGame : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;

        KeyboardState lastKeyboardState = new KeyboardState();
        KeyboardState currentKeyboardState = new KeyboardState();

        public static int retrievedFuelCells;
        TimeSpan startTime, roundTimer, roundTime;
        Random random;
        SpriteBatch spriteBatch;
        SpriteFont statsFont;
        GameState currentGameState = GameState.Loading;

        GameObject ground;
        //        Camera gameCamera;
        //        Camera gameCameraRightVport;

        List<Bullet> bullets = new List<Bullet>();

        GameObject BoundingSphere;

        Skybox skybox;

        //FuelCarrier fuelCarrier;
        //FuelCarrier fuelCarrier2;
        FuelCarrier[] fuelCarriers;

        List<FuelCell> fuelCells = new List<FuelCell>();
        List<Barrier> barriers = new List<Barrier>();

        Viewport defaultViewport;
        //Viewport leftViewport;
        //Viewport rightViewport;
        Matrix projectionMatrix;
        Matrix halfprojectionMatrix;
        //Effect gameEffect;

        public static float ViewAngle = GameConstants.DefaultViewAngle;

        TimeSpan nextFuelCellAddTime = TimeSpan.FromSeconds(GameConstants.SecondsToAdditionOfFirstFuelCell);
        int TotalNumFuelCells = 0;

        // Audio objects
        public static AudioEngine engine;
        public static SoundBank soundBank;
        public static WaveBank waveBank;

        bool EndGameSoundPlayed = false;
        //SoundEffect FuelCellHitSound;

        public FuelCellGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.ApplyChanges();

             // Create FuelCarrier array.
            fuelCarriers = new FuelCarrier[GameConstants.NumPlayers];

            Content.RootDirectory = "Content";

            roundTime = GameConstants.RoundTime;
            random = new Random();


            //BoundingSphereRenderer.InitializeGraphics(graphics.GraphicsDevice, 30);
        }

        public void SetFrameRate(
           GraphicsDeviceManager manager, int frames)
        {
            double dt = (double)1000 / (double)frames;
            manager.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromMilliseconds(dt);
            manager.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ground = new GameObject();
            BoundingSphere = new GameObject();
            skybox = new Skybox();
            //skybox.Position = new Vector3(0, 10, 0);

            // Initialize audio objects.
            engine = new AudioEngine("Content\\Audio\\FuelCell.xgs");
            soundBank = new SoundBank(engine, "Content\\Audio\\Sound Bank.xsb");
            waveBank = new WaveBank(engine, "Content\\Audio\\Wave Bank.xwb");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {


            //graphics.PreferredBackBufferWidth = graphics.GraphicsAdapter.DefaultAdapter.DisplayMode.Width; //1024;  //853
            //graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height; // 768; // 480

            //normal width
            //graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width - 50; //1024;  //853

            //normal height
            graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height - 50; // 768; // 480

            // wide extended
            graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width * 2 - 50; //1024;  //853

            // Extended Laptop and Samsung small TV width
            //graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width * 2 - 850; //1024;  //853

            // Extended Laptop and Samsung small TV height
            //graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height - 350; // 768; // 480

            //graphics.PreferredBackBufferWidth = 1024;  //853
            //graphics.PreferredBackBufferHeight = 768; // 480


            ground.Model = Content.Load<Model>("Models/ground");


            BoundingSphere.Model = Content.Load<Model>("Models/sphere1uR");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            statsFont = Content.Load<SpriteFont>("Fonts/StatsFont");

            //FuelCellHitSound = Content.Load<SoundEffect>("pop1");
            skybox.Model = Content.Load<Model>("Models/skybox");

            //Initialize barriers
            //barriers = new Barrier[GameConstants.NumBarriers];

            //int randomBarrier = random.Next(Barrier.NumBarrierTypes);
            //string barrierName = null;

            //for (int index = 0; index < GameConstants.NumBarriers; index++)
            //{
            //    Barrier thisBarrier;

            //    switch (randomBarrier)
            //    {
            //        case (int)Barrier.BarrierTypes.cube:
            //            barrierName = "Models/cube10uR";
            //            break;
            //        case (int)Barrier.BarrierTypes.pyramid:
            //            barrierName = "Models/pyramid10uR";
            //            break;
            //        case (int)Barrier.BarrierTypes.cylinder:
            //            barrierName = "Models/cylinder10uR";
            //            break;
            //    }

            //    thisBarrier = new Barrier();
            //    thisBarrier.BarrierType = (Barrier.BarrierTypes)randomBarrier;
            //    thisBarrier.LoadContent(Content, barrierName);

            //    barriers.Add(thisBarrier);

            //    randomBarrier = random.Next(Barrier.NumBarrierTypes);
            //}

            //PlaceFuelCellsAndBarriers();

            InitializeGameField();

            //Load bullet mesh

            //Last working missile is below!!!!! %%%
            Bullet.LoadContent(Content, "Models/PKMissileTest");
            //Bullet.LoadContent(Content, "Models/cylinder10uR");
            //Bullet.LoadContent(Content, "Models/Bullet");
            //Bullet.LoadContent(Content, "Models/PK Blend Test1");


            defaultViewport = GraphicsDevice.Viewport;
            defaultViewport.Height = graphics.PreferredBackBufferHeight;
            defaultViewport.Width = graphics.PreferredBackBufferWidth;
            //leftViewport = defaultViewport;
            //rightViewport = defaultViewport;
            //leftViewport.Width = leftViewport.Width / 2;
            //rightViewport.Width = rightViewport.Width / 2;
            ////rightViewport.X = leftViewport.Width + 1;
            //rightViewport.X = leftViewport.Width;

            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, GraphicsDevice.Viewport.Width / GraphicsDevice.Viewport.Height, 1.0f, 10000f);
            halfprojectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, (GraphicsDevice.Viewport.Width / 2) / GraphicsDevice.Viewport.Height, 1.0f, 10000f);

            //Initialize fuel carriers
            for (int playerIndex = 0; playerIndex < GameConstants.NumPlayers; playerIndex++)
            {
                FuelCarrier thisFuelCarrier = new FuelCarrier();

                thisFuelCarrier.camera = new Camera();
                thisFuelCarrier.LoadContent(Content, "Models/fuelcarrier");

                Vector3 p = new Vector3(5f, 0f, 10f) * playerIndex;
                thisFuelCarrier.playerIndex = (PlayerIndex)playerIndex;
                thisFuelCarrier.texture = Content.Load<Texture2D>("Models/fuelcarrier" + (playerIndex + 1));


                thisFuelCarrier.SetStartPosition(p);
                thisFuelCarrier.Reset();

                Viewport thisViewport = defaultViewport;

                thisFuelCarrier.viewport = thisViewport;
                fuelCarriers[playerIndex] = thisFuelCarrier;
            }

            // Set overall window position.
            Window.Position = new Point(17, 30);

            // Setup viewports.
            switch (GameConstants.NumPlayers)
            {
                case 1:
                    // If only one player, only one viewport so leave default size.
                    fuelCarriers[0].SetKeyboardControlKeys(Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.LeftControl);
                    break;

                case 2:
                    // If two players then split screen in half.
                    if (GameConstants.topBottomTwoPlayerScreenSplit)
                    {
                        // Split into top and bottom viewports.
                        fuelCarriers[0].viewport.Height = defaultViewport.Height / 2;
                        fuelCarriers[1].viewport.Height = defaultViewport.Height - fuelCarriers[0].viewport.Height;
                        fuelCarriers[1].viewport.Y = fuelCarriers[0].viewport.Height;
                    }
                    else
                    {
                        // Split into right and left viewports.
                        fuelCarriers[0].viewport.Width = defaultViewport.Width / 2;
                        fuelCarriers[1].viewport.Width = defaultViewport.Width - fuelCarriers[0].viewport.Width;
                        fuelCarriers[1].viewport.X = fuelCarriers[0].viewport.Width;

                        // Doing full height viewports so increase viewing angle from 30 to 45 degrees.
                        ViewAngle = GameConstants.FullHeightViewAngle;
                    }

                    fuelCarriers[0].SetKeyboardControlKeys(Keys.A, Keys.D, Keys.W, Keys.S, Keys.LeftControl);
                    fuelCarriers[1].SetKeyboardControlKeys(Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.RightControl);
                    break;

                case 3:
                    // If three players then split horizontally and then split bottom port vertically.
                    fuelCarriers[0].viewport.Height = defaultViewport.Height / 2;
                    fuelCarriers[1].viewport.Height = defaultViewport.Height - fuelCarriers[0].viewport.Height;
                    fuelCarriers[2].viewport.Height = fuelCarriers[1].viewport.Height;
                    fuelCarriers[1].viewport.Width = defaultViewport.Width / 2;
                    fuelCarriers[2].viewport.Width = defaultViewport.Width - fuelCarriers[1].viewport.Width;
                    fuelCarriers[1].viewport.Y = fuelCarriers[0].viewport.Height;
                    fuelCarriers[2].viewport.Y = fuelCarriers[1].viewport.Y;
                    fuelCarriers[2].viewport.X = fuelCarriers[1].viewport.Width;

                    fuelCarriers[0].SetKeyboardControlKeys(Keys.A, Keys.D, Keys.W, Keys.S, Keys.LeftControl);
                    fuelCarriers[1].SetKeyboardControlKeys(Keys.G, Keys.J, Keys.Y, Keys.H, Keys.Space);
                    fuelCarriers[2].SetKeyboardControlKeys(Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.RightControl);

                    break;

                case 4:
                    // If four players then split horizontally and then split each port vertically.
                    fuelCarriers[0].viewport.Height = defaultViewport.Height / 2;
                    fuelCarriers[0].viewport.Width = defaultViewport.Width / 2;
                    fuelCarriers[1].viewport.Height = fuelCarriers[0].viewport.Height;
                    fuelCarriers[1].viewport.Width = defaultViewport.Width - fuelCarriers[0].viewport.Width;
                    fuelCarriers[1].viewport.X = fuelCarriers[0].viewport.Width;

                    fuelCarriers[2].viewport.Height = defaultViewport.Height - fuelCarriers[0].viewport.Height;
                    fuelCarriers[3].viewport.Height = fuelCarriers[2].viewport.Height;
                    fuelCarriers[2].viewport.Width = defaultViewport.Width / 2;
                    fuelCarriers[3].viewport.Width = defaultViewport.Width - fuelCarriers[2].viewport.Width;
                    fuelCarriers[2].viewport.Y = fuelCarriers[0].viewport.Height;
                    fuelCarriers[3].viewport.Y = fuelCarriers[2].viewport.Y;
                    fuelCarriers[1].viewport.X = fuelCarriers[0].viewport.Width;
                    fuelCarriers[3].viewport.X = fuelCarriers[0].viewport.Width;

                    fuelCarriers[0].SetKeyboardControlKeys(Keys.A, Keys.D, Keys.W, Keys.S, Keys.LeftControl);
                    fuelCarriers[1].SetKeyboardControlKeys(Keys.F, Keys.H, Keys.T, Keys.G, Keys.Space);
                    fuelCarriers[2].SetKeyboardControlKeys(Keys.J, Keys.L, Keys.I, Keys.K, Keys.RightAlt);
                    fuelCarriers[3].SetKeyboardControlKeys(Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.RightControl);

                    break;

            }

            SetFrameRate(graphics, GameConstants.FrameRate);

            //gameCameraRightVport.Update(fuelCarrier.ForwardDirection,
            //    fuelCarrier.Position, GraphicsDevice.Viewport.Width / GraphicsDevice.Viewport.Height / 1.7f);
            // Initialize our renderer
            DebugShapeRenderer.Initialize(GraphicsDevice);

        }

        private void AddFuelCell()
        {
            //Initialize fuel cells
            FuelCell cell = new FuelCell();
            cell.LoadContent(Content, "Models/fuelcell");

            int min = GameConstants.MinDistance;
            int max = GameConstants.MaxDistance;
            Vector3 tempCenter;

            cell.Position = GenerateRandomPosition(min, max);
            tempCenter = cell.BoundingSphere.Center;
            tempCenter.X = cell.Position.X;
            tempCenter.Y = cell.BoundingSphere.Center.Y;
            tempCenter.Z = cell.Position.Z;
            cell.BoundingSphere =
                new BoundingSphere(tempCenter, cell.BoundingSphere.Radius);
            cell.Retrieved = false;

            fuelCells.Add(cell);
            ++TotalNumFuelCells;

        }


        private void PlaceFuelCells()
        {
            fuelCells.Clear();
            TotalNumFuelCells = 0;

            for (int i = 1; i <= GameConstants.InitialNumFuelCells; i++)
                AddFuelCell();

        }

        private Vector3 GenerateRandomPosition(int min, int max)
        {
            int xValue, zValue;
            do
            {
                xValue = random.Next(min, max);
                zValue = random.Next(min, max);
                if (random.Next(100) % 2 == 0)
                    xValue *= -1;
                if (random.Next(100) % 2 == 0)
                    zValue *= -1;

            } while (IsOccupied(xValue, zValue));

            return new Vector3(xValue, 0, zValue);
        }

        private bool IsOccupied(int xValue, int zValue)
        {
            foreach (GameObject currentObj in fuelCells)
            {
                if (((int)(MathHelper.Distance(
                    xValue, currentObj.Position.X)) < 15) &&
                    ((int)(MathHelper.Distance(
                    zValue, currentObj.Position.Z)) < 15))
                    return true;
            }

            foreach (GameObject currentObj in barriers)
            {
                if (((int)(MathHelper.Distance(
                    xValue, currentObj.Position.X)) < 15) &&
                    ((int)(MathHelper.Distance(
                    zValue, currentObj.Position.Z)) < 15) &&
                    (currentObj.Position.Y < 15))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            float aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
            // Not first time through so check if time for next fuelcell addtion has elapsed.
            if (gameTime.TotalGameTime > nextFuelCellAddTime)
            {
                // Time to add next fuel cell.
                AddFuelCell();
                nextFuelCellAddTime = gameTime.TotalGameTime + TimeSpan.FromSeconds(GameConstants.SecondsBetweenAdditionOfEachFuelCell);
            }

            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Allows the game to exit via keyboard.
            if ((currentKeyboardState.IsKeyDown(Keys.Escape)))
                this.Exit();

            // Update gamepad states and allow game to exit via gamepad controllers.
            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {

                fuelCarrier.lastGamePadState = fuelCarrier.currentGamePadState;
                fuelCarrier.currentGamePadState = GamePad.GetState(fuelCarrier.playerIndex);

                //if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                //    this.Exit(); 

                if (fuelCarrier.currentGamePadState.Buttons.Back == ButtonState.Pressed)
                    this.Exit();
            }

            //// Update location of camera.
            //if (currentKeyboardState.IsKeyDown(Keys.R) && lastKeyboardState.IsKeyDown(Keys.R))
            //{
            //    gameCameraRightVport.Update(fuelCarrier.ForwardDirection,
            //        fuelCarrier.Position, aspectRatio);
            //}

            if (currentGameState == GameState.Loading)
            {
                Boolean startRequested = false;
                foreach (FuelCarrier fuelCarrier in fuelCarriers)
                {
                    if (fuelCarrier.currentGamePadState.Buttons.Start == ButtonState.Pressed)
                    {
                        startRequested = true;
                        break;
                    }
                }

                if ((lastKeyboardState.IsKeyDown(Keys.Enter) &&
                    (currentKeyboardState.IsKeyUp(Keys.Enter))) || startRequested)
                {
                    roundTimer = roundTime;
                    currentGameState = GameState.Running;
                }
            }

            if ((currentGameState == GameState.Running))
            {
                foreach (FuelCarrier fuelCarrier in fuelCarriers)
                {
                    // Update location of fuel carriers based on user input.
                    fuelCarrier.Update(gameTime, currentKeyboardState, lastKeyboardState, barriers, bullets, fuelCarriers);
                    //fuelCarrier2.Update(gameTime, currentGamePadStateTwo, lastGamePadStateTwo,
                    //    currentKeyboardState, lastKeyboardState, barriers, bullets, 2, fuelCarrier);

                    if (fuelCarrier.currentGamePadState.Buttons.Start == ButtonState.Pressed && fuelCarrier.lastGamePadState.Buttons.Start != ButtonState.Pressed &&
                         fuelCarrier.currentGamePadState.IsButtonDown(Buttons.DPadLeft))
                    {
                        // DPad left held down whilst Start button pressed so fuelCarrier flight activation requested.
                        if (!fuelCarrier.allowFlight)
                        {
                            // Not already enabled so enable flight for this fuel carrier
                            fuelCarrier.allowFlight = true;
                            fuelCarrier.allowElevation = true;
                        }
                        else
                        {
                            // Already enabled for this fuel carrier so enable elevation (but not flight) for all other gamepads.
                            foreach (FuelCarrier fuelCarrierToElevate in fuelCarriers)
                            {
                                fuelCarrierToElevate.allowElevation = true;
                            }
                        }
                    }


                    if (fuelCarrier.currentGamePadState.Buttons.A == ButtonState.Pressed && fuelCarrier.lastGamePadState.Buttons.A != ButtonState.Pressed)
                    {
                        // Add a barrier at the current position.
                        Vector3 Position = fuelCarrier.Position + Vector3.Transform(Vector3.Backward, Matrix.CreateRotationX(fuelCarrier.Elevation) * Matrix.CreateRotationY(fuelCarrier.ForwardDirection)) * GameConstants.PlacedCubeOffset;

                        Barrier.AddBarrier(barriers, Content, Position, Barrier.BarrierTypes.cube, fuelCarriers);
                    }

                    if (fuelCarrier.currentGamePadState.Buttons.B == ButtonState.Pressed && fuelCarrier.lastGamePadState.Buttons.B != ButtonState.Pressed)
                    {
                        // Remove barrier in front of fuel carrier
                        Vector3 Position = fuelCarrier.Position + Vector3.Transform(Vector3.Backward, Matrix.CreateRotationY(fuelCarrier.ForwardDirection)) * GameConstants.PlacedCubeOffset;

                        Barrier.RemoveBarrier(fuelCarrier, barriers, Position);
                    }


                    // Update location of cameras.
                    fuelCarrier.camera.Update(fuelCarrier.ForwardDirection, fuelCarrier.Elevation,
                        fuelCarrier.Position, fuelCarrier.viewport.AspectRatio, ViewAngle);
                    //                    gameCameraRightVport.Update(fuelCarrier2.ForwardDirection,
                    //                        fuelCarrier2.Position, aspectRatio);

                    //retrievedFuelCells = 0;
                    for (int index = 0; index < fuelCells.Count; index++)
                    {
                        FuelCell fuelCell = (FuelCell)fuelCells[index];
                        bool previouslyRetrieved = fuelCell.Retrieved;
                        if (fuelCell.Update(fuelCarrier.BoundingSphere) && previouslyRetrieved == false)
                        {
                            fuelCarrier.retreivedFuelCells++;
                            fuelCarrier.AddBullets();
                            soundBank.PlayCue("pop1");
                            fuelCells.RemoveAt(index);
                        }

                        if (fuelCell.Retrieved)
                        {
                            retrievedFuelCells++;
                            //FuelCellHitSound.Play();
                        }

                    }

                }

                foreach (Bullet bullet in bullets)
                {
                    bullet.Update(gameTime, barriers, bullets, fuelCells, fuelCarriers);
                }

                // Handle updates for bullets that have hit things.
                // First remove any bullets that have exploded.
                for (int index = 0; index < bullets.Count; index++)
                {
                    if (((Bullet)bullets[index]).Destroyed)
                    {
                        bullets.RemoveAt(index);
                    }
                }

                //if (retrievedFuelCells == GameConstants.InitialNumFuelCells)
                //{
                //    currentGameState = GameState.Won;
                //}
                roundTimer -= gameTime.ElapsedGameTime;
                //if ((roundTimer < TimeSpan.Zero) &&
                //    (retrievedFuelCells != GameConstants.InitialNumFuelCells))
                if ((roundTimer < TimeSpan.Zero))
                {
                    currentGameState = GameState.Lost;
                }
            }

            if ((currentGameState == GameState.Won) ||
                (currentGameState == GameState.Lost))
            {

                Boolean startRequested = false;
                foreach (FuelCarrier fuelCarrier in fuelCarriers)
                {
                    if (fuelCarrier.currentGamePadState.Buttons.Start == ButtonState.Pressed)
                    {
                        startRequested = true;
                        break;
                    }
                }

                if ((lastKeyboardState.IsKeyDown(Keys.Enter) &&
                    (currentKeyboardState.IsKeyUp(Keys.Enter))) || startRequested)
                {
                    // Reset the world for a new game
                    ResetGame(gameTime);
                }
            }

            // Update the audio engine.
            engine.Update();

            base.Update(gameTime);
        }

        private void ResetGame(GameTime gameTime)
        {
            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {
                fuelCarrier.Reset();

                fuelCarrier.camera.Update(fuelCarrier.ForwardDirection, fuelCarrier.Elevation,
                    fuelCarrier.Position, fuelCarrier.viewport.AspectRatio, ViewAngle);
            }

            InitializeGameField();

            retrievedFuelCells = 0;
            startTime = gameTime.TotalGameTime;
            roundTimer = roundTime;
            currentGameState = GameState.Running;
            EndGameSoundPlayed = false;

            bullets.Clear();
        }

        private void InitializeGameField()
        {
            //Initialize barriers
            //barriers = new Barrier[GameConstants.NumBarriers];
            int min = GameConstants.MinDistance;
            int max = GameConstants.MaxDistance;

            int randomBarrier = random.Next(Barrier.NumBarrierTypes);

            barriers.Clear();

            for (int index = 0; index < GameConstants.NumBarriers; index++)
            {
                Vector3 Position;

                Position = GenerateRandomPosition(min, max);
                Barrier.AddBarrier(barriers, Content, Position, (Barrier.BarrierTypes)randomBarrier, fuelCarriers);

                randomBarrier = random.Next(Barrier.NumBarrierTypes);
            }

            PlaceFuelCells();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameState.Loading:
                    GraphicsDevice.Viewport = defaultViewport;
                    graphics.GraphicsDevice.Clear(Color.Black);

                    DrawSplashScreen();
                    break;
                case GameState.Running:
                    DrawAllGameplayScreenElements(gameTime);
                    break;
                case GameState.Won:
                    DrawAllGameplayScreenElements(gameTime);
                    GraphicsDevice.Viewport = fuelCarriers[0].viewport;
                    DrawStats(defaultViewport);
                    if (EndGameSoundPlayed == false)
                    {
                        soundBank.PlayCue("fanfare3");
                        EndGameSoundPlayed = true;
                    }
                    DrawWinOrLossScreen(GameConstants.StrGameWon);
                    break;
                case GameState.Lost:
                    DrawAllGameplayScreenElements(gameTime);
                    GraphicsDevice.Viewport = fuelCarriers[0].viewport;
                    DrawStats(defaultViewport);
                    if (EndGameSoundPlayed == false)
                    {
                        soundBank.PlayCue("slash");
                        EndGameSoundPlayed = true;
                    }
                    DrawWinOrLossScreen(GameConstants.StrGameLost);
                    break;
            };

            base.Draw(gameTime);
        }

        void DrawAllGameplayScreenElements(GameTime gameTime)
        {
            GraphicsDevice.Viewport = defaultViewport;
            graphics.GraphicsDevice.Clear(Color.Black);

            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {
                GraphicsDevice.Viewport = fuelCarrier.viewport;
                DrawGameplayScreen(gameTime, fuelCarrier);
                DrawStats(fuelCarrier.viewport);

                //DrawGameplayScreen(gameCamera, fuelCarrier2);

                //fuelCarrier.Draw(gameCameraRightVport.ViewMatrix, gameCameraRightVport.ProjectionMatrix);

                //                GraphicsDevice.Viewport = rightViewport;
                //                DrawGameplayScreen(gameTime, gameCameraRightVport);
                //DrawGameplayScreen(gameCameraRightVport, fuelCarrier);

                //fuelCarrier.Draw(gameCameraRightVport.ViewMatrix, gameCameraRightVport.ProjectionMatrix);
            }

            //DrawStats(defaultViewport);

        }


        /// <summary>
        /// Draws the game terrain, a simple blue grid.
        /// </summary>
        /// <param name="model">Model representing the game playing field.</param>
        private void DrawTerrain(Model model, Camera thisCamera)
        {
            Matrix scaleMatrix = Matrix.CreateScale((float)(GameConstants.MaxRange + GameConstants.ExtraBorderToAvoidOverlook) / (float)GameConstants.DefaultMaxRange);


            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    //effect.TextureEnabled = true;
                    //effect.DiffuseColor = new Vector3(0.5f, 0.5f, 0.5f);
                    effect.PreferPerPixelLighting = true;
                    effect.World = Matrix.Identity * scaleMatrix;

                    // Use the matrices provided by the game camera
                    effect.View = thisCamera.ViewMatrix;
                    effect.Projection = thisCamera.ProjectionMatrix;
                }
                mesh.Draw();
            }
        }

        private void DrawSplashScreen()
        {
            float xOffsetText, yOffsetText;
            Vector2 viewportSize = new Vector2(GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height);
            Vector2 strCenter;

            graphics.GraphicsDevice.Clear(Color.SteelBlue);

            xOffsetText = yOffsetText = 0;
            Vector2 strInstructionsSize =
                statsFont.MeasureString(GameConstants.StrInstructions1);
            Vector2 strPosition;
            strCenter = new Vector2(strInstructionsSize.X / 2,
                strInstructionsSize.Y / 2);

            yOffsetText = (viewportSize.Y / 2 - strCenter.Y);
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2((int)xOffsetText, (int)yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, GameConstants.StrInstructions1,
                strPosition, Color.White);

            strInstructionsSize =
                statsFont.MeasureString(GameConstants.StrInstructions2);
            strCenter = new Vector2(strInstructionsSize.X / 2,
                strInstructionsSize.Y / 2);
            yOffsetText =
                (viewportSize.Y / 2 - strCenter.Y) + statsFont.LineSpacing;
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2((int)xOffsetText, (int)yOffsetText);

            spriteBatch.DrawString(statsFont, GameConstants.StrInstructions2,
                strPosition, Color.LightGray);
            spriteBatch.End();

            //re-enable depth buffer after sprite batch disablement
            //GraphicsDevice.RenderState.DepthBufferEnable = true;
            //GraphicsDevice.RenderState.AlphaBlendEnable = false;
            //GraphicsDevice.RenderState.AlphaTestEnable = false;

            DepthStencilState dss = new DepthStencilState();
            dss.DepthBufferEnable = true;
            GraphicsDevice.DepthStencilState = dss;

            //%%%%
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }

        private void DrawWinOrLossScreen(string gameResult)
        {
            float xOffsetText, yOffsetText;
            Vector2 viewportSize = new Vector2(GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height);
            Vector2 strCenter;

            xOffsetText = yOffsetText = 0;
            Vector2 strResult = statsFont.MeasureString(gameResult);
            Vector2 strPlayAgainSize =
                statsFont.MeasureString(GameConstants.StrPlayAgain);
            Vector2 strPosition;
            strCenter = new Vector2(strResult.X / 2, strResult.Y / 2);

            yOffsetText = (viewportSize.Y / 2 - strCenter.Y);
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2((int)xOffsetText, (int)yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, gameResult,
                strPosition, Color.Red);

            strCenter =
                new Vector2(strPlayAgainSize.X / 2, strPlayAgainSize.Y / 2);
            yOffsetText = (viewportSize.Y / 2 - strCenter.Y) +
                (float)statsFont.LineSpacing;
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2((int)xOffsetText, (int)yOffsetText);
            spriteBatch.DrawString(statsFont, GameConstants.StrPlayAgain,
                strPosition, Color.AntiqueWhite);

            spriteBatch.End();

            //re-enable depth buffer after sprite batch disablement
            //GraphicsDevice.RenderState.DepthBufferEnable = true;
            //GraphicsDevice.RenderState.AlphaBlendEnable = false;
            //GraphicsDevice.RenderState.AlphaTestEnable = false;

            DepthStencilState dss = new DepthStencilState();
            dss.DepthBufferEnable = true;
            GraphicsDevice.DepthStencilState = dss;

            //%%%%
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }

        private void DrawGameplayScreen(GameTime gameTime, FuelCarrier thisFuelCarrier)
        {
            Vector3 newPsn = Vector3.Zero;

            //if (thisFuelCarrier.currentGamePadState.IsButtonDown(Buttons.RightShoulder))
            //    newPsn = Vector3.Zero;
            //newPsn.Y = thisFuelCarrier.Position.Y - 0.3f;
            newPsn = thisFuelCarrier.Position;
            //newPsn.Y = GameConstants.SkyboxHeight;
            skybox.Position = newPsn;
            skybox.Draw(thisFuelCarrier.camera.ViewMatrix, thisFuelCarrier.camera.ProjectionMatrix, graphics.GraphicsDevice);

            DrawTerrain(ground.Model, thisFuelCarrier.camera);
            foreach (FuelCell fuelCell in fuelCells)
            {
                if (!fuelCell.Retrieved)
                {
                    fuelCell.Draw(thisFuelCarrier.camera.ViewMatrix,
                        thisFuelCarrier.camera.ProjectionMatrix);
                }
            }
            foreach (Barrier barrier in barriers)
            {
                barrier.Draw(thisFuelCarrier.camera.ViewMatrix,
                    thisFuelCarrier.camera.ProjectionMatrix);
            }

            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(thisFuelCarrier.camera.ViewMatrix,
                    thisFuelCarrier.camera.ProjectionMatrix);
            }

            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {

                fuelCarrier.Draw(gameTime, thisFuelCarrier.camera.ViewMatrix,
                    thisFuelCarrier.camera.ProjectionMatrix);

                if (GameConstants.DrawCameraBoundingFrustrums)
                {
                    // Select colour.
                    Color thisColor;
                    switch (fuelCarrier.playerIndex)
                    {
                        case PlayerIndex.One:
                            thisColor = Color.Blue;
                            break;

                        case PlayerIndex.Two:
                            thisColor = Color.Red;
                            break;

                        case PlayerIndex.Three:
                            thisColor = Color.Green;
                            break;

                        case PlayerIndex.Four:
                            thisColor = Color.Yellow;
                            break;

                        default:
                            thisColor = Color.Green;
                            break;
                    }
                    fuelCarrier.camera.DrawBoundingFrustrum(0f, thisColor);
                }
                // Draw FuelCarrier BoundingSphere trails.
                //DebugShapeRenderer.AddBoundingSphere(thisFuelCarrier.BoundingSphere, Color.Red, 10f);

                // Render debug shapes now
                if (GameConstants.ShowBulletTrack)
                { 
                    Vector3 bulletStartPsn = fuelCarrier.Position;
                    bulletStartPsn.Y += GameConstants.BulletHeight;
                    DebugShapeRenderer.AddLine(bulletStartPsn, bulletStartPsn + fuelCarrier.GetDirection() * 175, Color.Green);
                }
                DebugShapeRenderer.Draw(gameTime, thisFuelCarrier.camera.ViewMatrix,
                    thisFuelCarrier.camera.ProjectionMatrix);

                //                fuelCarrier2.Draw(gameTime, thisFuelCarrier.camera.ViewMatrix,
                //                    thisFuelCarrier.camera.ProjectionMatrix);
                //if (thisFuelCarrier.camera == gameCamera)
            }
            // Construct our view and projection matrices
            //Matrix frustumView = Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitX, Vector3.Up);
            //Matrix frustumProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16f / 9f, 1f, 5f);
            //BoundingFrustum frustum = new BoundingFrustum(frustumView * frustumProjection);
            //float angle = (float)gameTime.TotalGameTime.TotalSeconds;
            //Vector3 eye = new Vector3((float)Math.Cos(angle * .5f), 0f, (float)Math.Sin(angle * .5f)) * 12f;
            //eye.Y = 5f;
            //Matrix view = Matrix.CreateLookAt(eye, Vector3.Zero, Vector3.Up);
            //Matrix projection = Matrix.CreatePerspectiveFieldOfView(
            //    MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);

            //// Add our shapes to be rendered
            //DebugShapeRenderer.AddBoundingFrustum(frustum, Color.Green);


        }

        private void DrawStats(Viewport viewport)
        {
            float xOffsetText, yOffsetText;
            string str1 = GameConstants.StrTimeRemaining;
            string str2 =
                "Found " + retrievedFuelCells.ToString() + " of " + TotalNumFuelCells.ToString() + " cells";

            Rectangle rectSafeArea;

            str1 += (roundTimer.Minutes).ToString() + ":" + (roundTimer.Seconds).ToString();

            GraphicsDevice.Viewport = viewport;

            //Calculate str1 position
            rectSafeArea = viewport.TitleSafeArea;

            xOffsetText = viewport.X - rectSafeArea.X;
            yOffsetText = viewport.Y - rectSafeArea.Y;

            Vector2 strSize = statsFont.MeasureString(str1);
            Vector2 strPosition =
                new Vector2((int)xOffsetText + 10, (int)yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, str1, strPosition, Color.White);
            strPosition.Y += strSize.Y;
            spriteBatch.DrawString(statsFont, str2, strPosition, Color.White);
            strPosition.Y += strSize.Y;

            // Draw gun site a third of the way up the viewport
            Vector2 CrossHairPosition = new Vector2(viewport.Width / 2, viewport.Height / 3.5f);
            CrossHairPosition.X -= 6;  // Adjust for width of character.
            spriteBatch.DrawString(statsFont, "+", CrossHairPosition, Color.White);

            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {
                string str3 = "P" + ((int)fuelCarrier.playerIndex + 1) + " Retrvd:" + fuelCarrier.retreivedFuelCells.ToString() +
                              " Kills:" + fuelCarrier.numKills.ToString() +
                              " Died:" + fuelCarrier.numTimesDied.ToString() +
                              " Bullts Rem:" + fuelCarrier.bulletCountRemaining.ToString(); // +
//                              " Stick:" + fuelCarrier.currentGamePadState.ThumbSticks.Right.X;

                spriteBatch.DrawString(statsFont, str3, strPosition, Color.White);
                strPosition.Y += strSize.Y;
            }

            spriteBatch.End();

            //re-enable depth buffer after sprite batch disablement
            //GraphicsDevice.RenderState.DepthBufferEnable = true;
            //GraphicsDevice.RenderState.AlphaBlendEnable = false;
            //GraphicsDevice.RenderState.AlphaTestEnable = false;

            DepthStencilState dss = new DepthStencilState();
            dss.DepthBufferEnable = true;
            GraphicsDevice.DepthStencilState = dss;

            //%%%%
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }
    }
}
