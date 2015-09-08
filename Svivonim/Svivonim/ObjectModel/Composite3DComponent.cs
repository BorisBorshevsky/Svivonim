using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Svivonim.ObjectModel
{
    class Composite3DComponent : Base3DElement
    {
        readonly List<Base3DElement> r_Components = new List<Base3DElement>(); 
        
        public Composite3DComponent(Game i_Game) : base(i_Game)
        {
            i_Game.Components.Add(this);
        }
        public void Add(Base3DElement i_Element)
        {
            if (!r_Components.Contains(i_Element))
            {
                r_Components.Add(i_Element);
//                i_Element.Rotations = Rotations;
//                i_Drawable.Scales = Scales;
//                i_Drawable.Position = Position;
//                i_Drawable.SpinComponent = SpinComponent;

            }
        }


        public override void Initialize()
        {
            base.Initialize();

            r_Components.ForEach(i_Element => i_Element.Initialize());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            r_Components.ForEach(i_Element => i_Element.Update(gameTime));
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
            r_Components.ForEach(i_Element => i_Element.Draw(gameTime));
        }


        protected override void DoDraw(GameTime i_GameTime)
        {
            //do nothing
        }
    }
}
