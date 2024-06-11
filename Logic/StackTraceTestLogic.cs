using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginStackTraceTest.Logic
{
	internal class StackTraceTestLogic
	{
		public void ThrowException()
		{
			throw new InvalidPluginExecutionException("Throwing an exception here");
		}
	}
}
