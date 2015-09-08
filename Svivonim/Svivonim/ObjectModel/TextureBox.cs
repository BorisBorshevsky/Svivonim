using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Svivonim.ObjectModel
{
    class TextureBox : DrawableGameComponent
    {


        private VertexPositionColor[] m_Verts;
        //        private BasicEffect effect;
        private VertexBuffer m_Buffer;
        private BasicEffect m_Effect;
        private Vector3 m_Position;
        private float m_RotationY;
        private Texture2D m_Texture;
        private BasicEffect m_BasicEffect;
        private VertexPositionTexture[] m_Vertices;
        private VertexBuffer m_VertexBuffer;
        private CameraManager m_CameraManager;
        private short[] m_Indices;
        private IndexBuffer m_IndexBuffer;
        private readonly RasterizerState r_RasterizerState = new RasterizerState();

        protected const float k_ZFactorWidth = 3;
        protected const float k_ZFactorCoordinate = -3f;
        protected const float k_MinXCoordinate = -3;
        protected const float k_MaxXCoordinate = 3;
        protected const float k_MinYCoordinate = -3;
        protected const float k_MaxYCoordinate = 3;
        protected readonly Color r_UpDownColor = Color.BurlyWood;
        private VertexPositionTexture[] m_TextureVertices;
        private Vector3[] m_VerticesCoordinates;
        private short[] m_ColorIndeces;

        public TextureBox(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            this.m_Position = i_Position;
        }

        public override void Initialize()
        {

            base.Initialize();
            m_CameraManager = Game.Services.GetService<CameraManager>();
        }

        /*protected override void LoadContent()
        {
            base.LoadContent();
            m_Texture = Game.Content.Load<Texture2D>(@"Textures2D/dradelTextures");

            m_BasicEffect = new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.Texture = m_Texture;
            m_BasicEffect.TextureEnabled = true;

            m_Vertices = new VertexPositionTexture[8];
            m_Vertices[0] = new VertexPositionTexture(new Vector3(-1, -1, -1), new Vector2(0, 0));
            m_Vertices[1] = new VertexPositionTexture(new Vector3(-1, 1, -1), new Vector2(0, 0.5f));
            m_Vertices[2] = new VertexPositionTexture(new Vector3(1, -1, -1), new Vector2(0.5f, 0));
            m_Vertices[3] = new VertexPositionTexture(new Vector3(1, 1, -1), new Vector2(0.5f, 0.5f));
            
            m_Vertices[4] = new VertexPositionTexture(new Vector3(-1, -1, 1), new Vector2(1, 1));
            m_Vertices[5] = new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(1, 0.5f));
            m_Vertices[6] = new VertexPositionTexture(new Vector3(1, -1, 1), new Vector2(0.5f, 1));
            m_Vertices[7] = new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f));


            m_VertexBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionTexture), m_Vertices.Length, BufferUsage.WriteOnly);
            m_VertexBuffer.SetData(m_Vertices, 0, m_Vertices.Length);

            m_Indices = new short[12];
            
            //front
            // first triangle:
            m_Indices[0] = 2;
            m_Indices[1] = 1;
            m_Indices[2] = 0;
            // second triangle:
            m_Indices[3] = 3;
            m_Indices[4] = 2;
            m_Indices[5] = 1;

            //back
            m_Indices[6] = 6;
            m_Indices[7] = 5;
            m_Indices[8] = 4;
            // second triangle:
            m_Indices[9] = 7;
            m_Indices[10] = 6;
            m_Indices[11] = 5;

            //left
            m_Indices[12] = 6;
            m_Indices[13] = 5;
            m_Indices[14] = 4;
            // second triangle:
            m_Indices[15] = 7;
            m_Indices[16] = 6;
            m_Indices[17] = 5;



            m_IndexBuffer = new IndexBuffer(this.GraphicsDevice, typeof(short), m_Indices.Length, BufferUsage.WriteOnly);
            m_IndexBuffer.SetData(m_Indices);

            r_RasterizerState.CullMode = CullMode.None;


        }*/

        private short[] createTextureIndices()
        {
            short[] textureIndices = new short[30];
            // Front face
            textureIndices[0] = 0;
            textureIndices[1] = 1;
            textureIndices[2] = 2;
            textureIndices[3] = 0;
            textureIndices[4] = 2;
            textureIndices[5] = 3;

            // Back face
            textureIndices[6] = 4;
            textureIndices[7] = 5;
            textureIndices[8] = 6;
            textureIndices[9] = 4;
            textureIndices[10] = 6;
            textureIndices[11] = 7;

            // Right face
            textureIndices[12] = 8;
            textureIndices[13] = 9;
            textureIndices[14] = 10;
            textureIndices[15] = 8;
            textureIndices[16] = 10;
            textureIndices[17] = 11;

            // Left face
            textureIndices[18] = 12;
            textureIndices[19] = 13;
            textureIndices[20] = 14;
            textureIndices[21] = 12;
            textureIndices[22] = 14;
            textureIndices[23] = 15;
            
            // top
            textureIndices[24] = 16;
            textureIndices[25] = 17;
            textureIndices[26] = 18;
            textureIndices[27] = 16;
            textureIndices[28] = 18;
            textureIndices[29] = 19;


            return textureIndices;
        }

        private Vector3[] createStartCoordinates()
        {
            var cordinates = new Vector3[8];
            cordinates[0] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_ZFactorCoordinate);
            cordinates[1] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_ZFactorCoordinate);
            cordinates[2] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_ZFactorCoordinate);
            cordinates[3] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_ZFactorCoordinate);
            cordinates[4] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_ZFactorWidth);
            cordinates[5] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_ZFactorWidth);
            cordinates[6] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_ZFactorWidth);
            cordinates[7] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_ZFactorWidth);
            return cordinates;
        }

        private VertexPositionTexture[] createTextureVertices()
        {
            var textureVerticale = new VertexPositionTexture[20];
            // Create front vertices
            textureVerticale[0] = new VertexPositionTexture(m_VerticesCoordinates[0], new Vector2(0, .5f));
            textureVerticale[1] = new VertexPositionTexture(m_VerticesCoordinates[1], new Vector2(0, 0));
            textureVerticale[2] = new VertexPositionTexture(m_VerticesCoordinates[2], new Vector2(.5f, 0));
            textureVerticale[3] = new VertexPositionTexture(m_VerticesCoordinates[3], new Vector2(.5f, .5f));

            // Creating the back side
            textureVerticale[4] = new VertexPositionTexture(m_VerticesCoordinates[4], new Vector2(0, 1));
            textureVerticale[5] = new VertexPositionTexture(m_VerticesCoordinates[5], new Vector2(0, .5f));
            textureVerticale[6] = new VertexPositionTexture(m_VerticesCoordinates[6], new Vector2(.5f, .5f));
            textureVerticale[7] = new VertexPositionTexture(m_VerticesCoordinates[7], new Vector2(.5f, 1));

            // Creating the right side
            textureVerticale[8] = new VertexPositionTexture(m_VerticesCoordinates[3], new Vector2(.5f, 1));
            textureVerticale[9] = new VertexPositionTexture(m_VerticesCoordinates[2], new Vector2(.5f, .5f));
            textureVerticale[10] = new VertexPositionTexture(m_VerticesCoordinates[5], new Vector2(1, .5f));
            textureVerticale[11] = new VertexPositionTexture(m_VerticesCoordinates[4], new Vector2(1, 1));

            // Creating the left side
            textureVerticale[12] = new VertexPositionTexture(m_VerticesCoordinates[7], new Vector2(.5f, .5f));
            textureVerticale[13] = new VertexPositionTexture(m_VerticesCoordinates[6], new Vector2(.5f, 0));
            textureVerticale[14] = new VertexPositionTexture(m_VerticesCoordinates[1], new Vector2(1, 0));
            textureVerticale[15] = new VertexPositionTexture(m_VerticesCoordinates[0], new Vector2(1, .5f));

            //top
            textureVerticale[16] = new VertexPositionTexture(m_VerticesCoordinates[1], new Vector2(0,0));
            textureVerticale[17] = new VertexPositionTexture(m_VerticesCoordinates[2], new Vector2(0,0));
            textureVerticale[18] = new VertexPositionTexture(m_VerticesCoordinates[5], new Vector2(0,0));
            textureVerticale[19] = new VertexPositionTexture(m_VerticesCoordinates[6], new Vector2(0,0));


            return textureVerticale;
        }


//        private short[] createColorIndices()
//        {
//            short[] colorIndices = new short[12];
//            // Top face
//            colorIndices[0] = 0;
//            colorIndices[1] = 1;
//            colorIndices[2] = 2;
//            colorIndices[3] = 0;
//            colorIndices[4] = 2;
//            colorIndices[5] = 3;
//
//            // Bottom face
//            colorIndices[6] = 4;
//            colorIndices[7] = 5;
//            colorIndices[8] = 6;
//            colorIndices[9] = 4;
//            colorIndices[10] = 6;
//            colorIndices[11] = 7;
//
//            return colorIndices;
//        }

        protected override void LoadContent()
        {
            base.LoadContent();
            m_Texture = Game.Content.Load<Texture2D>(@"Textures2D/dradelTextures");

            m_BasicEffect = new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.Texture = m_Texture;
            m_BasicEffect.TextureEnabled = true;

            m_VerticesCoordinates = createStartCoordinates();
            m_TextureVertices = createTextureVertices();

            m_VertexBuffer = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionTexture), m_TextureVertices.Length, BufferUsage.WriteOnly);

//            m_ColorIndeces = createColorIndices();
            m_Indices = createTextureIndices();

            m_IndexBuffer = new IndexBuffer(this.GraphicsDevice, typeof(short), m_Indices.Length, BufferUsage.WriteOnly);
           

            r_RasterizerState.CullMode = CullMode.None;
        }

        protected override void UnloadContent()
        {
            if (m_BasicEffect != null)
            {
                m_BasicEffect.Dispose();
                m_BasicEffect = null;

                m_VertexBuffer.Dispose();
            }
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


            m_BasicEffect.World = Matrix.Identity;


            foreach (var pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                m_BasicEffect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, m_VertexBuffer.VertexCount, 0, m_IndexBuffer.IndexCount / 3);

            }


            base.Draw(i_GameTime);
        }



        public override void Update(GameTime i_GameTime)
        {

            float deltaTime = (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            m_RotationY += deltaTime;


            base.Update(i_GameTime);
        }

    }
}
