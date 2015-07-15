using Microsoft.Win32;
using System.Activities.Presentation;
using System.IO;
using System.Windows.Input;
using System.Wpf.Mvvm;
using System.Wpf.Mvvm.Commands;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace WorkfFlowRehosted.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        public MainWindowViewModel(DockingManager dm, WorkflowDesigner wf)
        {
            SaveCommand = new DelegateCommand((o) =>
            {
                var of = new SaveFileDialog();
                of.Filter = "Workflow File (*.wf;*.xaml)|*.wf;*.xaml";

                if (of.ShowDialog().Value)
                {
                    wf.Save(of.FileName);
                }
            }, (o) => true);

            LoadCommand = new DelegateCommand((o) =>
            {
                var of = new OpenFileDialog();
                of.Filter = "Workflow File (*.wf;*.xaml)|*.wf;*.xaml";

                if (of.ShowDialog().Value)
                {
                    wf.Load(of.FileName);
                }
            }, (o) => true);
        }
    }
}