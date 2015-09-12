using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    abstract class Box : Composite3DComponent
    {
        protected Vector3 Position = Vector3.Zero;
        protected Vector3 Scale = Vector3.One;
        protected short[] m_Indices;


        protected const float k_MaxZCoordinate = 1;
        protected const float k_MinZCoordinate = -1f;
        protected const float k_MinXCoordinate = -1;
        protected const float k_MaxXCoordinate = 1;
        protected const float k_MinYCoordinate = -1;
        protected const float k_MaxYCoordinate = 1;

        protected Box(Game i_Game)
            : base(i_Game)
        {
            this.Add(new SideWall(i_Game, Vector3.One, new Vector3(0, 1, 0), true));
            this.Add(new SideWall(i_Game, Vector3.One, new Vector3(0, -1, 0)));
        }

        protected Box(Game i_Game, Vector3 i_Position)
            : this(i_Game)
        {
            this.Position = i_Position;
        }

        protected Box(Game i_Game, Vector3 i_Position, Vector3 i_Scale)
            : this(i_Game, i_Position)
        {
            this.Scale = i_Scale;
        }

        protected override Vector3[] createStartCoordinates()
        {
            var coordinates = new Vector3[8];
            coordinates[0] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_MinZCoordinate) * Scale + Position; //bottom left front
            coordinates[1] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_MinZCoordinate) * Scale + Position; //top left front
            coordinates[2] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_MinZCoordinate) * Scale + Position; //top right front
            coordinates[3] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_MinZCoordinate) * Scale + Position; //bottom right front
            coordinates[4] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_MaxZCoordinate) * Scale + Position; //bottom right back
            coordinates[5] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_MaxZCoordinate) * Scale + Position; //top right back
            coordinates[6] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_MaxZCoordinate) * Scale + Position; //top left back
            coordinates[7] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_MaxZCoordinate) * Scale + Position; //bottom left back
            return coordinates;
        }
    }
}
