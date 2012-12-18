using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	/// <summary>
	/// Base class for intializing video write tests
	/// </summary>
	public abstract class VideoWriteTestBase
	{
		protected BrightcoveApi _api;
		
		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.ReadToken, ApiKeys.WriteToken);	
		}
	}
}
