using System;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    class Dreidel3 : BaseDreidel
    {
        private TextureBox m_Body;
        private Pyramid m_Pyramid;
        private Stick m_Stick;
        static readonly Random sr_Random = new Random();

        public Dreidel3(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position)
        {
            m_Body = new TextureBox(i_Game, Vector3.Zero);
            Add(m_Body);
            m_Pyramid = new Pyramid(i_Game);
            Add(m_Pyramid);
            m_Stick = new Stick(i_Game, Color.Blue, new Vector3(0, 1, 0), new Vector3(.1f, 1f, .1f));
            Add(m_Stick);
        }
    }
}
