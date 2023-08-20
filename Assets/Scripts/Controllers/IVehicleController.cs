using UnityEngine;

namespace Controllers
{
    public interface IVehicleController
    {
        void Move(bool isForward);
        void StopMoving();
        void SetVehiclePos(Vector3 position);
    }
}