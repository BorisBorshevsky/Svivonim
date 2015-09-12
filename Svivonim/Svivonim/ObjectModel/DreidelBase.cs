using System;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    abstract class DreidelBase : Composite3DComponent
    {
        protected Base3DElement m_Body;
        protected Base3DElement m_Pyramid;
        protected Base3DElement m_Stick;
        static readonly Random sr_Random = new Random();

        protected DreidelBase(Game i_Game, Vector3 i_Position, Color i_StickColor)
            : base(i_Game)
        {
            Position = i_Position;
            m_Pyramid = new Pyramid(i_Game);
            Add(m_Pyramid);
            m_Stick = new Stick(i_Game, i_StickColor, new Vector3(0, 1, 0), new Vector3(.25f, 1f, .25f));
            Add(m_Stick);
        }

        public event Action<eDradleSide> Stopped;

        private void onStop()
        {
            SpinEnabled = false;;


            if (Stopped != null)
            {
                Stopped.Invoke(GetLetter());
            }
        }

        public void StartSpinning()
        {
            startRotationPerSecond = (float)sr_Random.Next(300, 1000) / 100;
            RotationsPerSecond = startRotationPerSecond;
            SpinEnabled = true;
        }

        private float startRotationPerSecond;


        public override void Update(GameTime gameTime)
        {
            if (!temp)
            {
                Console.WriteLine(Rotations.Y % MathHelper.TwoPi);
                temp = true;
            }


            base.Update(gameTime);

            if (SpinEnabled) { 
//                if (RotationsPerSecond > MathHelper.PiOver2)
//                {
                    RotationsPerSecond -= (float)gameTime.ElapsedGameTime.TotalSeconds;
//                }
//                else if (Rotations.Y % MathHelper.PiOver2 < 0.4)
//                {
//                    RotationsPerSecond -= (float)gameTime.ElapsedGameTime.TotalSeconds * 5;
//                }


                
                
                if (RotationsPerSecond <= 0)
                {
                    Console.WriteLine("Y: " + Rotations.Y + " delta: " + Rotations.Y % MathHelper.TwoPi);
                    Console.WriteLine(GetLetter());
                    onStop();
                }
            }

        }

        private bool temp = false;

        public eDradleSide GetLetter()
        {
            eDradleSide dradleSide;

            float rotationY = Rotations.Y % MathHelper.Pi;
            int x = 0;
//            while (rotationY - MathHelper.PiOver2 > 0)
//            {
//                rotationY -= MathHelper.PiOver2;
//                x++;
//            }
            rotationY *= 2;

            if (rotationY < MathHelper.PiOver4)
            {
                x = 0;
            }
            else if (rotationY < MathHelper.PiOver2 + MathHelper.PiOver4 )
            {
                x = 1;
            }
            else if (rotationY < MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver4)
            {
                x = 2;
            }
            else if (rotationY < MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver2 + MathHelper.PiOver4)
            {
                x = 3;
            }
            else
            {
                x = 0;
            }




            switch (x)
            {
                case 0:
                    dradleSide = eDradleSide.PEY;
                    break;
                case 1:
                    dradleSide = eDradleSide.GIMEL;
                    break;
                case 2:
                    dradleSide = eDradleSide.NUN ;
                    break;
                case 3:
                    dradleSide = eDradleSide.HEY;
                    break;
                default: throw new Exception("should not happen");
            }
            return dradleSide;
        }

    }
}
