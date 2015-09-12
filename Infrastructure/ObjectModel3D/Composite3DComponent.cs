using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Infrastructure.ObjectModel3D
{
    public class Composite3DComponent : Base3DElement
    {
        readonly List<Base3DElement> r_Components = new List<Base3DElement>(); 
        
        public Composite3DComponent(Game i_Game) : base(i_Game)
        { }
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

        public override void Update(GameTime i_GameTime)
        {
            base.Update(i_GameTime);
            r_Components.ForEach(i_Element => i_Element.Update(i_GameTime));
        }

        protected override Vector3[] CreateStartCoordinates()
        {
            throw new InvalidOperationException();
        }

        protected override short[] CreateIndicesMapping()
        {
            throw new InvalidOperationException();
        }

        public override void Draw(GameTime i_GameTime)
        {
            base.Draw(i_GameTime);
            
            r_Components.ForEach(i_Element => i_Element.Draw(i_GameTime));
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