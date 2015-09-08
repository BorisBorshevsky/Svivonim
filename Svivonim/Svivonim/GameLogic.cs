using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.ObjectModel;
using Infrastructure.ServiceInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Svivonim.ObjectModel;

namespace Svivonim
{
    class GameLogic : RegisteredComponent
    {

        private IInputManager m_InputManager;
        private readonly List<Dradel> r_Dradels = new List<Dradel>();
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
                    i_Dradel.StartSpining();
                    m_SpinningDradles++;
                });
            }

        }





        public override void Initialize()
        {
            base.Initialize();
            m_InputManager = Game.Services.GetService<IInputManager>();





            //initialize models
            r_Dradels.Add(new Dradel(Game, new Vector3(-5, -5, 0)));
            r_Dradels.Add(new Dradel(Game, new Vector3(-5, 5, 0)));

            r_Dradels.ForEach(dradel => dradel.Stopped += DradelOnStopped);


        }

        private void DradelOnStopped(DradleSide dradleSide)
        {
            m_SpinningDradles--;
            //add score
        }
    }
}
