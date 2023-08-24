using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TestAutomation.Core.Utils
{
    public static class Waiters
    {
        public static void WaitForPageLoad() => Browser.Browser.Instance.Waiters().Until(condition => Browser.Browser.Instance.ExecuteScript("return document.readyState").Equals("complete"));

        public static void WaitForCondition(Func<bool> condition) => Browser.Browser.Instance.Waiters().Until(x => condition.Invoke());

    }
}
