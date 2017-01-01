// Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeRenderingSample;

namespace FuelCell
{
    class GameObject
    {
        //private bool bLastPositionSet = false;

        public Model Model { get; set; }
        private Vector3 position;
        public float Speed { get; set; }

        //private Vector3 myPosition;
        //private Vector3 myLastPosition;

        //public Vector3 Position 
        //{ 
        //    get
        //    {
        //        return myPosition;
        //    }
        //    set
        //    {
        //        LastPosition = myPosition;
        //        myPosition = value;
        //    }
        //}
        //public Vector3 LastPosition
        //{
        //    get
        //    {
        //        if (bLastPositionSet)
        //            return myPosition;
        //        else
        //            return myLastPosition;
        //    }
        //    set
        //    {
        //        bLastPositionSet = true;
        //        myLastPosition = value;
        //    }
        //}

        public BoundingSphere BoundingSphere { get; set; }

        //BoundingSphere mBoundingSphere;

        //public BoundingSphere BoundingSphere
        //{
        //    get
        //    {
        //        return mBoundingSphere;
        //    }
        //    set
        //    {
        //        mBoundingSphere = value;
        //    }
        //}

        public bool Destroyed { get; set; }

        public GameObject()
        {
            Model = null;
            position = Vector3.Zero;
            Speed = 0f;
            //LastPosition = Vector3.Zero;
            BoundingSphere = new BoundingSphere();
            Destroyed = false;
        }

        protected BoundingSphere CalculateBoundingSphere()
        {
            return CalculateModelBoundingSphere(Model);
        }

        public void RenderBoundingSphere(GraphicsDevice graphicsDevice, Matrix view, Matrix projection)
        {
            BoundingSphereRenderer.Render(BoundingSphere, graphicsDevice, view, projection, Color.Red, Color.Green, Color.Blue);
        }

         public Vector3 Position 
         { 
             get
             {
                 return position;
             }

             set
             {
                 Speed = (position - value).Length();
                 position = value;
             }
         }

        protected static BoundingSphere CalculateModelBoundingSphere(Model model)
        {
            BoundingSphere mergedSphere = new BoundingSphere();
            BoundingSphere[] boundingSpheres;
            int index = 0;
            int meshCount = model.Meshes.Count;

            boundingSpheres = new BoundingSphere[meshCount];
            foreach (ModelMesh mesh in model.Meshes)
            {
                boundingSpheres[index++] = mesh.BoundingSphere;
            }

            mergedSphere = boundingSpheres[0];
            if ((model.Meshes.Count) > 1)
            {
                index = 1;
                do
                {
                    mergedSphere = BoundingSphere.CreateMerged(mergedSphere,
                        boundingSpheres[index]);
                    index++;
                } while (index < model.Meshes.Count);
            }
            //mergedSphere.Center.Y = 0;
            return mergedSphere;
        }

        internal void DrawBoundingSphere(Matrix view, Matrix projection, 
            GameObject boundingSphereModel)
        {
            Matrix scaleMatrix = Matrix.CreateScale(BoundingSphere.Radius);
            Matrix translateMatrix = 
                Matrix.CreateTranslation(BoundingSphere.Center);
            Matrix worldMatrix = scaleMatrix * translateMatrix;

            foreach (ModelMesh mesh in boundingSphereModel.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldMatrix;
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }
    }

    class Skybox : GameObject
    {
        public Skybox()
            : base()
        {
            base.Destroyed = false;
        }

        public void LoadContent(ContentManager content, string modelName)
        {
            Model = content.Load<Model>(modelName);
            Position = Vector3.Down;

            //BoundingSphere = CalculateBoundingSphere();

            //BoundingSphere scaledSphere;
            //scaledSphere = BoundingSphere;
            //scaledSphere.Radius *= GameConstants.FuelCellBoundingSphereFactor;
            //BoundingSphere =
            //    new BoundingSphere(scaledSphere.Center, scaledSphere.Radius);
        }

        public void Draw(Matrix view, Matrix projection, GraphicsDevice device)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);
            //Matrix translateMatrix = Matrix.CreateTranslation(Position);
            //Matrix worldMatrix = translateMatrix;
            Matrix scaleMatrix = Matrix.CreateScale(1.5f + Position.Y / GameConstants.MaxRange* 2f);
//            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X) &&  Position != Vector3.Zero)
//                System.Diagnostics.Debugger.Break();
            Vector3 p = Position / -1000f;
            Matrix translateMatrix =
                Matrix.CreateTranslation(p);
            Matrix worldMatrix = Matrix.Identity * scaleMatrix * translateMatrix;
            const float scaleit = 1000f;


            // To position the view matrix at 0,0,0 we can directly modify our current view matrix as follows.
            // The second value can be altered to change the y horizon position of the skybox. Note though that this is not 
            // a simple y value. Experimentation works well here.
            view.M41 = 0; // Position.X / scaleit;
            view.M42 = -Position.Y / (GameConstants.MaxRange * 0.9f);
            view.M43 = 0; // Position.Z / scaleit;

            //  When rendering the skybox we know it is the most distant thing we will draw so we could disable the depth buffer checks and also 
            // the depth buffer writes (see also the advanced note below). Note that disabling depth buffer checks only works if we draw the skybox first. 
            // We also do not want the skybox to be lit (its textures encode lighting), so we turn lighting off. 
            // A further issue is that we want our textures to be clamped to the internal box rather than wrapped else a seam will appear

            // Turn off Z buffer and also change texture wrapping
            //// Save current state first.
            //DepthStencilState dss = new DepthStencilState();
            //dss = device.DepthStencilState;

            //SamplerState ss = new SamplerState();
            //ss = device.SamplerStates[0];

            device.DepthStencilState = DepthStencilState.None;
            device.SamplerStates[0] = SamplerState.LinearClamp;


            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World =
                        worldMatrix * transforms[mesh.ParentBone.Index];
                    effect.View = view;
                    effect.Projection = projection;

                    //effect.EnableDefaultLighting();
                    //effect.PreferPerPixelLighting = true;
                }

                mesh.Draw();

            }

            if (GameConstants.DrawBoundingSpheres)
                RenderBoundingSphere(FuelCellGame.graphics.GraphicsDevice, view, projection);

            // Renable defaults
            //device.DepthStencilState = DepthStencilState.Default;
            
            //device.DepthStencilState = dss;
            device.SamplerStates[0] = SamplerState.LinearWrap;

            //DepthStencilState dss = new DepthStencilState();
            //dss.DepthBufferEnable = true;
            //device.DepthStencilState = dss;

            device.DepthStencilState = DepthStencilState.Default;


        }

        internal bool Update(BoundingSphere thisBoundingSphere)
        {
            return false;
        }


    }

    //class Skybox : GameObject
    //{

    //    private Texture2D[] textures;

    //    public Skybox() 
    //        : base()
    //    {        
    //    }

    //    public void LoadContent(ContentManager content, Effect gameEffect, string modelName)
    //    {
    //        Model = content.Load<Model>(modelName);
    //        Position = Vector3.Down;

    //        Model = content.Load<Model> (modelName);            
    //        textures = new Texture2D[Model.Meshes.Count];
    //        int i = 0;
    //        foreach (ModelMesh mesh in Model.Meshes)
    //            foreach (BasicEffect currentEffect in mesh.Effects)
    //                textures[i++] = currentEffect.Texture;
            
    //        foreach (ModelMesh mesh in Model.Meshes)
    //            foreach (ModelMeshPart meshPart in mesh.MeshParts)
    //                meshPart.Effect = gameEffect.Clone();
    //    }
        
    //}
    
    class FuelCell : GameObject
    {
        public bool Retrieved { get; set; }

        public FuelCell()
            : base()
        {
            Retrieved = false;
        }

        public void LoadContent(ContentManager content, string modelName)
        {
            Model = content.Load<Model>(modelName);
            Position = Vector3.Down;

            BoundingSphere = CalculateBoundingSphere();

            BoundingSphere scaledSphere;
            scaledSphere = BoundingSphere;
            scaledSphere.Radius *= GameConstants.FuelCellBoundingSphereFactor;
            BoundingSphere = 
                new BoundingSphere(scaledSphere.Center, scaledSphere.Radius);
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);
            Matrix translateMatrix = Matrix.CreateTranslation(Position);
            Matrix worldMatrix = translateMatrix;

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = 
                        worldMatrix * transforms[mesh.ParentBone.Index];
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }

            if (GameConstants.DrawBoundingSpheres)
                RenderBoundingSphere(FuelCellGame.graphics.GraphicsDevice, view, projection);
        }

        internal bool Update(BoundingSphere vehicleBoundingSphere)
        {
            if (vehicleBoundingSphere.Intersects(this.BoundingSphere))
                return this.Retrieved = true;

            return false;
        }
    }

    class Barrier : GameObject
    {
        public BarrierTypes BarrierType { get; set; }
        
        public enum BarrierTypes
        {
            none = -1,
            cube = 0,
            pyramid = 1,
            cylinder = 2,
        }

        public const int NumBarrierTypes = 3;


        public Barrier()
            : base()
        {
            BarrierType = BarrierTypes.none;
        }

        // returns true if barrier found that can be removed.
        public static Boolean RemoveBarrier(FuelCarrier fuelCarrier, List<Barrier> barriers, Vector3 Position)
        {
            // Find barrier closest to nominated position.
            Barrier closestBarrier = null;
            float closestDistance = 999999f;

            Vector3 separation;

            foreach (Barrier barrier in barriers)
            {
                if (barrier != null)
                {
                    separation = barrier.Position - Position;
                    if (separation.Length() < closestDistance)
                    {
                        // Found closest barrier.
                        closestDistance = separation.Length();
                        closestBarrier = barrier;
                    }
                }
            }
            if (closestBarrier != null && closestDistance < GameConstants.PlacedCubeOffset)
            {
                // Found a barrier within striking distance so delete it.
                barriers.Remove(closestBarrier);
                return true;
            }

            return false;

        }


        // Returns true if barrier can be added.
        public static Boolean AddBarrier(List<Barrier> barriers, ContentManager Content, Vector3 Position, Barrier.BarrierTypes barrierType, FuelCarrier [] fuelCarriers)
        {

            Barrier thisBarrier;
            Vector3 tempCenter;

            string barrierName = null;

            switch (barrierType)
            {
                case Barrier.BarrierTypes.cube:
                    barrierName = "Models/cube10uR";
                    break;
                case Barrier.BarrierTypes.pyramid:
                    barrierName = "Models/pyramid10uR";
                    break;
                case Barrier.BarrierTypes.cylinder:
                    barrierName = "Models/cylinder10uR";
                    break;
            }

            thisBarrier = new Barrier();
            thisBarrier.BarrierType = barrierType;
            thisBarrier.LoadContent(Content, barrierName);
            thisBarrier.Position = Position;

            //tempCenter = Position;
            tempCenter = Position;
            switch (thisBarrier.BarrierType)
            {
                case (BarrierTypes.pyramid):
                    tempCenter.Y = thisBarrier.BoundingSphere.Radius / 2 + Position.Y;
                    thisBarrier.BoundingSphere = new BoundingSphere(tempCenter,
                        thisBarrier.BoundingSphere.Radius);
                    break;

                case (BarrierTypes.cube):
                    tempCenter.Y = thisBarrier.BoundingSphere.Radius + Position.Y + GameConstants.CubeBoundingSphereHeightOffset;
                    thisBarrier.BoundingSphere = new BoundingSphere(tempCenter,
                        thisBarrier.BoundingSphere.Radius);
                    break;

                default:
                    tempCenter.Y = thisBarrier.BoundingSphere.Radius + Position.Y;
                    thisBarrier.BoundingSphere = new BoundingSphere(tempCenter,
                        thisBarrier.BoundingSphere.Radius);
                    break;
            }
 
            //tempCenter.X = thisBarrier.Position.X;
            //tempCenter.Y = 0;
            //tempCenter.Z = thisBarrier.Position.Z;

            // Check location is not occupied by a fuelcarrier
            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {
                //Check if posiiton of barrier to add is occupied.
                if (fuelCarrier != null && fuelCarrier.BoundingSphere.Intersects(thisBarrier.BoundingSphere))
                {
                    // Error - can't add a barrier here.
                    return false;
                }
            }

            barriers.Add(thisBarrier);
            return true;

        }

        // Recolour or change the effect of a model.
        public static void RemapModel(Model model, Effect effect)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = effect;
                }
            }
        }

        public void LoadContent(ContentManager content, string modelName)
        {
            Model = content.Load<Model>(modelName);
            //BarrierType = modelName;
            Position = Vector3.Down;
            BoundingSphere = CalculateBoundingSphere();

            BoundingSphere scaledSphere;
            scaledSphere = BoundingSphere;
            scaledSphere.Radius *= GameConstants.BarrierBoundingSphereFactor;
            BoundingSphere = 
                new BoundingSphere(scaledSphere.Center, scaledSphere.Radius);
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);
            Matrix translateMatrix = Matrix.CreateTranslation(Position);
            Matrix worldMatrix = translateMatrix;

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = 
                        worldMatrix * transforms[mesh.ParentBone.Index];
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }
            if (GameConstants.DrawBoundingSpheres)
                RenderBoundingSphere(FuelCellGame.graphics.GraphicsDevice, view, projection);
        }


    }


    class Bullet : GameObject
    {
        //Angle in radians.
        public float ForwardDirection { get; set; }
        public float Elevation { get; set; }
        public int MaxRange { get; set; }
        private Matrix orientationMatrix;
        private float BulletSpeed;
        private FuelCarrier ShootingFuelCarrier;
        private Barrier hitBarrier = null;      // The barrier that a bullet has most recently hit (used to avoid hitting barrier again
                                                // as a bullet exits a barrier object during a bounce.

        public static Model baseModel;
        public static BoundingSphere baseBoundingSphere;

        public Bullet()
            : base()
        {
            ForwardDirection = 0.0f;
            MaxRange = GameConstants.MaxRange;
        }

        public Bullet(FuelCarrier shootingFuelCarrier)
            : base()
        {
            ShootingFuelCarrier = shootingFuelCarrier;
            ForwardDirection = shootingFuelCarrier.ForwardDirection;
            Elevation = shootingFuelCarrier.Elevation;
            MaxRange = GameConstants.MaxRange;
            Position = new Vector3(shootingFuelCarrier.Position.X, Math.Max(shootingFuelCarrier.Position.Y + GameConstants.BulletHeight, GameConstants.BulletHeight), shootingFuelCarrier.Position.Z);
            orientationMatrix = Matrix.CreateRotationX(Elevation) * Matrix.CreateRotationY(ForwardDirection);
            //BulletSpeed = GameConstants.BulletStartOffset;
            BulletSpeed = shootingFuelCarrier.Speed + GameConstants.BulletStartOffset;
            FuelCellGame.soundBank.PlayCue("slap");

            if (baseModel != null)
                Model = baseModel;

            if (baseBoundingSphere != null)
            {
                BoundingSphere updatedSphere;
                updatedSphere = baseBoundingSphere;

                updatedSphere.Center = Position;
                BoundingSphere = new BoundingSphere(updatedSphere.Center,
                    updatedSphere.Radius);
            }


        }

        public static void LoadContent(ContentManager content, string modelName)
        {
            baseModel = content.Load<Model>(modelName);
            baseBoundingSphere = CalculateModelBoundingSphere(baseModel);

            BoundingSphere scaledSphere;
            scaledSphere = baseBoundingSphere;
            scaledSphere.Radius *=
                GameConstants.BulletBoundingSphereFactor;
            baseBoundingSphere =
                new BoundingSphere(scaledSphere.Center, scaledSphere.Radius);
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);
            Matrix worldMatrix = Matrix.Identity;
            Matrix rotationYMatrix = Matrix.CreateRotationY(ForwardDirection);
            Matrix translateMatrix = Matrix.CreateTranslation(Position);

            worldMatrix = Matrix.CreateRotationX(Elevation) * rotationYMatrix * translateMatrix;

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World =
                        worldMatrix * transforms[mesh.ParentBone.Index];
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }

            if (GameConstants.DrawBoundingSpheres)
                RenderBoundingSphere(FuelCellGame.graphics.GraphicsDevice, view, projection);

        }

        public void Update(GameTime gameTime, List<Barrier> barriers, List<Bullet> bullets, List<FuelCell> fuelCells, FuelCarrier [] fuelCarriers)
        {
            Vector3 futurePosition = Position;
            Vector3 movement = Vector3.Backward;

            Vector3 speed = Vector3.Transform(movement, orientationMatrix);

            // Use current bullet speed which will start larger than normal so we can offset
            //  to the point outside the center of the firing object.  From then on, reset the speed to
            //  the default speed.
            speed *= BulletSpeed;
            BulletSpeed = GameConstants.BulletSpeed;
            futurePosition = Position + speed;
            if (futurePosition.Y < GameConstants.BulletHeight)
            {
                // Stop bullets going underground.
                Elevation = 0;
                futurePosition.Y = GameConstants.BulletHeight;
            }


            if (ValidateMovement(gameTime, futurePosition, barriers, bullets, fuelCells, fuelCarriers))
            {
                Position = futurePosition;

                BoundingSphere updatedSphere;
                updatedSphere = BoundingSphere;
                updatedSphere.Center = Position;

                //updatedSphere.Center.X = Position.X;
                //updatedSphere.Center.Z = Position.Z;
                BoundingSphere = new BoundingSphere(updatedSphere.Center,
                    updatedSphere.Radius);
            }
        }

        //Returns true if bullet has not been destroyed.
        private bool ValidateMovement(GameTime gameTime, Vector3 futurePosition,
            List<Barrier> barriers, List<Bullet> bullets, List<FuelCell> fuelCells, FuelCarrier [] fuelCarriers)
        {
            BoundingSphere futureBoundingSphere = BoundingSphere;
            futureBoundingSphere.Center = futurePosition;

            //Don't allow off-terrain driving
            if ((Math.Abs(futurePosition.X) > MaxRange) || 
                (Math.Abs(futurePosition.Y) > MaxRange) ||
                (Math.Abs(futurePosition.Z) > MaxRange))
            {
                Destroyed = true;
                return false;
            }

            //Check if bullet hit a barrier
            if (CheckForBarrierCollision(futureBoundingSphere, barriers))
            {
                Destroyed = true;
                FuelCellGame.soundBank.PlayCue("ping");
                return false;
            }

            //Check if bullet hit a fuelcell.
            for (int index = 0; index < fuelCells.Count; index++)
            {
                FuelCell fuelCell = (FuelCell)fuelCells[index];
                if (!fuelCell.Retrieved)
                {
                    if (fuelCell.Update(futureBoundingSphere))
                    {
                        ShootingFuelCarrier.retreivedFuelCells++;
                        FuelCellGame.soundBank.PlayCue("pop1");
                        FuelCellGame.retrievedFuelCells++;
                        fuelCells.RemoveAt(index);
                        Destroyed = true;
                        ShootingFuelCarrier.AddBullets();
                        return false;
                    }
                }
            }

            //Check fuelcarrier impact.
            foreach (FuelCarrier fuelCarrier in fuelCarriers)
            {
                if (!fuelCarrier.Destroyed && futureBoundingSphere.Intersects(fuelCarrier.BoundingSphere))
                {
                    Destroyed = true;
                    fuelCarrier.Destroyed = true;
                    fuelCarrier.unfreezeTime = gameTime.TotalGameTime + TimeSpan.FromSeconds(GameConstants.secondsDestroyedDelay);
                    fuelCarrier.SetFlashDelay(gameTime, GameConstants.secondsFlashDelay);

                    FuelCellGame.soundBank.PlayCue("implosion");
                    fuelCarrier.numTimesDied++;
                    ShootingFuelCarrier.numKills++;

                    return false;
                }
            }

            //Check for bullet hitting a bullet.
            if (CheckForBulletCollision(futureBoundingSphere, bullets))
            {
                FuelCellGame.soundBank.PlayCue("ping");
                Destroyed = true;
                return false;
            }

            return true;

        }
        
        /// <summary>
        /// Checks for a bullet hitting a barrier.
        /// </summary>
        /// <param name="futureBulletBoundingSphere">The bounding sphere of the position the bullet will move to if it hasn't hit anything</param>
        /// <param name="barriers"></param>
        /// <returns>true if bullet has hit barrier and should be destroyed (false if not hit or if bounced off barrier)</returns>
        private bool CheckForBarrierCollision(BoundingSphere futureBulletBoundingSphere, List<Barrier> barriers)
        {
            foreach (Barrier curBarrier in barriers)
            {
                if (curBarrier != hitBarrier)
                {
                    //We've not hit the same barrier we've already most recently hit.
                    if (futureBulletBoundingSphere.Intersects(
                        curBarrier.BoundingSphere))
                    {
                        if (GameConstants.BulletsBounce == false)
                        {
                            //Bullets don't bounce off barriers and we've hit one so
                            // return true to indicate this so we can blow up the bullet
                            // and continue.
                            return true;
                        }
                        else
                        {
                            hitBarrier = curBarrier;
                            Vector3 HitPosition = BoundingSphere.Center - hitBarrier.BoundingSphere.Center;
                            Vector3 Normal = Vector3.Zero;
                            if (hitBarrier.BarrierType == Barrier.BarrierTypes.cylinder)
                            {
                                //Cylinder
                                Normal = HitPosition;
                            }
                            else
                            {
                                //Rectancular
                                if (HitPosition.Z == 0.0f)
                                {
                                    //Avoid division by zero.
                                    if (HitPosition.X > 0.0f)
                                    {
                                        Normal = Vector3.Right;
                                    }
                                    else
                                    {
                                        Normal = Vector3.Left;
                                    }
                                }
                                else
                                {
                                    //Vector3 NormalisedHitPosition = HitPosition;
                                    //NormalisedHitPosition.Normalize();
                                    double HitAngle = MathHelper.ToDegrees((float)Math.Atan(HitPosition.Z / HitPosition.X));
                                    if (HitAngle < 0) HitAngle += 180.0f;
                                    if (HitPosition.Z < 0) HitAngle += 180.0f;
                                    if (HitAngle < 45.0f || HitAngle >= 315.0f)
                                        Normal = Vector3.Right;
                                    else if (HitAngle < 135.0f)
                                        Normal = Vector3.Backward;
                                    else if (HitAngle < 225.0f)
                                        Normal = Vector3.Left;
                                    else
                                        Normal = Vector3.Forward;
                                }
                            }

                            // Worked out normal to use to reflect the bullet so now reflect it.
                            Vector3 CurrentBulletVector = new Vector3((float)Math.Sin((double)ForwardDirection), 0.0f, (float)Math.Cos(ForwardDirection));
                            Vector3 NewBulletVector = Vector3.Reflect(CurrentBulletVector, Normal);

                            if (NewBulletVector.Z == 0.0f)
                            {
                                //Avoid division by zero.
                                if (NewBulletVector.X > 0.0f)
                                {
                                    ForwardDirection = 0.0f;
                                }
                                else
                                {
                                    ForwardDirection = (float)Math.PI;
                                }
                            }
                            else
                            {
                                //ForwardDirection = (float)(Math.Atan(NewBulletVector.Z / NewBulletVector.X));
                                ForwardDirection = CvtXYToAngle(NewBulletVector.Z, NewBulletVector.X);
                                //ForwardDirection = (float)(Math.Acos(NewBulletVector.X));
                                ////if (ForwardDirection < 0) ForwardDirection += (float)Math.PI;
                                //if (NewBulletVector.Z < 0)
                                //    ForwardDirection -= ForwardDirection - MathHelper.Pi;
                            }
                            orientationMatrix = Matrix.CreateRotationY(ForwardDirection);
                        }
                    }
                }
            }
            return false;
        }

        public static float CvtXYToAngle(float x, float y)
        {
            float theta = (float)(Math.Atan2(y, x));
            if (y < 0)
                theta += MathHelper.Pi + MathHelper.Pi;
            return theta;
        }



        /// <summary>
        /// Checks for a bullet hitting a bullet.
        /// </summary>
        /// <param name="objectBoundingSphere"></param>
        /// <param name="bullets"></param>
        /// <returns></returns>
        private bool CheckForBulletCollision(BoundingSphere objectBoundingSphere, List<Bullet> bullets)
        {
            bool hit = false;
            foreach (Bullet bullet in bullets)
            {
                if (bullet != this && 
                    objectBoundingSphere.Intersects(bullet.BoundingSphere))
                {
                    bullet.Destroyed = true;
                    hit = true;
                }
            }

            return hit;
        }

    }

    class FuelCarrier : GameObject
    {
        public float ForwardDirection { get; set; }
        public Boolean allowElevation = false;
        public Boolean allowFlight = false;
        public float Elevation { get; set; }
        public int MaxRange { get; set; }
        private Vector3 StartPosition = Vector3.Zero;
        public int retreivedFuelCells = 0;
        public System.TimeSpan unfreezeTime;
        private TimeSpan flashDelay;
        private bool flashPlayerDrawOn;
        public int numTimesDied;
        public Texture2D texture;
        public int numKills;
        public float turnAcceleration = 0.0f;
        private float turnAmount = 0.0f;
        private float fwdSpeed = 0.0f;
        public int bulletCountRemaining;
        private Keys leftKey;
        private Keys rightKey;
        private Keys forwardKey;
        private Keys backwardKey;
        private Keys fireKey;

        public PlayerIndex playerIndex { get; set; }
        public GamePadState lastGamePadState = new GamePadState();
        public GamePadState currentGamePadState = new GamePadState();

        public Viewport viewport;
        public Camera camera { get; set; }

        public void SetStartPosition(Vector3 p)
        {
            StartPosition = p;
        }

        public FuelCarrier()
            : base()
        {
            ForwardDirection = 0.0f;
            Elevation = 0.0f;
            MaxRange = GameConstants.MaxRange;
        }

        public void AddBullets()
        {
            bulletCountRemaining += GameConstants.ExtraBulletsEarntPerFuelCell;
        }

        public void SetKeyboardControlKeys(Keys thisLeftKey, Keys thisRightKey, Keys thisForwardKey, Keys thisBackwardKey, Keys thisFireKey)
        {
            leftKey = thisLeftKey;
            rightKey = thisRightKey;
            forwardKey = thisForwardKey;
            backwardKey = thisBackwardKey;
            fireKey = thisFireKey;
        }


        public void LoadContent(ContentManager content, string modelName)
        {
            Model = content.Load<Model>(modelName);
            BoundingSphere = CalculateBoundingSphere();

            BoundingSphere scaledSphere;
            scaledSphere = BoundingSphere;
            scaledSphere.Radius *= 
                GameConstants.FuelCarrierBoundingSphereFactor;
            scaledSphere.Center.Y += GameConstants.FuelCarrierBoundingSphereHeightOffset;
            BoundingSphere = 
                new BoundingSphere(scaledSphere.Center, scaledSphere.Radius);
        }

        internal void Reset()
        {
            Position = StartPosition;
            ForwardDirection = 0f;
            retreivedFuelCells = 0;
            numTimesDied = 0;
            numKills = 0;
            turnAmount = 0;
            Elevation = 0;
            bulletCountRemaining = GameConstants.StartBulletCountPerPlayer;

            BoundingSphere updatedSphere;
            updatedSphere = BoundingSphere;

            updatedSphere.Center = Position;
            updatedSphere.Center.Y += GameConstants.FuelCarrierBoundingSphereHeightOffset;
            BoundingSphere = new BoundingSphere(updatedSphere.Center,
                updatedSphere.Radius);
        }
        
        /// <summary>
        /// Returns true if this fuelcarrier has been destroyed and should
        /// momentarily not be displayed to make the player flash.
        /// </summary>
        /// <returns></returns>
        public bool DestroyFlashDelay(GameTime gameTime)
        {
            if (!Destroyed)
                return false;

            if (gameTime.TotalGameTime >= flashDelay)
            {
                flashDelay = TimeSpan.FromSeconds(GameConstants.secondsFlashDelay) + gameTime.TotalGameTime;
                flashPlayerDrawOn ^= true;
            }
            return !flashPlayerDrawOn;
        }


        public void SetFlashDelay(GameTime gameTime, double secondsFlashDelay)
        {
            flashDelay = TimeSpan.FromSeconds(secondsFlashDelay) + gameTime.TotalGameTime;
            flashPlayerDrawOn = false;
        }


        public void Draw(GameTime gameTime, Matrix view, Matrix projection)
        {
            if (DestroyFlashDelay(gameTime))
                return;

            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);
            Matrix worldMatrix = Matrix.Identity;
            Matrix rotationYMatrix = Matrix.CreateRotationY(ForwardDirection);
            Matrix rotationXMatrix = Matrix.CreateRotationX(Elevation);
            Matrix translateMatrix = Matrix.CreateTranslation(Position);

            worldMatrix = rotationXMatrix * rotationYMatrix * translateMatrix;

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = 
                        worldMatrix * transforms[mesh.ParentBone.Index];
                    effect.View = view;
                    effect.Projection = projection;
                    effect.Texture = texture;
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }
            if (GameConstants.DrawBoundingSpheres)
                RenderBoundingSphere(FuelCellGame.graphics.GraphicsDevice, view, projection);
        }

        public Vector3 GetDirection()
        {

            Matrix orientationMatrix = Matrix.CreateRotationX(Elevation) * Matrix.CreateRotationY(ForwardDirection);

            Vector3 direction = Vector3.Transform(Vector3.Backward, orientationMatrix);

            return direction;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, KeyboardState lastKeyboardState, List<Barrier> barriers, List<Bullet> bullets, FuelCarrier [] fuelCarriers)
        {
            Vector3 futurePosition = Position;
            Vector3 movement = Vector3.Zero;
            Matrix orientationMatrix;
            bool disableThisPlayerMovement = false;
            //float turnAmount = 0;

            if (Destroyed)
            {
                if (gameTime.TotalGameTime >= (unfreezeTime - TimeSpan.FromSeconds(GameConstants.secondsVibrateAdjust )) )
                    GamePad.SetVibration(playerIndex, 0.0f, 0.0f);
                else
                    GamePad.SetVibration(playerIndex, .5f, .5f);

                //Disable all controls until defined time interval has elapsed.
                if (gameTime.TotalGameTime >= unfreezeTime)
                {
                    Destroyed = false;
                } else 
                {
                    //Delay not yet elapsed so disable player movement.
                    disableThisPlayerMovement = true;
                }
            }

            // Left keyboard key prssed
            if (keyboardState.IsKeyDown(leftKey))
            {
                //turnAmount = 2;
                //if (turnAmount < 0 && !GameConstants.zeroGMovementMode)
                if (turnAmount < 0)
                    // We were previously turning right and not zero G mode so reset to just beginning to turn left.
                    turnAmount = 1;
                else
                    // Increase left turn rate.
                    turnAmount++;
            }
            // Right keyboard key prssed
            else if (keyboardState.IsKeyDown(rightKey))
            {
                //turnAmount = -2;
                //if (turnAmount > 0 && !GameConstants.zeroGMovementMode)
                if (turnAmount > 0)
                    // We were previously turning left and not zero G mode so reset to just beginning to turn right.
                    turnAmount = -1;
                else
                    // Increase right turn rate.
                    turnAmount--;
            }

            //                else if (gamepadState.ThumbSticks.Left.X > GameConstants.ThumbstickMinRegistrationVal || gamepadState.ThumbSticks.Left.X < -gamepadState.ThumbSticks.Left.X)
            else if (currentGamePadState.IsConnected)
            {
                float ThumbstickVal = currentGamePadState.ThumbSticks.Right.X;
                if (ThumbstickVal == 0)
                    turnAmount = 0;
                else
                {
                    //if (ThumbstickVal < 0)
                    //{
                    //    if (ThumbstickVal > -GameConstants.ThumbstickSmallIncrementThreshhold)
                    //    {
                    //        ThumbstickVal = -GameConstants.ThumbstickSmallIncrementVal;
                    //        //                            ThumbstickVal *= ThumbstickVal * ThumbstickVal;
                    //    }
                    //}
                    //else
                    //{
                    //    if (ThumbstickVal < GameConstants.ThumbstickSmallIncrementThreshhold)
                    //        ThumbstickVal = GameConstants.ThumbstickSmallIncrementVal;
                    //}
                    turnAmount = -ThumbstickVal * GameConstants.ThumbstickXMultiplier;
                    //turnAmount = -currentGamePadState.ThumbSticks.Right.X * Math.Abs(currentGamePadState.ThumbSticks.Right.X) * GameConstants.ThumbstickXMultiplier;
                    if (currentGamePadState.IsButtonDown(Buttons.LeftTrigger))
                        turnAmount /= GameConstants.ScopedGamepadTurnFactor;
                }
            }
            else //// if (!GameConstants.zeroGMovementMode)
            {
                if (turnAmount > 0)
                    // Slow down left turn rate when key not being pressed
                    turnAmount -= 2;
                else if (turnAmount < 0)
                    // Slow down right turn rate when key not being pressed
                    turnAmount += 2;
            }

            if (!disableThisPlayerMovement)
            {
                if (keyboardState.IsKeyDown(fireKey) && !lastKeyboardState.IsKeyDown(fireKey) ||
                    (currentGamePadState.Triggers.Right != 0 && lastGamePadState.Triggers.Right == 0))
                {
                    if (bulletCountRemaining > 0)
                    {
                        // Create bullet and subtract one from player's bullet count.
                        bullets.Add(new Bullet(this));
                        --bulletCountRemaining;
                    }
                }

                if (keyboardState.IsKeyDown(forwardKey))
                {
                    if (GameConstants.zeroGMovementMode)
                    {
                        fwdSpeed += GameConstants.ZeroGModeFwdInc;
                        if (fwdSpeed >= GameConstants.MaxFwdSpeedInZeroGMode)
                            fwdSpeed = GameConstants.MaxFwdSpeedInZeroGMode;
                    }
                    else
                        fwdSpeed = 1;
                }
                else 
                {
                    if (keyboardState.IsKeyDown(backwardKey))
                    {
                        if (GameConstants.zeroGMovementMode)
                        {
                            fwdSpeed -= GameConstants.ZeroGModeFwdInc;
                            if (fwdSpeed <= -GameConstants.MaxFwdSpeedInZeroGMode)
                                fwdSpeed = -GameConstants.MaxFwdSpeedInZeroGMode;
                        }
                        else
                            fwdSpeed = -1;
                    }
                }
                //else if (gamepadState.ThumbSticks.Right.Y != 0)
                //{
                //    movement.Z = gamepadState.ThumbSticks.Right.Y * GameConstants.ThumbstickYMultiplier;
                //}
            }

            movement.Z = fwdSpeed;

            if (turnAmount < -GameConstants.MaxTurnAmount)
                turnAmount = -GameConstants.MaxTurnAmount;
            else
                if (turnAmount > GameConstants.MaxTurnAmount)
                    turnAmount = GameConstants.MaxTurnAmount;

            //if (gamepadState.Buttons.A == ButtonState.Pressed)
            //    turnAmount = turnAmount;

            if (currentGamePadState.IsConnected)
            {
                if (currentGamePadState.IsButtonDown(Buttons.RightShoulder))
                {
                    System.Diagnostics.Debugger.Break();
                }
                // We've a gamepad operating 
                //// If turn amount has been reduced to a decimal below 1 then zero it to avoid creep.
                //if (Math.Abs(turnAmount) < GameConstants.ThumbstickMinRegistrationVal)
                //{
                //    turnAmount = 0;
                //}
                // Use the left hand ThumbStick to move the player.
                if (!disableThisPlayerMovement)
                {
                    if (GameConstants.allowSidewaysGamePadMovement)
                    {
                        movement.X = -currentGamePadState.ThumbSticks.Left.X * GameConstants.ThumbstickSidewaysMultiplier;
                    }
                    movement.Z = currentGamePadState.ThumbSticks.Left.Y * GameConstants.ThumbstickYMultiplier;
                }
                if (allowElevation)
                {
                    //if (currentGamePadState.IsButtonDown(Buttons.RightShoulder) )
                    //{
                    //    int i = 1;
                    //    i = i+2;
                    //}
                    Elevation += -currentGamePadState.ThumbSticks.Right.Y * GameConstants.ElevationMultiplier;
                    
                    // Ensure we don't rotate beyond 90 degrees elevation up or down.
                    if (Elevation >= MathHelper.PiOver2 - 0.3f)
                        Elevation = MathHelper.PiOver2 - 0.31f;

                    if (Elevation <= -MathHelper.PiOver2)
                        Elevation = -MathHelper.PiOver2 + 0.001f;

                }
            }

            ForwardDirection += turnAmount * GameConstants.TurnSpeed;
            orientationMatrix = Matrix.CreateRotationX(Elevation) * Matrix.CreateRotationY(ForwardDirection);

            Vector3 speed = Vector3.Transform(movement, orientationMatrix);
            speed *= GameConstants.Velocity;
            futurePosition = Position + speed;

            if (!GameConstants.AllowUndergroundDriving && futurePosition.Y < 0)
            {
                // Don't allow going underground.
                futurePosition.Y = 0;
                Elevation = 0;
            }

            if (!allowFlight)
                // Don't allow flight.
                futurePosition.Y = 0;

            if (ValidateMovement(futurePosition, barriers, fuelCarriers))
            {
                Position = futurePosition;

                BoundingSphere updatedSphere;
                updatedSphere = BoundingSphere;

                updatedSphere.Center.X = Position.X;
                updatedSphere.Center.Z = Position.Z;
                updatedSphere.Center.Y = Position.Y + GameConstants.FuelCarrierBoundingSphereHeightOffset;

                BoundingSphere = new BoundingSphere(updatedSphere.Center, 
                    updatedSphere.Radius);
            }
        }


// Returns true of valid movement, false if hitting a barrier or other fuel carrier.
        private bool ValidateMovement(Vector3 futurePosition, List<Barrier> barriers, FuelCarrier [] fuelCarriers)
        {
            BoundingSphere futureBoundingSphere = BoundingSphere;
            futureBoundingSphere.Center= futurePosition;

//            if (this == otherFuelCarrier)
//                throw new Exception(@"ValidateMovement() called with object ref equal to otherFuelCarrier");

            //Don't allow off-terrain driving
            if ((Math.Abs(futurePosition.X) > MaxRange) ||
                (Math.Abs(futurePosition.Y) > MaxRange) ||
                (Math.Abs(futurePosition.Z) > MaxRange))
                return false;

            //Don't allow driving through a barrier
            if (CheckForBarrierCollision(futureBoundingSphere, barriers))
                return false;
            
            //Don't allow driving through another player's fuelcarrier.
            foreach (FuelCarrier otherFuelCarrier in fuelCarriers)
            {
                if (!this.Equals(otherFuelCarrier))
                {
                    // We are not check for a collision with "ourself".
                    if (this.BoundingSphere.Intersects(otherFuelCarrier.BoundingSphere))
                    {
                        // We are driving through another carrier.
                        if (Math.Abs((this.BoundingSphere.Center - otherFuelCarrier.BoundingSphere.Center).Length())
                                >=
                                Math.Abs((futureBoundingSphere.Center - otherFuelCarrier.BoundingSphere.Center).Length()))
                        {
                            // ... and movement is toward the blocking fuel carrier so deny movement.
                            return false;
                        }
                    }
                }
            }   

            // No problem with movement so allow it.
            return true;

        }

        private bool CheckForBarrierCollision(BoundingSphere futureVehicleBoundingSphere, List<Barrier> barriers)
        {
            foreach (Barrier barrier in barriers)
            {
                if (futureVehicleBoundingSphere.Intersects(barrier.BoundingSphere))
                {
                    // We are driving through a barrier.
                    if (Math.Abs((futureVehicleBoundingSphere.Center - barrier.BoundingSphere.Center).Length())
                            >=
                            Math.Abs((futureVehicleBoundingSphere.Center - barrier.BoundingSphere.Center).Length()))
                    {
                        // ... and movement is toward the blocking barrier so this is a collision.
                        return true;
                    }
                }
            }

            // No collision.
            return false;
        }
    }

    class Camera
    {
        public Vector3 AvatarHeadOffset { get; set; }
        public Vector3 TargetOffset { get; set; }
        public Matrix ViewMatrix { get; set; }
        public Matrix ProjectionMatrix { get; set; }

        float viewangle;
        float aspectratio;

        public Camera()
        {
            AvatarHeadOffset = new Vector3(0, 7, -15);  //0 7 -15
            TargetOffset = new Vector3(0, 4, 0);//0 5 0
            ViewMatrix = Matrix.Identity;
            ProjectionMatrix = Matrix.Identity;
        }

        public void DrawBoundingFrustrum()
        {
            DrawBoundingFrustrum(0f, Color.Green);
        }

        /// <summary>
        /// Draw the BoundingFrustrum represented by this camera object using the DebugShapeRenderer class.
        /// </summary>
        /// <param name="life">The life time that the shape should be rendered for in seconds (0 means for one frame only)</param>
        public void DrawBoundingFrustrum(float life, Color thisColor)
        {
            // Create our frustum to simulate a camera view.
            //Matrix newProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            //        MathHelper.ToRadians(viewangle), aspectratio,
            //        GameConstants.NearClip, GameConstants.FarClip/10);

            //Matrix newViewMatrix =
            //        Matrix.CreateLookAt(Vector3.Zero, new Vector3(5f,5f,5f), Vector3.Up);


            //BoundingFrustum frustum = new BoundingFrustum(newViewMatrix * newProjectionMatrix);
            BoundingFrustum frustum = new BoundingFrustum(ViewMatrix * ProjectionMatrix);
            DebugShapeRenderer.AddBoundingFrustum(frustum, thisColor, life);
            //DebugShapeRenderer.AddBoundingFrustum(frustum, Color.Green, life);
        }

        public void Update(float avatarYaw, float avatarPitch, Vector3 position, float aspectRatio, float viewAngle)
        {
            Matrix rotationMatrix = Matrix.CreateRotationX(avatarPitch) * Matrix.CreateRotationY(avatarYaw);

            Vector3 transformedheadOffset = 
                Vector3.Transform(AvatarHeadOffset, rotationMatrix);
            Vector3 transformedReference = 
                Vector3.Transform(TargetOffset, rotationMatrix);

            Vector3 cameraPosition = position + transformedheadOffset;
            Vector3 cameraTarget = position + transformedReference;

            //Calculate the camera's view and projection
            // matrices based on current values.
            ViewMatrix = 
                Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            ProjectionMatrix = 
                Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.ToRadians(viewAngle), aspectRatio, 
                    GameConstants.NearClip, GameConstants.FarClip);

            //DrawBoundingFrustrum();
            viewangle = viewAngle;
            aspectratio = aspectRatio;
        }
    }
}


/// <summary>
/// Provides a set of methods for rendering BoundingSpheres.
/// </summary>
public static class BoundingSphereRenderer
{
    static VertexBuffer vertBuffer;
    static VertexDeclaration vertDecl;
    static BasicEffect effect;
    static int sphereResolution;

    /// <summary>
    /// Initializes the graphics objects for rendering the spheres. If this method isn't
    /// run manually, it will be called the first time you render a sphere.
    /// </summary>
    /// <param name="graphicsDevice">The graphics device to use when rendering.</param>
    /// <param name="sphereResolution">The number of line segments
    ///     to use for each of the three circles.</param>
    public static void InitializeGraphics(GraphicsDevice graphicsDevice, int sphereResolution)
    {
        BoundingSphereRenderer.sphereResolution = sphereResolution;

        //vertDecl = new VertexDeclaration(
        effect = new BasicEffect(graphicsDevice);
        effect.LightingEnabled = false;
        effect.VertexColorEnabled = false;

        VertexPositionColor[] verts = new VertexPositionColor[(sphereResolution + 1) * 3];

        int index = 0;

        float step = MathHelper.TwoPi / (float)sphereResolution;

        //create the loop on the XY plane first
        for (float a = 0f; a <= MathHelper.TwoPi; a += step)
        {
            verts[index++] = new VertexPositionColor(
                new Vector3((float)Math.Cos(a), (float)Math.Sin(a), 0f),
                Color.White);
        }

        //next on the XZ plane
        for (float a = 0f; a <= MathHelper.TwoPi; a += step)
        {
            verts[index++] = new VertexPositionColor(
                new Vector3((float)Math.Cos(a), 0f, (float)Math.Sin(a)),
                Color.White);
        }

        //finally on the YZ plane
        for (float a = 0f; a <= MathHelper.TwoPi; a += step)
        {
            verts[index++] = new VertexPositionColor(
                new Vector3(0f, (float)Math.Cos(a), (float)Math.Sin(a)),
                Color.White);
        }

        vertBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
        vertBuffer.SetData(verts);
    }

    /// <summary>
    /// Renders a bounding sphere using different colors for each axis.
    /// </summary>
    /// <param name="sphere">The sphere to render.</param>
    /// <param name="graphicsDevice">The graphics device to use when rendering.</param>
    /// <param name="view">The current view matrix.</param>
    /// <param name="projection">The current projection matrix.</param>
    /// <param name="xyColor">The color for the XY circle.</param>
    /// <param name="xzColor">The color for the XZ circle.</param>
    /// <param name="yzColor">The color for the YZ circle.</param>
    public static void Render(
        BoundingSphere sphere,
        GraphicsDevice graphicsDevice,
        Matrix view,
        Matrix projection,
        Color xyColor,
        Color xzColor,
        Color yzColor)
    {
        if (vertBuffer == null)
            InitializeGraphics(graphicsDevice, 30);

        graphicsDevice.SetVertexBuffer(vertBuffer);

        effect.World =
            Matrix.CreateScale(sphere.Radius) *
            Matrix.CreateTranslation(sphere.Center);
        effect.View = view;
        effect.Projection = projection;
        effect.DiffuseColor = xyColor.ToVector3();

        foreach (EffectPass pass in effect.CurrentTechnique.Passes)
        {
            pass.Apply();

            //render each circle individually
            graphicsDevice.DrawPrimitives(
                  PrimitiveType.LineStrip,
                  0,
                  sphereResolution);
            pass.Apply();
            effect.DiffuseColor = xzColor.ToVector3();
            graphicsDevice.DrawPrimitives(
                  PrimitiveType.LineStrip,
                  sphereResolution + 1,
                  sphereResolution);
            pass.Apply();
            effect.DiffuseColor = yzColor.ToVector3();
            graphicsDevice.DrawPrimitives(
                  PrimitiveType.LineStrip,
                  (sphereResolution + 1) * 2,
                  sphereResolution);
            pass.Apply();

        }

    }

    public static void Render(BoundingSphere[] spheres,
       GraphicsDevice graphicsDevice,
       Matrix view,
       Matrix projection,
       Color xyColor,
        Color xzColor,
        Color yzColor)
    {
        foreach (BoundingSphere sphere in spheres)
        {
            Render(sphere, graphicsDevice, view, projection, xyColor, xzColor, yzColor);
        }
    }

    public static void Render(BoundingSphere[] spheres,
        GraphicsDevice graphicsDevice,
        Matrix view,
        Matrix projection,
        Color color)
    {
        foreach (BoundingSphere sphere in spheres)
        {
            Render(sphere, graphicsDevice, view, projection, color);
        }
    }

    /// <summary>
    /// Renders a bounding sphere using a single color for all three axis.
    /// </summary>
    /// <param name="sphere">The sphere to render.</param>
    /// <param name="graphicsDevice">The graphics device to use when rendering.</param>
    /// <param name="view">The current view matrix.</param>
    /// <param name="projection">The current projection matrix.</param>
    /// <param name="color">The color to use for rendering the circles.</param>
    public static void Render(
        BoundingSphere sphere,
        GraphicsDevice graphicsDevice,
        Matrix view,
        Matrix projection,
        Color color)
    {
        if (vertBuffer == null)
            InitializeGraphics(graphicsDevice, 30);

        graphicsDevice.SetVertexBuffer(vertBuffer);

        effect.World =
              Matrix.CreateScale(sphere.Radius) *
              Matrix.CreateTranslation(sphere.Center);
        effect.View = view;
        effect.Projection = projection;
        effect.DiffuseColor = color.ToVector3();

        foreach (EffectPass pass in effect.CurrentTechnique.Passes)
        {
            pass.Apply();

            //render each circle individually
            graphicsDevice.DrawPrimitives(
                  PrimitiveType.LineStrip,
                  0,
                  sphereResolution);
            graphicsDevice.DrawPrimitives(
                  PrimitiveType.LineStrip,
                  sphereResolution + 1,
                  sphereResolution);
            graphicsDevice.DrawPrimitives(
                  PrimitiveType.LineStrip,
                  (sphereResolution + 1) * 2,
                  sphereResolution);

        }

    }
}