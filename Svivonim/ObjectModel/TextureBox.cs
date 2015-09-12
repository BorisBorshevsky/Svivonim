using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class TextureBox : Box
    {
        private Texture2D m_Texture;
        private VertexPositionTexture[] m_TextureVertices;
     
        public TextureBox(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            Position = i_Position;
        }

        protected VertexPositionTexture[] CreateTextureVertices()
        {
            var textureVerticale = new VertexPositionTexture[10];
            
            textureVerticale[0] = new VertexPositionTexture(new Vector3(-1, -1, 1), new Vector2(0, 1f));
            textureVerticale[1] = new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(0, 0));
            textureVerticale[2] = new VertexPositionTexture(new Vector3(1, -1, 1), new Vector2(0.25f, 1));
            textureVerticale[3] = new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(0.25f, 0));
            textureVerticale[4] = new VertexPositionTexture(new Vector3(1, -1, -1), new Vector2(0.5f, 1));
            textureVerticale[5] = new VertexPositionTexture(new Vector3(1, 1, -1), new Vector2(0.5f, 0));
            textureVerticale[6] = new VertexPositionTexture(new Vector3(-1, -1, -1), new Vector2(0.75f, 1));
            textureVerticale[7] = new VertexPositionTexture(new Vector3(-1, 1, -1), new Vector2(0.75f, 0));
            textureVerticale[8] = new VertexPositionTexture(new Vector3(-1, -1, 1), new Vector2(1, 1));
            textureVerticale[9] = new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(1, 0));

            return textureVerticale;
        }

        protected override short[] CreateIndicesMapping()
        {
            short[] textureIndices = new short[24];
            // Back face ++
            textureIndices[0] = 0;
            textureIndices[1] = 1;
            textureIndices[2] = 2;
            textureIndices[3] = 3;
            textureIndices[4] = 2;
            textureIndices[5] = 1;

            // Back face
            textureIndices[6] = 2;
            textureIndices[7] = 3;
            textureIndices[8] = 4;
            textureIndices[9] = 5;
            textureIndices[10] = 4;
            textureIndices[11] = 3;

            // Right face
            textureIndices[12] = 4;
            textureIndices[13] = 5;
            textureIndices[14] = 6;
            textureIndices[15] = 7;
            textureIndices[16] = 6;
            textureIndices[17] = 5;

            // Left face
            textureIndices[18] = 6;
            textureIndices[19] = 7;
            textureIndices[20] = 8;
            textureIndices[21] = 9;
            textureIndices[22] = 8;
            textureIndices[23] = 7;

            return textureIndices;
        }

        protected override void LoadContent()
        {
            m_Texture = Game.Content.Load<Texture2D>(@"Textures2D/LinedTexture");
            m_BasicEffect = m_BasicEffect ?? new BasicEffect(GraphicsDevice);
            m_BasicEffect.Texture = m_Texture;
            m_BasicEffect.TextureEnabled = true;

            m_VerticesCoordinates = CreateStartCoordinates();
            m_TextureVertices = CreateTextureVertices();

            m_VertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionTexture), m_TextureVertices.Length, BufferUsage.WriteOnly);
            m_Indices = CreateIndicesMapping();
            m_IndexBuffer = new IndexBuffer(GraphicsDevice, typeof(short), m_Indices.Length, BufferUsage.WriteOnly);
        }

        public override void Draw(GameTime i_GameTime)
        {
            base.Draw(i_GameTime);

            m_IndexBuffer.SetData(m_Indices);
            m_VertexBuffer.SetData(m_TextureVertices, 0, m_TextureVertices.Length);

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