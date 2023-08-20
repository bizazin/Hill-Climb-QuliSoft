using Core.Abstracts;
using UniRx;
using UniRx.Triggers;
using Views;
using Zenject;

namespace Controllers.Impls
{
    public class InputController : Controller<InputView>, IInitializable, IInputController
    {
        private readonly IVehicleController _vehicleController;

        public InputController
        (
            IVehicleController vehicleController
        )
        {
            _vehicleController = vehicleController;
        }
        
        public void Initialize()
        {
            View.ForwardButton.OnPointerDownAsObservable().Subscribe(_ => _vehicleController.Move(true)).AddTo(View);
            View.ForwardButton.OnPointerUpAsObservable().Subscribe(_ => _vehicleController.StopMoving()).AddTo(View);

            View.BackwardButton.OnPointerDownAsObservable().Subscribe(_ => _vehicleController.Move(false)).AddTo(View);
            View.BackwardButton.OnPointerUpAsObservable().Subscribe(_ => _vehicleController.StopMoving()).AddTo(View);

        }
    }
}