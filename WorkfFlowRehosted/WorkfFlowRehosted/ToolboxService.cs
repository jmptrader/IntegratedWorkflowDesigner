using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;

namespace WorkfFlowRehosted
{
    public static class ToolboxService
    {
        private static List<ToolboxCategory> _source;

        public static void AddCategory(ToolboxCategory cat)
        {
            _source.Add(cat);
        }

        static ToolboxService()
        {
            _source = new List<ToolboxCategory>();
        }

        // Get the filled Toolbox
        public static ToolboxControl GetToolboxControl()
        {
            // Create the ToolBoxControl.
            ToolboxControl ctrl = new ToolboxControl();

            foreach (var item in _source)
            {
                ctrl.Categories.Add(item);
            }

            // Create a category.
            ToolboxCategory category = new ToolboxCategory("category1");

            // Create Toolbox items.
            ToolboxItemWrapper tool1 =
                new ToolboxItemWrapper("System.Activities.Statements.Assign",
                typeof(Assign).Assembly.FullName, null, "Assign");

            ToolboxItemWrapper tool2 = new ToolboxItemWrapper("System.Activities.Statements.Sequence",
                typeof(Sequence).Assembly.FullName, null, "Sequence");

            // Add the Toolbox items to the category.
            category.Add(tool1);
            category.Add(tool2);

            // Add the category to the ToolBox control.
            ctrl.Categories.Add(category);
            return ctrl;
        }
    }
}