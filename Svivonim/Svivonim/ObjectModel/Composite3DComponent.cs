using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
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
                i_Element.Initialize();
                i_Element.RotationsPerSecond = RotationsPerSecond;
                i_Element.Scales = Scales;
                i_Element.Position = Position;
                i_Element.SpinEnabled = SpinEnabled;

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

        protected override Vector3[] createStartCoordinates()
        {
            throw new InvalidOperationException();
        }

        protected override short[] createIndicesMapping()
        {
            throw new InvalidOperationException();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
            r_Components.ForEach(i_Element => i_Element.Draw(gameTime));
        }

        public override bool SpinEnabled
        {
            set
            {
                base.SpinEnabled = value;
                foreach (var comp in r_Components)
                {
                    comp.SpinEnabled = value;
                }
            }
        }

        public override float RotationsPerSecond
        {
            set
            {
                base.RotationsPerSecond = value;
                foreach (var comp in r_Components)
                {
                    comp.RotationsPerSecond = value;
                }
            }
            get { return base.RotationsPerSecond; }
        }

        public override Vector3 Position
        {
            set
            {
                base.Position = value;

                foreach (var comp in r_Components)
                {
                    comp.Position = value;
                }
            }
            get { return base.Position; }
        }

        public override Vector3 Scales
        {
            set
            {
                base.Scales = value;

                foreach (var comp in r_Components)
                {
                    comp.Scales = value;
                }
            }

            get { return base.Scales; }
        }


    
    }
}
