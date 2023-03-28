using System;
using ReactiveUI;
using AudioVision.ViewModels;
using AudioVision.Views;

namespace AudioVision
{
    class AppViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string? contract = null) => viewModel switch
        {
            SelectFilesViewModel context => new SelectFilesView { DataContext = context },
            TranscodeProgressViewModel context => new TranscodeProgressView { DataContext = context },
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}