using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace WinApp.Automation.Models
{
    public class UpdateRootElementArgs
    {
        public AutomationElement NewRootElement { get; set; }
        public IntPtr NewHWnd { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public UpdateRootElementArgs(AutomationElement newRoot, IntPtr newHwnd)
        {
            NewRootElement = newRoot;
            NewHWnd = newHwnd;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
