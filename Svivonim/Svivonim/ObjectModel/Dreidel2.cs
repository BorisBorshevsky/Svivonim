using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    class Dreidel2 : DreidelBase
    {
        public Dreidel2(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position, Color.White)
        {
            m_Body = new TextureBoxStrip(i_Game, Vector3.Zero);
            Add(m_Body);

        }
    }
}
