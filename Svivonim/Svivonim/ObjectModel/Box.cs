using Infrastructure.ObjectModel3D;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel
{
    abstract class Box : Composite3DComponent
    {
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
            const bool r_VIsRenderedClockwise = true;
            Add(new SideWall(i_Game, Vector3.One, new Vector3(0, 1, 0), r_VIsRenderedClockwise));
            Add(new SideWall(i_Game, Vector3.One, new Vector3(0, -1, 0) , !r_VIsRenderedClockwise));
        }

        protected Box(Game i_Game, Vector3 i_Position)
            : this(i_Game)
        {
            Position = i_Position;
        }

        protected Box(Game i_Game, Vector3 i_Position, Vector3 i_Scale)
            : this(i_Game, i_Position)
        {
            m_Scale = i_Scale;
        }

        protected override Vector3[] CreateStartCoordinates()
        {
            var coordinates = new Vector3[8];
            coordinates[0] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_MinZCoordinate) * m_Scale + Position; //bottom left front
            coordinates[1] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_MinZCoordinate) * m_Scale + Position; //top left front
            coordinates[2] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_MinZCoordinate) * m_Scale + Position; //top right front
            coordinates[3] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_MinZCoordinate) * m_Scale + Position; //bottom right front
            coordinates[4] = new Vector3(k_MaxXCoordinate, k_MinYCoordinate, k_MaxZCoordinate) * m_Scale + Position; //bottom right back
            coordinates[5] = new Vector3(k_MaxXCoordinate, k_MaxYCoordinate, k_MaxZCoordinate) * m_Scale + Position; //top right back
            coordinates[6] = new Vector3(k_MinXCoordinate, k_MaxYCoordinate, k_MaxZCoordinate) * m_Scale + Position; //top left back
            coordinates[7] = new Vector3(k_MinXCoordinate, k_MinYCoordinate, k_MaxZCoordinate) * m_Scale + Position; //bottom left back
            return coordinates;
        }
    }
}