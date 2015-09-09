using Dreidels.ObjectModel;
using Infrastructure.Managers;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;

namespace Dreidels
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DreidelsGame : Game
    {
        GraphicsDeviceManager graphics;


        private readonly CameraManager r_CameraManager;
        private IInputManager m_InputManager;
        private GameLogic r_GameLogic;


        public DreidelsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //initialize services
            r_CameraManager = new CameraManager(this);
            m_InputManager = new InputManager(this);

            r_GameLogic = new GameLogic(this);

        }

        protected override void Initialize()
        {
            r_CameraManager.SetCameraSettings();
            r_CameraManager.SetCameraState();

            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            base.Draw(gameTime);
        }
    }
}
