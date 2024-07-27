using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace WinApp.Automation.Models
{
    public class ElementInfo
    {
        public string Name { get; set; }
        public string AutomationId { get; set; }
        public ControlType ControlType { get; set; }
        public IReadOnlyCollection<AutomationPattern> SupportedPatterns { get; set; }
        public ElementInfo Parent { get; set; }
    }
}
