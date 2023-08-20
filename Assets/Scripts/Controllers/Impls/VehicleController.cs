using Behaviours;
using Core.Abstracts;
using Databases;
using UnityEngine;
using Zenject;

namespace Controllers.Impls
{
    public class VehicleController : Controller<VehicleBehaviour>, IVehicleController, IInitializable
    {
        private readonly IVehicleSettingsDatabase _vehicleSettingsDatabase;

        public VehicleController
        (
            IVehicleSettingsDatabase vehicleSettingsDatabase
        )
        {
            _vehicleSettingsDatabase = vehicleSettingsDatabase;
        }

        public void Initialize()
        {
            View.SetupVehicle(_vehicleSettingsDatabase.Settings.Speed, _vehicleSettingsDatabase.Settings.RotationSpeed);
        }

        public void Move(bool isForward) => View.Move(isForward);

        public void StopMoving() => View.StopMoving();
        
        public void SetVehiclePos(Vector3 position) => View.SetPosition(position);
    }
}