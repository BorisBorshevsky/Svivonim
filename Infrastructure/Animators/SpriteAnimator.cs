//*** Guy Ronen � 2008-2011 ***//

using System;
using Infrastructure.Animators.ConcreteAnimators;
using Infrastructure.ObjectModel2D;
using Microsoft.Xna.Framework;

namespace Infrastructure.Animators
{
    public abstract class SpriteAnimator
    {
        private Sprite m_BoundSprite;
        private TimeSpan m_AnimationLength;
        private bool m_IsFinished = false;
        private bool m_Enabled = true;
        private bool m_Initialized = false;
        private string m_Name;
        protected bool m_ResetAfterFinish = true;
        protected internal Sprite OriginalSpriteInfo;

        public event EventHandler Finished;


        protected TimeSpan TimeLeft { get; private set; }

        protected virtual void OnFinished()
        {
            if (m_ResetAfterFinish)
            {
                Reset();
                m_IsFinished = true;
            }


            if (GetType() == typeof (ShrinkAnimator))
            {
                
            }

            if (Finished != null)
            {
                Finished(this, EventArgs.Empty);
            }
        }

        protected SpriteAnimator(string i_Name, TimeSpan i_AnimationLength)
        {
            m_Name = i_Name;
            m_AnimationLength = i_AnimationLength;
        }

        protected internal Sprite BoundSprite
        {
            get { return m_BoundSprite; }
            set { m_BoundSprite = value; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public bool Enabled
        {
            get { return m_Enabled; }
            set { m_Enabled = value; }
        }

        public bool IsFinite
        {
            get { return m_AnimationLength != TimeSpan.Zero; }
        }

        public bool ResetAfterFinish
        {
            get { return m_ResetAfterFinish; }
            set { m_ResetAfterFinish = value; }
        }

        public virtual void Initialize()
        {
            if (!m_Initialized)
            {
                m_Initialized = true;

                CloneSpriteInfo();
//                TimeLeft = m_AnimationLength;
                Reset();
            }
        }

        protected virtual void CloneSpriteInfo()
        {
            if (OriginalSpriteInfo == null)
            {
                OriginalSpriteInfo = m_BoundSprite.ShallowClone();
            }
        }

        public void Reset()
        {
            Reset(m_AnimationLength);
        }

        public void Reset(TimeSpan i_AnimationLength)
        {
            if (!m_Initialized)
            {
                Initialize();
            }
            else
            {
                m_AnimationLength = i_AnimationLength;
                TimeLeft = m_AnimationLength;
                IsFinished = false;
            }

            RevertToOriginal();
        }

        protected abstract void RevertToOriginal();

        public void Pause()
        {
            Enabled = false;
        }

        public void Resume()
        {
            m_Enabled = true;
        }

        public virtual void Restart()
        {
            Restart(m_AnimationLength);
        }

        public virtual void Restart(TimeSpan i_AnimationLength)
        {
            Reset(i_AnimationLength);
            Resume();
        }

        protected TimeSpan AnimationLength
        {
            get { return m_AnimationLength; }
        }

        public bool IsFinished
        {
            get { return m_IsFinished; }
            protected set
            {
                if (value != m_IsFinished)
                {
                    m_IsFinished = value;
                    if (m_IsFinished == true)
                    {
                        OnFinished();
                    }
                }
            }
        }

        public void Update(GameTime i_GameTime)
        {
            if (!m_Initialized)
            {
                Initialize();
            }

            if (GetType() != typeof(CompositeAnimator))
            {

            }

            if (Enabled && !IsFinished)
            {
                if (IsFinite)
                {
                    // check if we should stop animating:
                    TimeLeft -= i_GameTime.ElapsedGameTime;

                    if (TimeLeft.TotalSeconds < 0)
                    {
                        IsFinished = true;
                    }
                }

                if (!IsFinished)
                {
                    // we are still required to animate:

                    DoFrame(i_GameTime);
                }
            }
        }

        protected abstract void DoFrame(GameTime i_GameTime);
    }
}
