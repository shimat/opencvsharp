#nullable enable

#if DOTNET_FRAMEWORK
using System;
using System.Globalization;
using System.Security.Policy;
using Xunit;

namespace OpenCvSharp.Tests
{
    public class MarshalByRefAction : MarshalByRefObject
    {
        public Action? Action { get; set; }
        public void Run()
        {
            Action?.Invoke();
        }
    }

    [Collection(nameof(AppDomainTest))] // should not be run test in parallel 
    [Serializable]
    public class AppDomainTest : TestBase
    {
        // https://github.com/shimat/opencvsharp/issues/389
        // http://urasandesu.blogspot.com/2012/02/appdomain-how-to-use-unmanaged-code-as.html
       
        [ExplicitFact]
        public void Test()
        {
            using (var mat1 = new Mat(@"_data\image\lenna.png"))
            {
                Assert.Throws<OpenCVException>(() =>
                {
                    Cv2.MedianBlur(mat1, mat1, 2 /*even*/);
                });
            }

            for (int i = 0; i < 100; i++)
            {
                RunAtIsolatedDomain(AppDomain.CurrentDomain, () =>
                {
                    // ITestOutputHelper cannot be serialized
                    // ReSharper disable once Xunit.XunitTestWithConsoleOutput
                    Console.WriteLine(Cv2.GetTickCount().ToString(CultureInfo.InvariantCulture));
                    using var mat2 = new Mat(@"_data\image\lenna.png");
                    try
                    {
                        Cv2.MedianBlur(mat2, mat2, 2 /*even*/);
                    }
                    catch (OpenCVException ex)
                    {
                        // OK
                        GC.KeepAlive(ex);
                    }
                });
            }

            // avoid AppDomainUnloadedException on subsequent tests https://codeday.me/jp/qa/20190609/973822.html
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private static void RunAtIsolatedDomain(Evidence securityInfo, AppDomainSetup info, Action action)
        {
            //if (!action.Method.IsStatic)
            //    throw new ArgumentException("", nameof(action));

            AppDomain? domain = null;
            try
            {
                domain = AppDomain.CreateDomain("MyDomain " + action.Method, securityInfo, info);
                var type = typeof(MarshalByRefAction);
                Assert.NotNull(type.FullName);
                var runner = (MarshalByRefAction)domain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
                runner.Action = action;
                runner.Run();
            }
            finally
            {
                if (domain != null)
                    AppDomain.Unload(domain);
            }
        }

        private static void RunAtIsolatedDomain(AppDomain source, Action action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            RunAtIsolatedDomain(source.Evidence, source.SetupInformation, action);
        }
    }
}

#endif