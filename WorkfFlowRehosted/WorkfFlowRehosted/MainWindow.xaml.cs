using System.Windows;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Statements;
using WorkfFlowRehosted.ViewModel;

namespace WorkfFlowRehosted
{
    public partial class MainWindow : Window
    {
        WorkflowDesigner _designer;

        public MainWindow()
        {
            InitializeComponent();

            _designer = new WorkflowDesigner();

            Loaded += (s, e) => Layout.Load(dockingManager);
            Closed += (s, e) => Layout.Save(dockingManager);

            DesignerMetadata dm = new DesignerMetadata();
            dm.Register();

            toolboxBorder.Child = ToolboxService.GetToolboxControl();
            propertiesBorder.Child = _designer.PropertyInspectorView;
            outlineBorder.Child = _designer.OutlineView;
            designerBorder.Child = _designer.View;
            

            _designer.Load(new Sequence());

            DataContext = new MainWindowViewModel(dockingManager, _designer);
        }
    }
}