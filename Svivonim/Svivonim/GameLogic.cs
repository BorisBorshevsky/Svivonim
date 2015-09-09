using System.Collections.Generic;
using Dreidels.ObjectModel;
using Infrastructure.ObjectModel;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dreidels
{
    class GameLogic : RegisteredComponent
    {
        private IInputManager m_InputManager;
        private readonly List<BaseDreidel> r_Dradels = new List<BaseDreidel>();
        private int m_SpinningDradles = 0;
       
        public GameLogic(Game i_Game) : base(i_Game)
        {
        }

        public bool CanSpin
        {
            get { return m_SpinningDradles == 0; }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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

            //initialize models
            r_Dradels.Add(new Dreidel1(Game, new Vector3(-5, -5, 0)));
            r_Dradels.Add(new Dreidel3(Game, new Vector3(-5, 5, 0)));

            r_Dradels.ForEach(dreidel => dreidel.Stopped += DreidelOnStopped);


        }

        private void DreidelOnStopped(DradleSide dreidelSide)
        {
            m_SpinningDradles--;
            //add score
        }
    }
}
