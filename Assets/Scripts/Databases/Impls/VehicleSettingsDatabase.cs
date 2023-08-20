using Models;
using UnityEngine;

namespace Databases.Impls
{
    [CreateAssetMenu(menuName = "Databases/VehicleSettingsDatabase", fileName = "VehicleSettingsDatabase")]
    public class VehicleSettingsDatabase : ScriptableObject, IVehicleSettingsDatabase
    {
        [SerializeField] private VehicleSettingsVo vehicleSettings;

        public VehicleSettingsVo Settings => vehicleSettings;
    }
}