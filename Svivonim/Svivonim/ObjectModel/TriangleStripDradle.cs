using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    class TriangleStripDradle : DreidelBase
    {
        public TriangleStripDradle(Game i_Game, Vector3 i_Position)
            : base(i_Game, i_Position, Color.White)
        {
            m_Body = new TextureTriangleStripBox(i_Game, Vector3.Zero);
            Add(m_Body);
        }
    }
}