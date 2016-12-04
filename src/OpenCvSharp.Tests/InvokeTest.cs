using System;
using System.Reflection;
using NUnit.Framework;

namespace OpenCvSharp.Tests
{
    [TestFixture]
    public class InvokeTest
    {
        [Test]
        public void ExistsAllEntryPoints()
        {
            var type = typeof (NativeMethods);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                var parameters = method.GetParameters();
                var values = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    var paramType = parameters[i].ParameterType;
                    if (paramType == typeof (string))
                        values[i] = "";
                    else
                        values[i] = Activator.CreateInstance(parameters[i].ParameterType);
                }

                /*
                var task = Task.Factory.StartNew(
                    () =>
                    {
                        try
                        {
                            Console.WriteLine(method.Name);
                            method.Invoke(null, values);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Caught one (inside):" + e.GetType().Name);
                        }
                    });
                try
                {
                    task.Wait(1000);
                }
                catch (AggregateException ae)
                {
                    // Assume we know what's going on with this particular exception. 
                    // Rethrow anything else. AggregateException.Handle provides 
                    // another way to express this. See later example. 
                    foreach (var e in ae.InnerExceptions)
                    {
                        if (e is TargetInvocationException)
                        {
                            Console.WriteLine("After:" + e.GetType().Name + e.StackTrace);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                */

                ///* TODO
                try
                {
                    method.Invoke(null, values);
                }
                catch (AccessViolationException ex)
                {
                    ex.ToString();
                }
                catch (TargetInvocationException ex)
                {
                    ex.ToString();
                }
                catch (MissingMethodException ex)
                {
                    Assert.Fail(ex.ToString());
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                //*/
            }

        }
    }
}

