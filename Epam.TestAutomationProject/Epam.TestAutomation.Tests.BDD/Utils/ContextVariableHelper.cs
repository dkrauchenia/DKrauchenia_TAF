using NUnit.Framework.Internal;

namespace Epam.TestAutomation.Tests.BDD.Utils
{
    public static class ContextVariableHelper
    {
        public static void SetValueToContext(string key, object value)
        {
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(key, value);
        }

        public static T GetValueFromContext<T>(string key)
        {
            return (T)NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get(key);
        }

        public static bool IsValueExist(string key)
        {
            return NUnit.Framework.TestContext.CurrentContext.Test.Properties.ContainsKey(key);
        }
    }
}
