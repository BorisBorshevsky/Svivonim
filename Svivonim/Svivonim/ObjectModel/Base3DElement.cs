using Dreidels.ObjectModel.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreidels.ObjectModel
{
    abstract class Base3DElement : DrawableGameComponent
    {
        protected ICameraManager m_CameraManager;
        private Vector3 m_Position = Vector3.Zero;
        private Vector3 m_Rotations = Vector3.Zero;
        private Vector3 m_Scales = Vector3.One;
        protected Matrix m_WorldMatrix = Matrix.Identity;
        protected BasicEffect m_BasicEffect;
        protected VertexBuffer m_VertexBuffer;
        protected IndexBuffer m_IndexBuffer;
        protected Vector3[] m_VerticesCoordinates;
        protected readonly RasterizerState r_RasterizerState = new RasterizerState();

        protected Vector3 m_Scale = Vector3.One;

        public virtual bool SpinEnabled { get; set; }

        private float m_RotationsPerSecond;
        public virtual float RotationsPerSecond
        {
            get { return m_RotationsPerSecond; }
            set { m_RotationsPerSecond = value; }
        }

        public virtual Vector3 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        protected virtual Vector3 Rotations
        {
            get { return m_Rotations; }
            set { m_Rotations = value; }
        }

        public virtual Vector3 Scales
        {
            get { return m_Scales; }
            set { m_Scales = value; }
        }

        protected Base3DElement(Game i_Game) : base(i_Game)
        { }

        public override void Initialize()
        {
            base.Initialize();
            r_RasterizerState.CullMode = CullMode.CullCounterClockwiseFace; //TODO: change back to CullCounterClockwiseFace
            m_CameraManager = Game.Services.GetService<ICameraManager>();
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

        public override void Update(GameTime i_GameTime)
        {
            base.Update(i_GameTime);

            if (SpinEnabled)
            {
                m_Rotations.Y += (float)i_GameTime.ElapsedGameTime.TotalSeconds * m_RotationsPerSecond;
            }

            m_WorldMatrix =
                Matrix.Identity *
                Matrix.CreateScale(m_Scales) *
                Matrix.CreateRotationX(m_Rotations.X) *
                Matrix.CreateRotationY(m_Rotations.Y) *
                Matrix.CreateRotationZ(m_Rotations.Z) *
                Matrix.CreateTranslation(m_Position);
        }

        protected abstract Vector3[] createStartCoordinates();

        protected abstract short[] createIndicesMapping();
    }
}
