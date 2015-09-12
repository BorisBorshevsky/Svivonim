using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Dreidels.ObjectModel;
using Infrastructure.Common;
using Infrastructure.ObjectModel;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dreidels
{
    class GameLogic : RegisteredComponent
    {
        private IInputManager m_InputManager;
        private readonly List<DreidelBase> r_Dradels = new List<DreidelBase>();
        private int m_SpinningDradles = 0;
        private Dictionary<Keys, eDradleSide> m_DreidelLettersKeys;
        private int m_Score = 0;
        private eDradleSide m_ChosenLetter = eDradleSide.UNKNOWN;

        private List<Vector3> m_PossiblePossitions = new List<Vector3>();
        private static readonly Random sr_Random = new Random();






        public GameLogic(Game i_Game)
            : base(i_Game)
        {
            
        }

        private void initializeRandomPositions()
        {
            for (int x = -12; x <= 12; x += 4)
            {
                for (int y = -10; y <= 10; y += 5)
                {
                    m_PossiblePossitions.Add(new Vector3(x, y, sr_Random.Next(-20, 20)));
                }
            }
        }

        public bool CanSpin
        {
            get { return m_SpinningDradles == 0 && m_ChosenLetter != eDradleSide.UNKNOWN; }
        }

        public override void Update(GameTime i_GameTime)
        {
            base.Update(i_GameTime);

            if (m_SpinningDradles == 0)
            {
                foreach (Keys key in m_DreidelLettersKeys.Keys)
                {
                    if (m_InputManager.KeyPressed(key))
                    {
                        m_ChosenLetter = m_DreidelLettersKeys[key];
                    }
                }
            }

            Game.Window.Title = "LetterChosen: " + m_ChosenLetter.GetDescription() + "   The Score is: " + m_Score;

            if (m_InputManager.KeyPressed(Keys.Space) && CanSpin)
            {
                r_Dradels.ForEach(i_Dradel =>
                {
                    i_Dradel.StartSpinning();
                    m_SpinningDradles++;
                });
            }
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

            getRandomPosition();

            r_Dradels.Add(new Dreidel1(Game, getRandomPosition()));
            r_Dradels.Add(new Dreidel2(Game, getRandomPosition()));
            r_Dradels.Add(new Dreidel3(Game, getRandomPosition()));
            r_Dradels.Add(new Dreidel1(Game, getRandomPosition()));
            r_Dradels.Add(new Dreidel2(Game, getRandomPosition()));
            r_Dradels.Add(new Dreidel3(Game, getRandomPosition()));

            r_Dradels.ForEach(i_Dreidel => i_Dreidel.Stopped += dreidelOnStopped);
        }

        private Vector3 getRandomPosition()
        {
            var item = sr_Random.Next(0, m_PossiblePossitions.Count);
            var randomPosition = m_PossiblePossitions[item];
            m_PossiblePossitions.RemoveAt(item);
            return randomPosition;
        }

        private void initializeLetters()
        {
            m_DreidelLettersKeys = new Dictionary<Keys, eDradleSide>();
            m_DreidelLettersKeys.Add(Keys.B, eDradleSide.NUN);
            m_DreidelLettersKeys.Add(Keys.D, eDradleSide.GIMEL);
            m_DreidelLettersKeys.Add(Keys.V, eDradleSide.HEY);
            m_DreidelLettersKeys.Add(Keys.P, eDradleSide.PEY);
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
                m_ChosenLetter = eDradleSide.UNKNOWN; ;
            }

        }
    }
}
