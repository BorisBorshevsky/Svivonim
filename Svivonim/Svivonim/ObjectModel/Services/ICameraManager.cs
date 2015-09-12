using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dreidels.ObjectModel.Services
{
    interface ICameraManager
    {
        Matrix CameraSettings { get; }
        Matrix CameraState { get; }

    }

}
