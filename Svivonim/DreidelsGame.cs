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
        GraphicsDeviceManager m_Graphics;
        private readonly ICameraManager r_CameraManager;
        private IInputManager m_InputManager;
        private GameLogic m_GameLogic;

        public DreidelsGame()
        {
            m_Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //initialize services
            r_CameraManager = new CameraManager(this);
            m_InputManager = new InputManager(this);

            m_GameLogic = new GameLogic(this);
        }

        protected override void Draw(GameTime i_GameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            base.Draw(i_GameTime);
        }
    }
}