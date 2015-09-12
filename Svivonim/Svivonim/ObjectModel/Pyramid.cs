using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class Pyramid : Composite3DComponent
    {
        private readonly Color r_Color = Color.Blue;
        private VertexPositionColor[] m_ColorVertices;
        private short[] m_Indices;


        public Pyramid(Game i_Game)
            : base(i_Game)
        {
        }

        protected override Vector3[] CreateStartCoordinates()
        {
            var cordinates = new Vector3[5];
            cordinates[0] = new Vector3(-1, -1, -1); //front left
            cordinates[1] = new Vector3(1, -1, -1); //front right
            cordinates[2] = new Vector3(-1, -1, 1); //back left
            cordinates[3] = new Vector3(1, -1, 1); //back right
            cordinates[4] = new Vector3(0, -2, 0); //center
            return cordinates;
        }


        protected virtual VertexPositionColor[] CreateColorVertices()
        {
            var textureVerticale = new VertexPositionColor[5];
            textureVerticale[0] = new VertexPositionColor(m_VerticesCoordinates[0], r_Color);
            textureVerticale[1] = new VertexPositionColor(m_VerticesCoordinates[1], r_Color);
            textureVerticale[2] = new VertexPositionColor(m_VerticesCoordinates[2], r_Color);
            textureVerticale[3] = new VertexPositionColor(m_VerticesCoordinates[3], r_Color);
            textureVerticale[4] = new VertexPositionColor(m_VerticesCoordinates[4], Color.Black);

            return textureVerticale;
        }

        protected override short[] CreateIndicesMapping()
        {
            short[] indices = new short[12];
            // Front face
            indices[0] = 1;
            indices[1] = 0;
            indices[2] = 4;

            // back
            indices[3] = 2;
            indices[4] = 3;
            indices[5] = 4;

            // right
            indices[6] = 3;
            indices[7] = 1;
            indices[8] = 4;

            //left
            indices[9] = 0;
            indices[10] = 2;
            indices[11] = 4;

            return indices;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            m_BasicEffect = m_BasicEffect ?? new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.VertexColorEnabled = true;

            m_VerticesCoordinates = CreateStartCoordinates();
            m_ColorVertices = CreateColorVertices();

            m_VertexBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionColor), m_ColorVertices.Length, BufferUsage.WriteOnly);

            m_Indices = CreateIndicesMapping();

            m_IndexBuffer = new IndexBuffer(this.GraphicsDevice, typeof(short), m_Indices.Length, BufferUsage.WriteOnly);
        }


        public override void Draw(GameTime i_GameTime)
        {

            base.Draw(i_GameTime);
            
            m_IndexBuffer.SetData(m_Indices);
            m_VertexBuffer.SetData(m_ColorVertices, 0, m_ColorVertices.Length);

            m_BasicEffect.GraphicsDevice.Indices = m_IndexBuffer;
            m_BasicEffect.GraphicsDevice.SetVertexBuffer(m_VertexBuffer);

            foreach (var pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                m_BasicEffect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_VertexBuffer.VertexCount, 0, m_IndexBuffer.IndexCount / 3);

            }


            
        }
    }
}
