using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Svivonim.ObjectModel
{
    class TextureBox : Box
    {
        private VertexPositionColor[] m_Verts;
        private VertexBuffer m_Buffer;
        private BasicEffect m_Effect;
        private Texture2D m_Texture;
        private BasicEffect m_BasicEffect;
        private VertexPositionTexture[] m_Vertices;
        private short[] m_Indices;
        private IndexBuffer m_IndexBuffer;
//        private readonly RasterizerState r_RasterizerState = new RasterizerState();

        private VertexPositionTexture[] m_TextureVertices;
        

        public TextureBox(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            ((Base3DElement) this).Position = i_Position;
        }

        public override void Initialize()
        {

            base.Initialize();
            m_CameraManager = Game.Services.GetService<CameraManager>();
        }


       

 
     
        protected VertexPositionTexture[] createTextureVertices()
        {
            var textureVerticale = new VertexPositionTexture[24];
            // Create front vertices
            textureVerticale[0] = new VertexPositionTexture(m_VerticesCoordinates[0], new Vector2(.5f, .5f));
            textureVerticale[1] = new VertexPositionTexture(m_VerticesCoordinates[1], new Vector2(0.5f, 0));
            textureVerticale[2] = new VertexPositionTexture(m_VerticesCoordinates[2], new Vector2(0, 0));
            textureVerticale[3] = new VertexPositionTexture(m_VerticesCoordinates[3], new Vector2(0, .5f));

            // Creating the back side
            textureVerticale[4] = new VertexPositionTexture(m_VerticesCoordinates[4], new Vector2(0.5f, 1));
            textureVerticale[5] = new VertexPositionTexture(m_VerticesCoordinates[5], new Vector2(0.5f, .5f));
            textureVerticale[6] = new VertexPositionTexture(m_VerticesCoordinates[6], new Vector2(0, .5f));
            textureVerticale[7] = new VertexPositionTexture(m_VerticesCoordinates[7], new Vector2(0, 1));

            // Creating the right side
            textureVerticale[8] = new VertexPositionTexture(m_VerticesCoordinates[3], new Vector2(1, 1));
            textureVerticale[9] = new VertexPositionTexture(m_VerticesCoordinates[2], new Vector2(1, .5f));
            textureVerticale[10] = new VertexPositionTexture(m_VerticesCoordinates[5], new Vector2(.5f, .5f));
            textureVerticale[11] = new VertexPositionTexture(m_VerticesCoordinates[4], new Vector2(0.5f, 1));

            // Creating the left side
            textureVerticale[12] = new VertexPositionTexture(m_VerticesCoordinates[7], new Vector2(1, .5f));
            textureVerticale[13] = new VertexPositionTexture(m_VerticesCoordinates[6], new Vector2(1, 0));
            textureVerticale[14] = new VertexPositionTexture(m_VerticesCoordinates[1], new Vector2(.5f, 0));
            textureVerticale[15] = new VertexPositionTexture(m_VerticesCoordinates[0], new Vector2(0.5f, .5f));

            //top
            textureVerticale[16] = new VertexPositionTexture(m_VerticesCoordinates[1], new Vector2(0,0));
            textureVerticale[17] = new VertexPositionTexture(m_VerticesCoordinates[2], new Vector2(0,0));
            textureVerticale[18] = new VertexPositionTexture(m_VerticesCoordinates[5], new Vector2(0,0));
            textureVerticale[19] = new VertexPositionTexture(m_VerticesCoordinates[6], new Vector2(0,0));

            //bottom
            textureVerticale[20] = new VertexPositionTexture(m_VerticesCoordinates[0], new Vector2(0, 0));
            textureVerticale[21] = new VertexPositionTexture(m_VerticesCoordinates[3], new Vector2(0, 0));
            textureVerticale[22] = new VertexPositionTexture(m_VerticesCoordinates[4], new Vector2(0, 0));
            textureVerticale[23] = new VertexPositionTexture(m_VerticesCoordinates[7], new Vector2(0, 0));



            return textureVerticale;
        }

        protected override short[] createIndicesMapping()
        {
            short[] textureIndices = new short[36];
            // Front face
            textureIndices[0] = 2;
            textureIndices[1] = 1;
            textureIndices[2] = 0;
            textureIndices[3] = 0;
            textureIndices[4] = 3;
            textureIndices[5] = 2;

            // Back face
            textureIndices[6] = 6;
            textureIndices[7] = 5;
            textureIndices[8] = 4;
            textureIndices[9] = 4;
            textureIndices[10] = 7;
            textureIndices[11] = 6;

            // Right face
            textureIndices[12] = 10;
            textureIndices[13] = 9;
            textureIndices[14] = 8;
            textureIndices[15] = 8;
            textureIndices[16] = 11;
            textureIndices[17] = 10;

            // Left face
            textureIndices[18] = 14;
            textureIndices[19] = 13;
            textureIndices[20] = 12;
            textureIndices[21] = 12;
            textureIndices[22] = 15;
            textureIndices[23] = 14;

            // top
            textureIndices[24] = 16;
            textureIndices[25] = 17;
            textureIndices[26] = 18;
            textureIndices[27] = 16;
            textureIndices[28] = 18;
            textureIndices[29] = 19;

            // botton
            textureIndices[30] = 22;
            textureIndices[31] = 21;
            textureIndices[32] = 20;
            textureIndices[33] = 23;
            textureIndices[34] = 22;
            textureIndices[35] = 20;


            return textureIndices;
        }



        protected override void LoadContent()
        {
            m_Texture = Game.Content.Load<Texture2D>(@"Textures2D/dradelTextures");

            m_BasicEffect = new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.Texture = m_Texture;
            m_BasicEffect.TextureEnabled = true;

            m_VerticesCoordinates = createStartCoordinates();
            m_TextureVertices = createTextureVertices();

            m_VertexBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionTexture), m_TextureVertices.Length, BufferUsage.WriteOnly);

            m_Indices = createIndicesMapping();

            m_IndexBuffer = new IndexBuffer(this.GraphicsDevice, typeof(short), m_Indices.Length, BufferUsage.WriteOnly);
        }


        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.Projection = m_CameraManager.CameraSettings;
            m_BasicEffect.View = m_CameraManager.CameraState;

            m_IndexBuffer.SetData(m_Indices);
            m_VertexBuffer.SetData(m_TextureVertices, 0, m_TextureVertices.Length);

            m_BasicEffect.GraphicsDevice.Indices = m_IndexBuffer;
            m_BasicEffect.GraphicsDevice.SetVertexBuffer(m_VertexBuffer);
            m_BasicEffect.GraphicsDevice.RasterizerState = r_RasterizerState;

            m_BasicEffect.World = m_WorldMatrix;// * Matrix.CreateRotationY(m_RotationY += (float)i_GameTime.ElapsedGameTime.TotalSeconds * 10);

            foreach (var pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                m_BasicEffect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_VertexBuffer.VertexCount, 0, m_IndexBuffer.IndexCount / 3);

            }


            base.Draw(i_GameTime);
        }

    }
}
