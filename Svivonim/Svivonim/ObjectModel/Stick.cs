using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class Stick : Box
    {
        private VertexPositionColor[] m_ColorVertices;
        private short[] m_Indices;
        private Color m_Color;

        public Stick(Game i_Game, Color i_Color, Vector3 Position) : this(i_Game, i_Color, Position, Vector3.One)
        {
        }

        public Stick(Game i_Game, Color i_Color, Vector3 Position, Vector3 Scale) : base(i_Game, Position, Scale)
        {
            m_Color = i_Color;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            m_BasicEffect = new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.VertexColorEnabled = true;

            m_VerticesCoordinates = createStartCoordinates();
            m_ColorVertices = CreateColorVertices();

            m_VertexBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionColor), m_ColorVertices.Length, BufferUsage.WriteOnly);

            m_Indices = createIndicesMapping();

            m_IndexBuffer = new IndexBuffer(this.GraphicsDevice, typeof(short), m_Indices.Length, BufferUsage.WriteOnly);

        }


        protected virtual VertexPositionColor[] CreateColorVertices()
        {
            var textureVerticale = new VertexPositionColor[8];
            for (int i = 0; i < 8; i++)
            {
                textureVerticale[i] = new VertexPositionColor(m_VerticesCoordinates[i], m_Color); 
            }
            
            return textureVerticale;
        }

        protected override short[] createIndicesMapping()
        {
            short[] indices = new short[36];
            // Front face
            indices[0] = 2;
            indices[1] = 1;
            indices[2] = 0;
            indices[3] = 0;
            indices[4] = 3;
            indices[5] = 2;
        
            // Back face
            indices[6] = 6;
            indices[7] = 5;
            indices[8] = 4;
            indices[9] = 4;
            indices[10] = 7;
            indices[11] = 6;
            
            //// Right face
            indices[12] = 2;
            indices[13] = 3;
            indices[14] = 4;
            indices[15] = 4;
            indices[16] = 5;
            indices[17] = 2;
            
            //// Left face
            indices[18] = 0;
            indices[19] = 1;
            indices[20] = 6;
            indices[21] = 0;
            indices[22] = 6;
            indices[23] = 7;
            
            //// top
            indices[24] = 1;
            indices[25] = 2;
            indices[26] = 5;
            indices[27] = 1;
            indices[28] = 5;
            indices[29] = 6;

            //// bottom
            indices[30] = 4;
            indices[31] = 3;
            indices[32] = 0;
            indices[33] = 7;
            indices[34] = 4;
            indices[35] = 0;

            return indices;
        }


        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.Projection = m_CameraManager.CameraSettings;
            m_BasicEffect.View = m_CameraManager.CameraState;

            m_IndexBuffer.SetData(m_Indices);
            m_VertexBuffer.SetData(m_ColorVertices, 0, m_ColorVertices.Length);

            m_BasicEffect.GraphicsDevice.Indices = m_IndexBuffer;
            m_BasicEffect.GraphicsDevice.SetVertexBuffer(m_VertexBuffer);
            m_BasicEffect.GraphicsDevice.RasterizerState = r_RasterizerState;
            m_BasicEffect.World = m_WorldMatrix;



            foreach (var pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                m_BasicEffect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_VertexBuffer.VertexCount, 0, m_IndexBuffer.IndexCount / 3);

            }


            base.Draw(i_GameTime);
        }
    }
}
