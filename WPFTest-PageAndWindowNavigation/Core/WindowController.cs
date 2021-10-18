using System;
using System.Collections.Generic;
using System.Windows;

namespace WPFTest_PageAndWindowNavigation.Core
{
    public class WindowController
    {
        private readonly Dictionary<Type,Type> _vmToWindowMap = new();
        private readonly Dictionary<object, Window> _openedWindows = new();

        public void RegisterVMAndWindow<VM, Win>()
            where VM : class
            where Win : Window
        {
            var typeVm = typeof(VM);
            if (typeVm.IsInterface || typeVm.IsAbstract)
                throw new ArgumentException(nameof(typeVm) + " can't to register");

            if (_vmToWindowMap.ContainsKey(typeVm))
                throw new InvalidOperationException(nameof(typeVm) + " is registered");

            _vmToWindowMap[typeVm] = typeof(Win);
        }

        private Window CreateWindowWithVM(object vm)
        {
            if (!_vmToWindowMap.TryGetValue(vm.GetType(), out Type? windType))
                throw new InvalidOperationException($"For {nameof(vm)} not found window");

            if (windType is null)
                throw new ArgumentNullException(nameof(windType));

            var wind = (Window)Activator.CreateInstance(windType);
            wind.DataContext = vm;
            return wind;
        }

        public void ShowWindow(object vm)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm));

            if (_openedWindows.ContainsKey(vm))
                throw new InvalidOperationException($"UI for {nameof(vm)} is displayed");

            var window = CreateWindowWithVM(vm);
            _openedWindows[vm] = window;
            window.Show();
        }

        public void HideWindow(object vm)
        {
            if (!_openedWindows.TryGetValue(vm, out Window? wind))
                throw new InvalidOperationException($"UI for this {nameof(vm)} is not displlayed");

            wind.Close();
            _openedWindows.Remove(vm);
        }
    }
}
