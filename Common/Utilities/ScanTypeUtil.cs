using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


internal class ScanTypeUtil
{
    public static Type[] GetTypeInNameSpace(Assembly assembly, String nameSpace)
    {
        return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
    }
}

