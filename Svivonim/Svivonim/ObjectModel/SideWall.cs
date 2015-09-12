using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    class SideWall : Base3DElement
    {

        protected const float k_MaxZCoordinate = 1;
        protected const float k_MinZCoordinate = -1;
        protected const float k_MinXCoordinate = -1;
        protected const float k_MaxXCoordinate = 1;
        protected VertexPositionColor[] m_Vertices;

        protected bool m_IsReverseOrder = false;

        public SideWall(Game i_Game, Vector3 i_Scale, Vector3 i_Position) : base(i_Game)
        {
            this.Scales = i_Scale;
            this.Position = i_Position;
        }

        public SideWall(Game i_Game, Vector3 i_Scale, Vector3 i_Position, bool i_IsReveseOrder)
            : this(i_Game, i_Scale, i_Position)
        {
            m_IsReverseOrder = i_IsReveseOrder;
        }

        protected override Vector3[] createStartCoordinates()
        {
            var coordinates = new Vector3[4];
            coordinates[0] = new Vector3(-1, 0, -1) * m_Scale + Position;
            coordinates[1] = new Vector3(-1, 0, 1) * m_Scale + Position;
            coordinates[2] = new Vector3(1, 0, -1) * m_Scale + Position;
            coordinates[3] = new Vector3(1, 0, 1) * m_Scale + Position;
            return coordinates;
        }

        protected override short[] createIndicesMapping()
        {
            throw new InvalidOperationException("method not allowed");
        }

        protected override void LoadContent()
        {
            m_BasicEffect = m_BasicEffect ?? new BasicEffect(this.GraphicsDevice);
            m_BasicEffect.VertexColorEnabled = true;

            m_VerticesCoordinates = createStartCoordinates();

            CreateVerices();
        }

        protected void CreateVerices()
        {
            m_Vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(m_VerticesCoordinates[0], Color.Fuchsia),
                new VertexPositionColor(m_VerticesCoordinates[1], Color.Fuchsia),
                new VertexPositionColor(m_VerticesCoordinates[2], Color.Fuchsia),
                new VertexPositionColor(m_VerticesCoordinates[3], Color.Fuchsia),
            };


            if (m_IsReverseOrder)
            {
                m_Vertices = new VertexPositionColor[]
                {
                new VertexPositionColor(m_VerticesCoordinates[0], Color.Fuchsia),
                new VertexPositionColor(m_VerticesCoordinates[2], Color.Fuchsia),
                new VertexPositionColor(m_VerticesCoordinates[1], Color.Fuchsia),
                new VertexPositionColor(m_VerticesCoordinates[3], Color.Fuchsia),
                };
            }

        }


        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.Projection = m_CameraManager.CameraSettings;
            m_BasicEffect.View = m_CameraManager.CameraState;
            m_BasicEffect.World = m_WorldMatrix;
            m_BasicEffect.GraphicsDevice.RasterizerState = r_RasterizerState;

            foreach (EffectPass pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, m_Vertices, 0, m_Vertices.Length -2);
            }

            base.Draw(i_GameTime);
        }
    }
}
