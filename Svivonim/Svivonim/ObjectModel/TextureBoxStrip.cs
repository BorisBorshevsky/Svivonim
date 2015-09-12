using Dreidels.ObjectModel.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class TextureBoxStrip : Box
    {
        private Texture2D m_Texture;
        private VertexPositionTexture[] m_TextureVertices;

        public TextureBoxStrip(Game i_Game, Vector3 i_Position)
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

        protected override void LoadContent()
        {
            m_Texture = Game.Content.Load<Texture2D>(@"Textures2D/LinedTexture");

            m_BasicEffect = new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.Texture = m_Texture;
            m_BasicEffect.TextureEnabled = true;

            m_VerticesCoordinates = createStartCoordinates();

            m_TextureVertices = CreateTextureVertices();
        }

        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.Projection = m_CameraManager.CameraSettings;
            m_BasicEffect.View = m_CameraManager.CameraState;

            m_BasicEffect.GraphicsDevice.RasterizerState = r_RasterizerState;

            m_BasicEffect.World = m_WorldMatrix;

            foreach (var pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                m_BasicEffect.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, m_TextureVertices, 0, m_TextureVertices.Length - 2);
            }

            base.Draw(i_GameTime);
        }
    }
}