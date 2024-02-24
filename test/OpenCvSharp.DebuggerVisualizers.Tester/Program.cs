using System;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers.Tester
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var img = @"_data\image\calibration\00.jpg";
			var mainForm = new ImageViewer(img);
			Application.Run(mainForm);
		}
	}
}
