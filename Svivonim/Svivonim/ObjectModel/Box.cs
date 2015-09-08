using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Svivonim.ObjectModel
{
    abstract class Box : Base3DElement
    {
        public Box(Game i_Game )
            : base(i_Game)
        {
        }

        public Box(Game i_Game, Vector3 Position) : this(i_Game)
        {
            this.Position = Position;
        }

        public Box(Game i_Game, Vector3 Position, Vector3 Scale)
            : this(i_Game, Position)
        {
            this.Scale = Scale;
        }

        protected Vector3 Position = Vector3.Zero;
        protected Vector3 Scale = Vector3.One;

        protected const float k_MaxZCoordinate = 1;
        protected const float k_MinZCoordinate = -1f;
        protected const float k_MinXCoordinate = -1;
        protected const float k_MaxXCoordinate = 1;
        protected const float k_MinYCoordinate = -1;
        protected const float k_MaxYCoordinate = 1;


        protected override Vector3[] createStartCoordinates()
        {
            var cordinates = new Vector3[8];
            cordinates[0] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_MinZCoordinate) * Scale + Position; //bottom left front
            cordinates[1] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_MinZCoordinate) * Scale + Position; //top left front
            cordinates[2] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_MinZCoordinate) * Scale + Position; //top right front
            cordinates[3] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_MinZCoordinate) * Scale + Position; //bottom right front
            cordinates[4] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_MaxZCoordinate) * Scale + Position; //bottom right back
            cordinates[5] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_MaxZCoordinate) * Scale + Position; //top right back
            cordinates[6] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_MaxZCoordinate) * Scale + Position; //top left back
            cordinates[7] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_MaxZCoordinate) * Scale + Position; //bottom left back
            return cordinates;
        }

        

    }
}
