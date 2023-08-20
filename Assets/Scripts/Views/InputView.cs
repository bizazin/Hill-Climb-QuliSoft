using Core.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class InputView : View
    {
        [SerializeField] private Button forwardButton;
        [SerializeField] private Button backwardButton;

        public Button ForwardButton => forwardButton;

        public Button BackwardButton => backwardButton;
    }
}