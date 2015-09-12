using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel.Services
{
    public interface ICameraManager
    {
        Matrix CameraSettings { get; }
        Matrix CameraState { get; }

    }

}
