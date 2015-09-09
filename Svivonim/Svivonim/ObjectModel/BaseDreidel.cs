using System;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    abstract class BaseDreidel : Composite3DComponent
    {
        protected Base3DElement m_Body;
        protected Base3DElement m_Pyramid;
        protected Base3DElement m_Stick;
        static readonly Random sr_Random = new Random();

        protected BaseDreidel(Game i_Game, Vector3 i_Position)
            : base(i_Game)
        {
            Position = i_Position;
        }

        public event Action<DradleSide> Stopped;

        private void onStop()
        {
            if (Stopped != null)
            {
                Stopped.Invoke(DradleSide.GIMEL);
            }
        }

        public void StartSpinning()
        {
            RotationsPerSecond = (float)sr_Random.Next(300, 1000) / 100;
            SpinEnabled = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (RotationsPerSecond > 0 && SpinEnabled) { 
                RotationsPerSecond -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (RotationsPerSecond <= 0 && SpinEnabled)
            {
                onStop();
                SpinEnabled = false;
            }

        }
    }
}
