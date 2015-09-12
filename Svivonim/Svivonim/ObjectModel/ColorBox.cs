using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class ColorBox : Box
    {
        public ColorBox(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            Position = i_Position;
        }

        protected override void LoadContent()
        {
            m_BasicEffect = m_BasicEffect ?? new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.VertexColorEnabled = true;

            m_VerticesCoordinates = CreateStartCoordinates();

            Vertices = new List<VertexPositionColor>();
 
            createWalls();
            createHeiLetter();
            createNonLetter();
            createPeiLetter();
            createGimel();
        }

        private void createHeiLetter() // BACK
        {
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, -0.3f), Color.Black));
                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, -0.3f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0, -0.3f), Color.Black));
                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.3f, -0.5f), Color.Black));
                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.3f, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.3f, 0.5f), Color.Black));
                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, 0.3f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.3f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, 0.5f), Color.Black));
                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, -0.5f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.3f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-1.001f, 0.5f, 0.5f), Color.Black));
        }

        private void createNonLetter() //LEFT
        {
            Vertices.Add(new VertexPositionColor(new Vector3( -0.3f, -0.2f, 1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.2f, 1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3( -0.3f, -0.5f, 1.001f), Color.Black));
                                                                               
            Vertices.Add(new VertexPositionColor(new Vector3( -0.3f, -0.5f, 1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.2f, 1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.5f, 1.001f), Color.Black));
                                                                               
            Vertices.Add(new VertexPositionColor(new Vector3( 0.3f , -0.5f, 1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.3f  , 0.5f,  1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.5f, 1.001f), Color.Black));
                                                                               
            Vertices.Add(new VertexPositionColor(new Vector3( 0.5f , -0.5f, 1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.3f  , 0.5f,  1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.5f,  1.001f), Color.Black));
                                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(0     , 0.5f,  1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.5f,  1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0     , 0.2f,  1.001f), Color.Black));
                                                                               
            Vertices.Add(new VertexPositionColor(new Vector3(0     , 0.2f,  1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.5f,  1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f  , 0.2f,  1.001f), Color.Black));
        }

        private void createPeiLetter() //FRONT - GOOOOOD
        {
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.15f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0, 0.15f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.15f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.15f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0, 0.15f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0, -0.15f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.15f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.2f, -0.65f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(0.2f, -0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.15f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.2f, 0.15f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.35f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.35f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.65f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, -0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.35f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.65f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, -0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, 0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.65f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, -0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.2f, 0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.65f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.35f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.35f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.65f, -1.001f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(-0.5f, 0.65f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.35f, -1.001f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(0.5f, 0.65f, -1.001f), Color.Black));
        }

        private void createGimel() //left - GOOOD
        {
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.35f, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.35f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.5f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.5f), Color.Black));            
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.35f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, 0.5f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.15f, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.15f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, -0.5f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, -0.5f), Color.Black));            
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.15f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.5f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, -0.2f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.2f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, -0.5f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, -0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.2f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.65f, -0.5f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, 0.2f), Color.Black));

            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, -0.65f, 0.2f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.5f), Color.Black));
            Vertices.Add(new VertexPositionColor(new Vector3(1.001f, 0.15f, 0.2f), Color.Black));
        }

        private void createWalls()
        {
            //front - PEI
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.Blue));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.Blue));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Blue));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Blue));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.Blue));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.Blue));
            
            //back Nun
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Yellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Yellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.Yellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.Yellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.Yellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Yellow));

            //left - Gimel
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.GreenYellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[2], Color.GreenYellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.GreenYellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[3], Color.GreenYellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[4], Color.GreenYellow));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[5], Color.GreenYellow));

            //right -- Hei
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Red));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[1], Color.Red));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Red));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[6], Color.Red));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[7], Color.Red));
            Vertices.Add(new VertexPositionColor(m_VerticesCoordinates[0], Color.Red));
        }

        public override void Draw(GameTime i_GameTime)
        {
            base.Draw(i_GameTime);
            
            foreach (EffectPass pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Vertices.ToArray(), 0, Vertices.Count / 3);
            }
        }

        public List<VertexPositionColor> Vertices { get; set; }
    }
}