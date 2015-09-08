using System;
using Infrastructure.Managers;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Svivonim.ObjectModel;

namespace Svivonim
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DradelGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public BasicEffect Effect { get; private set; }
        private RasterizerState m_RasterizerState = new RasterizerState();
        private CameraManager m_CameraManager;
        private IInputManager m_InputManager;


        public DradelGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            m_CameraManager = new CameraManager(this);
            m_InputManager = new InputManager(this);

            var a = new TextureBox(this, Vector3.Zero);

            Components.Add(a);


            var b = new Pyramid(this);

            Components.Add(b);
        }

        protected override void Initialize()
        {
            m_CameraManager.SetCameraSettings();
            m_CameraManager.SetCameraState();


     



//            a = new SimpleTriangle(this, new Vector3(5, 0, 5));
//           var  b = new Dradel(this);
//           b.Initialize();

//            Components.Add(a);
//            Components.Add(b);

            m_RasterizerState.CullMode = CullMode.None;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
//            Effect.View = m_CameraManager.CameraState;
//            Effect.Projection = m_CameraManager.CameraSettings;
//            Effect.GraphicsDevice.RasterizerState = m_RasterizerState;

            base.Draw(gameTime);
        }
    }
}
