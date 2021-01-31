using System;
using System.Collections.Generic;
using System.Threading;
using Enum;
using Interface;

namespace Controller
{
    internal sealed class ControllerMaster : IInitialization, IExecution, ILateExecution, ICleanup
    {
        private readonly List<IInitialization> _initControllers;
        private readonly List<IExecution> _executeControllers;
        private readonly List<ILateExecution> _lateExecuteControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private static Dictionary<Type, IController> _controllerMap;

        internal ControllerMaster()
        {
            _initControllers = new List<IInitialization>();
            _executeControllers = new List<IExecution>();
            _lateExecuteControllers = new List<ILateExecution>();
            _cleanupControllers = new List<ICleanup>();
            _controllerMap = new Dictionary<Type, IController>();
        }

        internal ControllerMaster Add(IController controller)
        {
            if (controller is IInitialization initController)
            {
                _initControllers.Add(initController);
            }

            if (controller is IExecution executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ILateExecution lateExecuteController)
            {
                _lateExecuteControllers.Add(lateExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
            
            _controllerMap.Add(controller.GetType(), controller);

            return this;
        }

        public void Initialize()
        {
            foreach (var initController in _initControllers)
            {
                initController.Initialize();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var executeController in _executeControllers)
            {
                executeController.Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            foreach (var lateExecuteController in _lateExecuteControllers)
            {
                lateExecuteController.LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            foreach (var cleanupController in _cleanupControllers)
            {
                cleanupController.Cleanup();
            }
        }

        public static IController InjectController(Type type)
        {
            return _controllerMap[type];
        }
    }
}