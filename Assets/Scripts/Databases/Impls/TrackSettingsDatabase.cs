using Models;
using UnityEngine;

namespace Databases.Impls
{
    [CreateAssetMenu(menuName = "Databases/TrackSettingsDatabase", fileName = "TrackSettingsDatabase")]
    public class TrackSettingsDatabase : ScriptableObject, ITrackSettingsDatabase
    {
        [SerializeField] private TrackSettingsVo trackSettings;

        public TrackSettingsVo Settings => trackSettings;
    }
}