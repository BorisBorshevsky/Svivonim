using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.ObjectModel;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Svivonim.ObjectModel
{
    class CameraManager : GameService
    {
        float k_NearPlaneDistance = 0.5f;
        float k_FarPlaneDistance = 1000.0f;
        float k_ViewAngle = MathHelper.PiOver4;
        private float k_MovementSpeed = 20;

        
        public CameraManager(Game i_Game)
            : base(i_Game)
        {
        }

        public override void Initialize()
        {
            m_InputManager = Game.Services.GetService<IInputManager>();
            base.Initialize();
        }

        protected override void RegisterAsService()
        {
            Game.Services.AddService(typeof(CameraManager), this);
        }

        public Matrix CameraSettings { get; private set; }
        public Matrix CameraState { get; private set; }

        public void SetCameraSettings()
        {
            // we are storing the camera settings data in a matrix:
            CameraSettings = Matrix.CreatePerspectiveFieldOfView(k_ViewAngle,Game.GraphicsDevice.Viewport.AspectRatio,k_NearPlaneDistance,k_FarPlaneDistance);
        }

        // we want to look at the center of the 3D world:
        Vector3 m_CameraLooksAt = Vector3.Zero;
        // we are standing 80 units in front of our target:
        Vector3 m_CameraLocation = new Vector3(10, 0, 0);
        // the camera stands straight:
        Vector3 m_CameraUpDirection = new Vector3(0, 1, 0);
        private IInputManager m_InputManager;

        public override void Update(GameTime gameTime)
        {
            if (m_InputManager.KeyHeld(Keys.Left))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X - gameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed), m_CameraLocation.Y, m_CameraLocation.Z);
            }

            if (m_InputManager.KeyHeld(Keys.Right))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X + gameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed), m_CameraLocation.Y, m_CameraLocation.Z);
            }

            if (m_InputManager.KeyHeld(Keys.OemPlus))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X), m_CameraLocation.Y, (float)(m_CameraLocation.Z + gameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed));
            }

            if (m_InputManager.KeyHeld(Keys.OemMinus))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X), m_CameraLocation.Y, (float)(m_CameraLocation.Z - gameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed));
            }

            if (m_InputManager.KeyHeld(Keys.Up))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X), (float)(m_CameraLocation.Y - gameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed), m_CameraLocation.Z);
            }

            if (m_InputManager.KeyHeld(Keys.Down))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X), (float)(m_CameraLocation.Y + gameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed), m_CameraLocation.Z);
            }


            SetCameraState();
        }

        public void SetCameraState()
        {
            // we are storing the camera state data in a matrix:
            CameraState = Matrix.CreateLookAt(m_CameraLocation, m_CameraLooksAt, m_CameraUpDirection);
        }

    }
}
