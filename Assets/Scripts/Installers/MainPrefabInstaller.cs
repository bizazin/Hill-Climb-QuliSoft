using Behaviours;
using Controllers.Impls;
using Databases;
using Databases.Impls;
using Extensions;
using UnityEngine;
using UnityEngine.UI;
using Views;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/MainPrefabInstaller", fileName = "MainPrefabInstaller")]
    public class MainPrefabInstaller : ScriptableObjectInstaller
    {
        [Header("Databases")] 
        [SerializeField] private VehicleSettingsDatabase vehicleSettingsDatabase;
        [SerializeField] private TrackSettingsDatabase trackSettingsDatabase;
        
        [Header("Canvas")] 
        [SerializeField] private Canvas canvas;
        
        [Header("Ui Views")]
        [SerializeField] private InputView inputView;

        [Header("Behaviours")] 
        [SerializeField] private VehicleBehaviour vehicleBehaviour;
        [SerializeField] private TrackView trackView;
        [SerializeField] private CinemachineCameraBehaviour cinemachineCameraBehaviour;
        
        public override void InstallBindings()
        {
            BindDatabases();
            BindPrefabs();
            BindUiViews();
        }

        private void BindDatabases()
        {
            Container.Bind<IVehicleSettingsDatabase>().FromInstance(vehicleSettingsDatabase).AsSingle();
            Container.Bind<ITrackSettingsDatabase>().FromInstance(trackSettingsDatabase).AsSingle();
        }

        private void BindPrefabs()
        {
            var parent = new GameObject("GameWorld").transform;
            
            Container.BindView<VehicleController, VehicleBehaviour>(vehicleBehaviour, parent);
            Container.BindView<TrackController, TrackView>(trackView, parent);
            BindPrefab(cinemachineCameraBehaviour, parent).NonLazy();
        }
        
        private ConcreteIdArgConditionCopyNonLazyBinder BindPrefab<TContent>(TContent prefab, Transform parent)
            where TContent : Object =>
            Container.BindInterfacesAndSelfTo<TContent>()
                .FromComponentInNewPrefab(prefab)
#if UNITY_EDITOR
                .UnderTransform(parent)
#endif
                .AsSingle();


        private void BindUiViews()
        {
            Container.Bind<CanvasScaler>().FromComponentInNewPrefab(canvas).AsSingle();
            var parent = Container.Resolve<CanvasScaler>().transform;
            
            Container.BindView<InputController, InputView>(inputView, parent);
        }
    }
}