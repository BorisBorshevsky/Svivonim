using System;
using Microsoft.Xna.Framework;

namespace Infrastructure.Animators.ConcreteAnimators
{
    public class ShrinkAnimator : SpriteAnimator
    {
        public ShrinkAnimator(string i_Name, TimeSpan i_AnimationLength)
            : base(i_Name, i_AnimationLength)
        {
        }

        public ShrinkAnimator(TimeSpan i_AnimationLength)
            : this("Shrink", i_AnimationLength)
        {
        }

        protected override void DoFrame(GameTime i_GameTime)
        {
            BoundSprite.Scales -= new Vector2((float)i_GameTime.ElapsedGameTime.TotalSeconds / (float)AnimationLength.TotalSeconds);
        }

        protected override void RevertToOriginal()
        {
            BoundSprite.Scales = OriginalSpriteInfo.Scales;
        }
    }
}