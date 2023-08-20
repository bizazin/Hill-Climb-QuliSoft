using Core.Abstracts;
using Databases;
using Views;
using Zenject;

namespace Controllers.Impls
{
    public class TrackController : Controller<TrackView>, IInitializable
    {
        private readonly ITrackSettingsDatabase _trackSettingsDatabase;
        private readonly IVehicleController _vehicleController;

        public TrackController
        (
            ITrackSettingsDatabase trackSettingsDatabase,
            IVehicleController vehicleController
        )
        {
            _trackSettingsDatabase = trackSettingsDatabase;
            _vehicleController = vehicleController;
        }

        public void Initialize()
        {
            _vehicleController.SetVehiclePos(View.VehicleSpawnTransform.position);
            View.SetupTrack(_trackSettingsDatabase.Settings.LevelLength, _trackSettingsDatabase.Settings.XMultiplier,
                _trackSettingsDatabase.Settings.YMultiplier, _trackSettingsDatabase.Settings.NoiseStep,
                _trackSettingsDatabase.Settings.CurveSmoothness, _trackSettingsDatabase.Settings.Bottom);
        }
    }
}