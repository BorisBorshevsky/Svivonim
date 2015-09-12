using System;
using System.Collections.Generic;
using Dreidels.ObjectModel;
using Infrastructure.Common;
using Infrastructure.ObjectModel2D;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dreidels
{
    class GameLogic : RegisteredComponent
    {
        private IInputManager m_InputManager;
        private eDradleSide m_ChosenLetter = eDradleSide.Unknown;

        private int m_SpinningDradles = 0;
        private int m_Score = 0;

        private static readonly Random r_Random = new Random();
        private readonly Dictionary<Keys, eDradleSide> r_DreidelLettersKeys = new Dictionary<Keys, eDradleSide>();
        private readonly List<DreidelBase> r_Dradels = new List<DreidelBase>();
        private readonly List<Vector3> r_PossiblePossitions = new List<Vector3>();
        
        private const int k_MinDreidelXPosition = -12;
        private const int k_MaxDreidelXPosition = 12;
        private const int k_DreidelXPositionJumpInterval = 4;
        private const int k_MinDreidelYPosition = -10;
        private const int k_MaxDreidelYPosition = 10;
        private const int k_DreidelYPositionJumpInterval = 5;
        private const int k_MinDreidelZPosition = -20;
        private const int k_MaxDreidelZPosition = 20;

        public GameLogic(Game i_Game)
            : base(i_Game)
        { }

        private void initializeRandomPositions()
        {
            for (int x = k_MinDreidelXPosition; x <= k_MaxDreidelXPosition; x += k_DreidelXPositionJumpInterval)
            {
                for (int y = k_MinDreidelYPosition; y <= k_MaxDreidelYPosition; y += k_DreidelYPositionJumpInterval)
                {
                    r_PossiblePossitions.Add(new Vector3(x, y, r_Random.Next(k_MinDreidelZPosition, k_MaxDreidelZPosition)));
                }
            }
        }

        public bool CanSpin
        {
            get { return m_SpinningDradles == 0 && m_ChosenLetter != eDradleSide.Unknown; }
        }

        public override void Update(GameTime i_GameTime)
        {
            base.Update(i_GameTime);

            if (m_SpinningDradles == 0)
            {
                foreach (Keys key in r_DreidelLettersKeys.Keys)
                {
                    if (m_InputManager.KeyPressed(key))
                    {
                        m_ChosenLetter = r_DreidelLettersKeys[key];
                    }
                }
            }

            updateTitle();
            if (m_InputManager.KeyPressed(Keys.Space) && CanSpin)
            {
                r_Dradels.ForEach(i_Dradel =>
                {
                    i_Dradel.StartSpinning();
                    m_SpinningDradles++;
                });
            }
        }

        private void updateTitle()
        {
            Game.Window.Title = "Letter Chosen: " + m_ChosenLetter.GetDescription() + "   The Score is: " + m_Score;
        }

        public override void Initialize()
        {
            base.Initialize();
            
            m_InputManager = Game.Services.GetService<IInputManager>();
            
            initializeRandomPositions();
            initializeLetters();
            initializeDradles();
        }

        private void initializeDradles()
        {
            r_Dradels.Add(new PositionColorDradle(Game, getRandomPosition()));
            r_Dradels.Add(new TriangleStripDradle(Game, getRandomPosition()));
            r_Dradels.Add(new VertexBufferDradle(Game, getRandomPosition()));
            r_Dradels.Add(new PositionColorDradle(Game, getRandomPosition()));
            r_Dradels.Add(new TriangleStripDradle(Game, getRandomPosition()));
            r_Dradels.Add(new VertexBufferDradle(Game, getRandomPosition()));

            r_Dradels.ForEach(i_Dreidel =>
            {
                i_Dreidel.Initialize();
                i_Dreidel.Stopped += dreidelOnStopped;
            });
        }

        private Vector3 getRandomPosition()
        {
            int item = r_Random.Next(0, r_PossiblePossitions.Count);
            Vector3 randomPosition = r_PossiblePossitions[item];
            r_PossiblePossitions.RemoveAt(item);
            return randomPosition;
        }

        private void initializeLetters()
        {
            r_DreidelLettersKeys.Add(Keys.B, eDradleSide.Nun);
            r_DreidelLettersKeys.Add(Keys.D, eDradleSide.Gimel);
            r_DreidelLettersKeys.Add(Keys.V, eDradleSide.Hey);
            r_DreidelLettersKeys.Add(Keys.P, eDradleSide.Pey);
        }

        private void dreidelOnStopped(eDradleSide i_DreidelSide)
        {
            m_SpinningDradles--;
            if (i_DreidelSide == m_ChosenLetter)
            {
                m_Score++;
            }

            if (m_SpinningDradles == 0)
            {
                m_ChosenLetter = eDradleSide.Unknown;
            }
        }

        public int MinimumDreidelXPosition { get; set; }

    }
}