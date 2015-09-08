using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Svivonim.ObjectModel
{

    enum DradleSide
    {
        NUN,  
        GIMEL,  
        HEY,  
        PEY
    }
    
    
    class Dradel : Composite3DComponent
    {
        private TextureBox m_Body;
        private Pyramid m_Pyramid;
        private Stick m_Stick;
        static readonly Random sr_Random = new Random();


        public Dradel(Game i_Game, Vector3 i_Position) : base(i_Game)
        {
            Position = i_Position;

            m_Body = new TextureBox(i_Game, Vector3.Zero);
            Add(m_Body);
            m_Pyramid = new Pyramid(i_Game);
            Add(m_Pyramid);
            m_Stick = new Stick(i_Game, Color.Blue, new Vector3(0, 1, 0), new Vector3(.1f, 1f, .1f));
            Add(m_Stick);

        }

        public event Action<DradleSide> Stopped;

        private void onStop()
        {
            if (Stopped != null)
            {
                Stopped.Invoke(DradleSide.GIMEL);
            }
        }

        public void StartSpining()
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
