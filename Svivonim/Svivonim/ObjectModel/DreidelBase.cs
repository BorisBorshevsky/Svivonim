using System;
using Infrastructure.ObjectModel3D;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    abstract class DreidelBase : Composite3DComponent
    {
        protected Base3DElement m_Body;
        protected Base3DElement m_Pyramid;
        protected Base3DElement m_Stick;
        static readonly Random sr_Random = new Random();
        private float m_StartRotationPerSecond;
        private const int k_MinRoundsPerSecond = 3000; //devided by 1000
        private const int k_MaxRoundsPerSecond = 10000;

        public event Action<eDradleSide> Stopped;

        protected DreidelBase(Game i_Game, Vector3 i_Position, Color i_StickColor)
            : base(i_Game)
        {
            i_Game.Components.Add(this);

            Position = i_Position;
            m_Pyramid = new Pyramid(i_Game);
            Add(m_Pyramid);
            m_Stick = new Stick(i_Game, i_StickColor, new Vector3(0, 1, 0), new Vector3(.25f, 1f, .25f));
            Add(m_Stick);
        }

        private void onStop()
        {
            SpinEnabled = false;

            if (Stopped != null)
            {
                Stopped.Invoke(GetLetter());
            }
        }

        public void StartSpinning()
        {
            m_StartRotationPerSecond = (float)sr_Random.Next(k_MinRoundsPerSecond, k_MaxRoundsPerSecond) / 1000;
            RotationsPerSecond = m_StartRotationPerSecond;
            SpinEnabled = true;
        }

        public override void Update(GameTime i_GameTime)
        {
            base.Update(i_GameTime);

            if (SpinEnabled)
            {
                RotationsPerSecond -= (float)i_GameTime.ElapsedGameTime.TotalSeconds;

                if (RotationsPerSecond <= 0)
                {
                    onStop();
                }
            }
        }

        public eDradleSide GetLetter()
        {
            eDradleSide dradleSide = eDradleSide.Unknown;

            float rotationY = Rotations.Y % MathHelper.TwoPi;

            if (rotationY < MathHelper.PiOver4 || rotationY > MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver4)
            {
                dradleSide = eDradleSide.Pey;
            }
            else if (rotationY < MathHelper.PiOver2 + MathHelper.PiOver4)
            {
                dradleSide = eDradleSide.Gimel;
            }
            else if (rotationY < MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver4)
            {
                dradleSide = eDradleSide.Nun;
            }
            else if (rotationY < MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver4)
            {
                dradleSide = eDradleSide.Hey;
            }

            return dradleSide;
        }
    }
}