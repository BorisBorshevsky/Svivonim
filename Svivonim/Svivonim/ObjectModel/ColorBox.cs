using System.Collections.Generic;
using System.Linq;
using Dreidels.ObjectModel.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class ColorBox : Box
    {
        public ColorBox(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            ((Base3DElement) this).Position = i_Position;
        }

        public override void Initialize()
        {

            base.Initialize();
            m_CameraManager = Game.Services.GetService<CameraManager>();
        }

        protected override void LoadContent()
        {
            m_BasicEffect = new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.VertexColorEnabled = true;

            m_VerticesCoordinates = createStartCoordinates();

            m_Vertices = new List<VertexPositionColor>();
 
            createWalls();
            createHeiLetter();
            createNonLetter();
            createPeiLetter();
            createGimel();
        }

        private void createHeiLetter() // BACK
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, -0.3f), Color.Black));
                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, -0.3f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0, -0.3f), Color.Black));
                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.3f, -0.5f), Color.Black));
                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.3f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.3f, 0.5f), Color.Black));
                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, 0.3f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.3f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, 0.5f), Color.Black));
                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.3f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.5f), Color.Black));
        }

        private void createNonLetter() //LEFT
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3( -0.3f, -0.2f, 1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.2f, 1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3( -0.3f, -0.5f, 1.001f), Color.Black));
                                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3( -0.3f, -0.5f, 1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.2f, 1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.5f, 1.001f), Color.Black));
                                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3( 0.3f , -0.5f, 1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.3f  , 0.5f,  1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.5f, 1.001f), Color.Black));
                                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.5f, 1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.3f  , 0.5f,  1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.5f,  1.001f), Color.Black));
                                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(0     , 0.5f,  1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.5f,  1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0     , 0.2f,  1.001f), Color.Black));
                                                                               
            m_Vertices.Add(new VertexPositionColor(new Vector3(0     , 0.2f,  1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.5f,  1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.2f,  1.001f), Color.Black));
        }



        private void createPeiLetter() //FRONT - GOOOOOD
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.15f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0, 0.15f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.15f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.15f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0, 0.15f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0, -0.15f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.15f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.2f, -0.65f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.2f, -0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.15f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.2f, 0.15f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.35f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.35f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.65f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.35f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.65f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, -0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, 0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.65f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, 0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.65f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.35f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.35f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.65f, -1.001f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.65f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.35f, -1.001f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.65f, -1.001f), Color.Black));
        }

        private void createGimel() //left - GOOOD
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.35f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.35f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.5f), Color.Black));            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.35f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, 0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.15f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.15f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, -0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, -0.5f), Color.Black));            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.15f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, -0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, -0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, 0.2f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, 0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.2f), Color.Black));
        }

        private void createWalls()
        {
            //front - PEI
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.Blue));
            
            //back Nun
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Yellow));

            //left - Gimel
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.GreenYellow));

            //right -- Hei
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Red));
        }

        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.Projection = m_CameraManager.CameraSettings;
            m_BasicEffect.View = m_CameraManager.CameraState;
            m_BasicEffect.World = m_WorldMatrix;

            foreach (EffectPass pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, m_Vertices.ToArray(), 0, m_Vertices.Count / 3);
            }

            base.Draw(i_GameTime);
        }

        public List<VertexPositionColor> m_Vertices { get; set; }
    }
}