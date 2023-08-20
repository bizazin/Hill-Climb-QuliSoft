using Cinemachine;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CinemachineCameraBehaviour : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

        [Inject]
        private void Construct
        (
            VehicleBehaviour vehicleBehaviour
        )
        {
            cinemachineVirtualCamera.Follow = vehicleBehaviour.transform;
        }
    }
}