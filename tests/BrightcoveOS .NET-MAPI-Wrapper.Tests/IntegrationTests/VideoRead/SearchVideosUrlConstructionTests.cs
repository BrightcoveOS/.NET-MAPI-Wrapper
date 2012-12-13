using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Api.Connectors;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	/// <summary>
	/// Integration tests of video search url construction.
	/// </summary>
	[TestFixture(ApiKeys.VideoReadKey)]
	public class SearchVideosUrlConstructionTests
	{
		public BrightcoveApi Api { get; set; }
		public string ApiKey { get; set; }

		private List<FieldValuePair> _allFieldValues;
		private IEnumerable<FieldValuePair> AllFieldValues
		{
			get
			{
				if (_allFieldValues == null)
				{
					_allFieldValues = new List<FieldValuePair>
										  {
											  new FieldValuePair("display_name", "martian"),
											  new FieldValuePair("tag", "alien")
										  };
				}
				return _allFieldValues;
			}
		}

		private List<FieldValuePair> _anyFieldValues;
		private IEnumerable<FieldValuePair> AnyFieldValues
		{
			get
			{
				if (_anyFieldValues == null)
				{
					_anyFieldValues = new List<FieldValuePair>
										  {
											  new FieldValuePair("search_text", "foreigner"),
											  new FieldValuePair("custom_fields", "xenophobe")
										  };
				}
				return _anyFieldValues;
			}
		}

		private List<FieldValuePair> _noneFieldValues;
		private IEnumerable<FieldValuePair> NoneFieldValues
		{
			get
			{
				if (_noneFieldValues == null)
				{
					_noneFieldValues = new List<FieldValuePair>
										  {
											  new FieldValuePair(null, "american"),
											  new FieldValuePair("reference_id", "1234")
										  };
				}
				return _noneFieldValues;
			}
		}

		public delegate void CreateApiCall();

		public SearchVideosUrlConstructionTests(string apiKey)
		{
			ApiKey = apiKey;
		}

		public SearchVideosUrlConstructionTests() : this(null)
		{
		}

		[SetUp]
		public void Create_Brightcove_Api()
		{
			// Instantiate an API object by using the provided factory
			Api = BrightcoveApiFactory.CreateApi(ApiKey);
		}

		/// <summary>
		/// Tests if you can connect to Brightcove at all.
		/// </summary>
		[Test]
		public void SearchVideos_Connection_Test()
		{
			// Perform the API call   
			Api.SearchVideos(new List<FieldValuePair>(),
			                 new List<FieldValuePair>(),
			                 new List<FieldValuePair>());
		}

		/// <summary>
		/// Tests if a listing of blank parameters produces the correct url.
		/// </summary>
		[Test]
		public void SearchVideos_No_All_Any_None_Parameters_Url()
		{
			Api.SearchVideos(new List<FieldValuePair>(),
			                 new List<FieldValuePair>(),
			                 new List<FieldValuePair>());

			String url = ((BrightcoveApiConnector)Api.Connector).RequestUrl;
			String expectedUrl = String.Format("http://api.brightcove.com/services/library?command=search_videos&token={0}&sort_by=CREATION_DATE%3aASC&exact=false&page_size=100&page_number=0&get_item_count=true", HttpUtility.UrlEncode(ApiKey));

			Assert.AreEqual(expectedUrl, url);
		}

		/// <summary>
		/// Tests if a listing of non-blank all/any/none parameters products a correct url.
		/// </summary>
		[Test]
		public void SearchVideos_All_Any_None_Parameters_Url()
		{
			Api.SearchVideos(AllFieldValues,
			                 AnyFieldValues,
			                 NoneFieldValues);

			String url = ((BrightcoveApiConnector)Api.Connector).RequestUrl;
			StringBuilder builder = new StringBuilder("http://api.brightcove.com/services/library?command=search_videos&token={0}")
				.Append("&all=display_name%3amartian&all=tag%3aalien")
				.Append("&any=search_text%3aforeigner&any=custom_fields%3axenophobe")
				.Append("&none=american&none=reference_id%3a1234")
				.Append("&sort_by=CREATION_DATE%3aASC")
				.Append("&exact=false&page_size=100&page_number=0&get_item_count=true");
			String expectedUrl = String.Format(builder.ToString(), HttpUtility.UrlEncode(ApiKey));

			Assert.AreEqual(expectedUrl, url);
		}

		/// <summary>
		/// Tests if non blank parameters with one sort field products the correct url.
		/// </summary>
		[Test]
		public void SearchVideos_With_Parameters_With_One_Sort()
		{
			Api.SearchVideos(AllFieldValues,
			                 AnyFieldValues,
			                 NoneFieldValues,
			                 100,
			                 0,
			                 false,
			                 new SortedFieldDictionary(SortBy.ModifiedDate, SortOrder.Ascending));

			String url = ((BrightcoveApiConnector)Api.Connector).RequestUrl;
			StringBuilder builder = new StringBuilder("http://api.brightcove.com/services/library?command=search_videos&token={0}")
				.Append("&all=display_name%3amartian&all=tag%3aalien")
				.Append("&any=search_text%3aforeigner&any=custom_fields%3axenophobe")
				.Append("&none=american&none=reference_id%3a1234")
				.Append("&sort_by=MODIFIED_DATE%3aASC")
				.Append("&exact=false&page_size=100&page_number=0&get_item_count=true");
			String expectedUrl = String.Format(builder.ToString(), HttpUtility.UrlEncode(ApiKey));

			Assert.AreEqual(expectedUrl, url);
		}

		/// <summary>
		/// Tests if non blank parameters with multiple sort fields products the correct url.
		/// </summary>
		[Test]
		public void SearchVideos_With_Parameters_With_Multiple_Sorts()
		{

			Api.SearchVideos(AllFieldValues,
			                 AnyFieldValues,
			                 NoneFieldValues,
			                 100,
			                 0,
			                 false,
			                 new SortedFieldDictionary(SortBy.ModifiedDate, SortOrder.Ascending, SortBy.DisplayName, SortOrder.Descending, SortBy.PlaysTotal, SortOrder.Descending));

			String url = ((BrightcoveApiConnector)Api.Connector).RequestUrl;
			StringBuilder builder = new StringBuilder("http://api.brightcove.com/services/library?command=search_videos&token={0}")
				.Append("&all=display_name%3amartian&all=tag%3aalien")
				.Append("&any=search_text%3aforeigner&any=custom_fields%3axenophobe")
				.Append("&none=american&none=reference_id%3a1234")
				.Append("&sort_by=MODIFIED_DATE%3aASC%2cDISPLAY_NAME%3aDESC%2cPLAYS_TOTAL%3aDESC")
				.Append("&exact=false&page_size=100&page_number=0&get_item_count=true");
			String expectedUrl = String.Format(builder.ToString(), HttpUtility.UrlEncode(ApiKey));

			Assert.AreEqual(expectedUrl, url);
		}

		[Test]
		public void Use_Japanese_Url()
		{
			// Override the default API.
			Api = BrightcoveApiFactory.CreateApi(ApiKey, BrightcoveRegion.Japan);

			// The token doesn't work with the Japanese version of the API, and so it should throw an Invalid Token error; nonetheless, we want to check to see if the URL was properly constructed.
			try
			{
				var videos = Api.SearchVideos(new List<FieldValuePair>(),
											  new List<FieldValuePair>(),
											  new List<FieldValuePair>());
			}
			catch (BrightcoveApiException ex)
			{
				// Check to see whether the code references the Brightcove invalid token code (as of December 2012).
				if (ex.Error.Code != 210)
				{
					throw;
				}
			}

			String url = ((BrightcoveApiConnector)Api.Connector).RequestUrl;
			String expectedUrl = String.Format("http://api.brightcove.co.jp/services/library?command=search_videos&token={0}&sort_by=CREATION_DATE%3aASC&exact=false&page_size=100&page_number=0&get_item_count=true", HttpUtility.UrlEncode(ApiKey));

			Assert.AreEqual(expectedUrl, url);
		}
	}
}
