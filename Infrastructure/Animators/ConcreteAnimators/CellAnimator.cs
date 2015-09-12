//*** Guy Ronen © 2008-2011 ***//

using System;
using Microsoft.Xna.Framework;

namespace Infrastructure.Animators.ConcreteAnimators
{
    public class CellAnimator : SpriteAnimator
    {
        private TimeSpan m_CellTime;
        private TimeSpan m_TimeLeftForCell;
        private bool m_Loop = true;
        private int m_CurrCellIdx = 0;
        private readonly int r_NumOfCells = 1;

        public CellAnimator(TimeSpan i_CellTime, int i_NumOfCells, TimeSpan i_AnimationLength)
            : base("CelAnimation", i_AnimationLength)
        {
            m_CellTime = i_CellTime;
            m_TimeLeftForCell = i_CellTime;
            r_NumOfCells = i_NumOfCells;

            m_Loop = i_AnimationLength == TimeSpan.Zero;
        }

        private void goToNextFrame()
        {
            m_CurrCellIdx++;
            if (m_CurrCellIdx >= r_NumOfCells)
            {
                if (m_Loop)
                {
                    m_CurrCellIdx = 0;
                }
                else
                {
                    m_CurrCellIdx = r_NumOfCells - 1; // lets stop at the last frame
                    IsFinished = true;
                }
            }
        }

        protected override void RevertToOriginal()
        {
            BoundSprite.SourceRectangle = OriginalSpriteInfo.SourceRectangle;
        }

        protected override void DoFrame(GameTime i_GameTime)
        {
            if (m_CellTime != TimeSpan.Zero)
            {
                m_TimeLeftForCell -= i_GameTime.ElapsedGameTime;
                if (m_TimeLeftForCell.TotalSeconds <= 0)
                {
                    // we have elapsed, so blink
                    goToNextFrame();
                    m_TimeLeftForCell = m_CellTime;
                }
            }

            BoundSprite.SourceRectangle = new Rectangle(
                m_CurrCellIdx * BoundSprite.SourceRectangle.Width,
                BoundSprite.SourceRectangle.Top,
                BoundSprite.SourceRectangle.Width,
                BoundSprite.SourceRectangle.Height);
        }
    }
}
