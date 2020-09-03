using System;
using System.Reflection;
namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            try
            {
                string answer = null;
                Assembly dllFileAssembly = Assembly.LoadFile(Console.ReadLine());
                foreach (var singleClass in dllFileAssembly.GetTypes())
                {
                    answer += singleClass.Name + '\n';
                    MethodInfo[] methodInfo = singleClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    Array.ForEach(methodInfo, x => answer += x.GetBaseDefinition().DeclaringType != typeof(object) && (x.IsFamily || x.IsPublic) ? '-' + x.Name + '\n' : null);
                }
                Console.WriteLine(answer);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message + ex.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
