using System;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    class Dreidel3 : DreidelBase
    {

        public Dreidel3(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position, Color.Blue)
        {
            m_Body = new TextureBox(i_Game, Vector3.Zero);
            Add(m_Body);

        }
    }
}
