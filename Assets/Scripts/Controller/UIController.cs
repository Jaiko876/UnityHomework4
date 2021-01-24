using Interface;
using UI;

namespace Controller
{
    public class UiController : IInitialization, IExecution, ICleanup, ITrigger
    {
        private Menu _menu;
        private UIView _uiView;

        public UiController(Menu menu, UIView uiView)
        {
            _menu = menu;
            _uiView = uiView;
        }

        public void Initialize()
        {
            _menu.InitializeMenu();
            _uiView.InitializeUIView();
            SetUISpeedInfo(0f);
        }

        public void Execute(float deltaTime)
        {
            _menu.ReadInput();
        }

        public void Cleanup()
        {
        }

        public void Interact(float value)
        {
            SetUISpeedInfo(value);
        }

        private void SetUISpeedInfo(float value)
        {
            var speed = _uiView.DefaultSpeedValue + value;
            _uiView.SetSpeedInfo($"Speed: {speed}");
        }

        public bool IsPaused()
        {
            return _menu.IsPaused;
        }

        public Menu Menu
        {
            get => _menu;
            set => _menu = value;
        }

        public UIView UiView
        {
            get => _uiView;
            set => _uiView = value;
        }
    }
}