using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    class Dreidel1 : DreidelBase
    {
        public Dreidel1(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position, Color.Red)
        {
            m_Body = new ColorBox(i_Game, Vector3.Zero);
            Add(m_Body);

        }
    }
}
