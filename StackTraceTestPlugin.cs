using Microsoft.Xrm.Sdk;
using PluginStackTraceTest.Logic;
using System;
using System.Diagnostics;

namespace PluginStackTraceTest
{
	/// <summary>
	/// Plugin development guide: https://docs.microsoft.com/powerapps/developer/common-data-service/plug-ins
	/// Best practices and guidance: https://docs.microsoft.com/powerapps/developer/common-data-service/best-practices/business-logic/
	/// </summary>
	public class StackTraceTestPlugin : PluginBase
	{
		public StackTraceTestPlugin(string unsecureConfiguration, string secureConfiguration)
			: base(typeof(StackTraceTestPlugin))
		{
			// TODO: Implement your custom configuration handling
			// https://docs.microsoft.com/powerapps/developer/common-data-service/register-plug-in#set-configuration-data
		}

		// Entry point for custom business logic execution
		protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
		{
			if (localPluginContext == null)
			{
				throw new ArgumentNullException(nameof(localPluginContext));
			}

			var context = localPluginContext.PluginExecutionContext;

			var logic = new StackTraceTestLogic();

			localPluginContext.Trace($"Test 8");

			try
			{
				logic.ThrowException();
			}
			catch (Exception ex)
			{
				var stackTrace = new StackTrace(ex, true);
				var linenumber = stackTrace.GetFrame(0).GetFileLineNumber();
				var file = stackTrace.GetFrame(0).GetFileName();
				var method = stackTrace.GetFrame(0).GetMethod();
				localPluginContext.Trace($@"
					{nameof(linenumber)}: {linenumber}, 
					{nameof(file)}: {file}, 
					{nameof(stackTrace)}: {stackTrace}");
			}

			// TODO: Implement your custom business logic

			// Check for the entity on which the plugin would be registered
			//if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
			//{
			//    var entity = (Entity)context.InputParameters["Target"];

			//    // Check for entity name on which this plugin would be registered
			//    if (entity.LogicalName == "account")
			//    {

			//    }
			//}
		}
	}
}
