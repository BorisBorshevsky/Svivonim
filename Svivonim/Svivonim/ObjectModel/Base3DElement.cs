using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Svivonim.ObjectModel
{
    abstract class Base3DElement : DrawableGameComponent
    {

        protected Vector3 m_Position = Vector3.Zero;
        protected Vector3 m_Rotations = Vector3.Zero;
        protected Vector3 m_Scales = Vector3.One;
        protected Matrix m_WorldMatrix = Matrix.Identity;
        protected BasicEffect m_BasicEffect;

        public bool SpinEnabled { get; set; }

        private float m_RotationsPerSecond;
        public float RotationsPerSecond
        {
            get { return m_RotationsPerSecond; }
            set { m_RotationsPerSecond = value; }
        }

        protected Base3DElement(Game i_Game) : base(i_Game)
        {
        }

        public override void Initialize()
        {
                base.Initialize();
            //get camera

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


        protected abstract void DoDraw(GameTime i_GameTime);

        public override void Draw(GameTime i_GameTime)
        {
            m_BasicEffect.World = m_WorldMatrix;

            foreach (EffectPass pass in m_BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                DoDraw(i_GameTime);
            }
            
            base.Draw(i_GameTime);
        }
    }
}
