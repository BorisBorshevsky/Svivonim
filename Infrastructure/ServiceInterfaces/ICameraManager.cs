using Microsoft.Xna.Framework;

namespace Infrastructure.ServiceInterfaces
{
    public interface ICameraManager
    {
        Matrix CameraSettings { get; }
        Matrix CameraState { get; }
    }
}