using Infrastructure.ObjectModel2D;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infrastructure.Managers
{
    public class FontManager : GameService, IFontManager
    {
        private readonly string r_AssetName;
        private SpriteFont m_SpriteFont;

        public FontManager(Game i_Game, string i_AssetName)
            : base(i_Game)
        {
            r_AssetName = i_AssetName;
        }

        public override void Initialize()
        {
            m_SpriteFont = Game.Content.Load<SpriteFont>(r_AssetName);
        }

        protected override void RegisterAsService()
        {
            Game.Services.AddService(typeof(IFontManager), this);
        }

        public SpriteFont SpriteFont
        {
            get { return m_SpriteFont; }
        }
    }
}