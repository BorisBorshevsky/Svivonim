using Dreidels.ObjectModel.Services;
using Infrastructure.ObjectModel;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Infrastructure.Managers
{
    public class CameraManager : GameService , ICameraManager

    {
        private const float k_NearPlaneDistance = 0.5f;
        private const float k_FarPlaneDistance = 500.0f;
        private const float k_ViewAngle = MathHelper.PiOver4;
        private const float k_MovementSpeed = 20;

        readonly Vector3 r_CameraLooksAt = Vector3.Zero;
        readonly Vector3 r_CameraUpDirection = new Vector3(0, 1, 0);
        private IInputManager m_InputManager;

        Vector3 m_CameraLocation = new Vector3(0, 0, -40);
        
        public CameraManager(Game i_Game)
            : base(i_Game)
        {
        }

        public override void Initialize()
        {
            m_InputManager = Game.Services.GetService<IInputManager>();
            SetCameraSettings();
            SetCameraState();
            base.Initialize();
        }

        protected override void RegisterAsService()
        {
            Game.Services.AddService(typeof(ICameraManager), this);
        }

        public Matrix CameraSettings { get; private set; }
        public Matrix CameraState { get; private set; }

        public void SetCameraSettings()
        {
            CameraSettings = Matrix.CreatePerspectiveFieldOfView(k_ViewAngle,Game.GraphicsDevice.Viewport.AspectRatio,k_NearPlaneDistance,k_FarPlaneDistance);
        }

        public override void Update(GameTime i_GameTime)
        {
            if (m_InputManager.KeyHeld(Keys.Left))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X - i_GameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed), m_CameraLocation.Y, m_CameraLocation.Z);
            }

            if (m_InputManager.KeyHeld(Keys.Right))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X + i_GameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed), m_CameraLocation.Y, m_CameraLocation.Z);
            }

            if (m_InputManager.KeyHeld(Keys.Up))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X), m_CameraLocation.Y, (float)(m_CameraLocation.Z + i_GameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed));
            }

            if (m_InputManager.KeyHeld(Keys.Down))
            {
                m_CameraLocation = new Vector3((float)(m_CameraLocation.X), m_CameraLocation.Y, (float)(m_CameraLocation.Z - i_GameTime.ElapsedGameTime.TotalSeconds * k_MovementSpeed));
            }

            SetCameraState();
        }

        public void SetCameraState()
        {
            CameraState = Matrix.CreateLookAt(m_CameraLocation, r_CameraLooksAt, r_CameraUpDirection);
        }

    }
}
