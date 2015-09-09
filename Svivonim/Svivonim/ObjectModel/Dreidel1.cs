using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    class Dreidel1 : BaseDreidel
    {
        public Dreidel1(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position)
        {
            m_Body = new ColorBox(i_Game, Vector3.Zero);
            Add(m_Body);
            m_Pyramid = new Pyramid(i_Game);
            Add(m_Pyramid);
            m_Stick = new Stick(i_Game, Color.Blue, new Vector3(0, 1, 0), new Vector3(.1f, 1f, .1f));
            Add(m_Stick);
        }
    }
}
