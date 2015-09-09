using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class ColorBox : Box
    {
        private Texture2D m_Texture;
        private short[] m_Indices;
        private VertexPositionTexture[] m_TextureVertices;
     
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
 
            CreateWalls();
            createHeiLetter();
            createNonLetter();
            createPeiLetter();
            createGimel();
        }

        private void createHeiLetter()
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.25f, -0.5f, 1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.25f, -0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.25f, 0, 1f), Color.Black));
                      
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.25f, 1f), Color.Black));
                      
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.25f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.25f, 1f), Color.Black));
                      
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.25f, -0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.25f, 0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.5f, 1f), Color.Black));
                      
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.25f, 0.5f, 1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.5f, 1f), Color.Black));
        }

        private void createNonLetter()
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.25f, 0.25f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.25f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.5f, 0.25f), Color.Black));
            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.5f, 0.25f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.25f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.5f, -0.5f), Color.Black));
            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.5f, -0.25f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.5f, -0.25f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.5f, -0.5f), Color.Black));
            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, -0.5f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.5f, -0.25f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.5f, -0.5f), Color.Black));
            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.5f, 0), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.5f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.25f, 0), Color.Black));
            
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.25f, 0), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.5f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(1f, 0.25f, -0.5f), Color.Black));
        }

        private void createPeiLetter()
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.1f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0, 0.1f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.1f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.1f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0, 0.1f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0, -0.1f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.1f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.2f, -0.6f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.2f, -0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.1f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.2f, 0.1f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.3f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.3f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.6f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.3f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.6f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, -0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, 0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.6f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, 0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.6f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.3f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.3f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.6f, -1f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.6f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.3f, -1f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.6f, -1f), Color.Black));
        }

        private void createGimel()
        {
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.3f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.3f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.6f, 0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.6f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.3f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.6f, -0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.1f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.1f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.1f, 0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.1f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.1f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.1f, -0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.6f, 0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.6f, 0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.6f, 0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.6f, 0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.6f, 0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.6f, 0.5f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.6f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.1f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.6f, -0.2f), Color.Black));

            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, -0.6f, -0.2f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.1f, -0.5f), Color.Black));
            m_Vertices.Add(new VertexPositionColor(new Vector3(-1f, 0.1f, -0.2f), Color.Black));
        }

        private void CreateWalls()
        {
            //front
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.Yellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.Yellow));
            
            //back
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.Blue));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Blue));

            //left
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.GreenYellow));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.GreenYellow));

            //right
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Red));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Red));

            //top
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.White));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.White));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.White));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.White));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.White));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.White));

            //bottom
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.Black));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Black));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Black));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Black));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.Black));
            m_Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.Black));
        }

        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.Projection = m_CameraManager.CameraSettings;
            m_BasicEffect.View = m_CameraManager.CameraState;
            m_BasicEffect.World = m_WorldMatrix;// * Matrix.CreateRotationY(m_RotationY += (float)i_GameTime.ElapsedGameTime.TotalSeconds * 10);

            foreach (EffectPass pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                    PrimitiveType.TriangleList, m_Vertices.ToArray(), 0, m_Vertices.Count/3);
            }

            base.Draw(i_GameTime);
        }

        public List<VertexPositionColor> m_Vertices { get; set; }
    }
}