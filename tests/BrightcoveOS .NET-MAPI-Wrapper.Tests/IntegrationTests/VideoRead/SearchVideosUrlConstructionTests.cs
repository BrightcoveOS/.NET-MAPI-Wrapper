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
    /// Read token taken from Brightcoves media API sample @ http://docs.brightcove.com/en/media/samples/search_videos.html.
    /// </summary>
    [TestFixture("ZY4Ls9Hq6LCBgleGDTaFRDLWWBC8uoXQun0xEEXtlDUHBDPZBCOzbw..")]
    public class SearchVideosUrlConstructionTests
    {
        public BrightcoveApi _api;
        public string _apiKey;

        private List<FieldValuePair> _allFieldValues;
        public List<FieldValuePair> AllFieldValues
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
        public List<FieldValuePair> AnyFieldValues
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
        public List<FieldValuePair> NoneFieldValues
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

        public SearchVideosUrlConstructionTests(string apiKey)
        {
            _apiKey = apiKey;
        }

        [SetUp]
        public void Create_Brightcove_Api()
        {
            // Instantiate an API object by using the provided factory
            _api = BrightcoveApiFactory.CreateApi(_apiKey);
        }
        
        /// <summary>
        /// Tests if you can connect to Brightcove at all.
        /// </summary>
        [Test]
        public void SearchVideos_Connection_Test()
        {
            Exception ex = null;

            try
            {
                // Perform the API call   
                BrightcoveItemCollection<BrightcoveVideo> videos = _api.SearchVideos(new List<FieldValuePair>(),
                                                                                    new List<FieldValuePair>(),
                                                                                    new List<FieldValuePair>());
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreEqual(null, ex);
        }

        /// <summary>
        /// Tests if a listing of blank parameters produces the correct url.
        /// </summary>
        [Test]
        public void SearchVideos_No_All_Any_None_Parameters_Url()
        {
            try
            {
                BrightcoveItemCollection<BrightcoveVideo> videos = _api.SearchVideos(new List<FieldValuePair>(),
                                                                                    new List<FieldValuePair>(),
                                                                                    new List<FieldValuePair>());
            }
            catch (Exception ex)
            {
                if (!(ex is BrightcoveApiException))
                {
                    Assert.Fail();
                }
            }

            String url = ((BrightcoveApiConnector)_api.Connector).RequestUrl;
            String expectedUrl = String.Format("http://api.brightcove.com/services/library?command=search_videos&token={0}&sort_by=CREATION_DATE%3aASC&exact=false&page_size=100&page_number=0&get_item_count=true", HttpUtility.UrlEncode(_apiKey));

            Assert.AreEqual(expectedUrl, url);
        }

        /// <summary>
        /// Tests if a listing of non-blank all/any/none parameters products a correct url.
        /// </summary>
        [Test]
        public void SearchVideos_All_Any_None_Parameters_Url()
        {
            try
            {
                BrightcoveItemCollection<BrightcoveVideo> videos = _api.SearchVideos(AllFieldValues,
                                                                                     AnyFieldValues,
                                                                                     NoneFieldValues);
            }
            catch (Exception ex)
            {
                if (!(ex is BrightcoveApiException))
                {
                    Assert.Fail();
                }
            }

            String url = ((BrightcoveApiConnector)_api.Connector).RequestUrl;
            StringBuilder builder = new StringBuilder("http://api.brightcove.com/services/library?command=search_videos&token={0}");
            builder.Append("&all=display_name%3amartian&all=tag%3aalien");
            builder.Append("&any=search_text%3aforeigner&any=custom_fields%3axenophobe");
            builder.Append("&none=american&none=reference_id%3a1234");
            builder.Append("&sort_by=CREATION_DATE%3aASC");
            builder.Append("&exact=false&page_size=100&page_number=0&get_item_count=true");
            String expectedUrl = String.Format(builder.ToString(), HttpUtility.UrlEncode(_apiKey));

            Assert.AreEqual(expectedUrl, url);
        }

        /// <summary>
        /// Tests if non blank parameters with one sort field products the correct url.
        /// </summary>
        [Test]
        public void SearchVideos_With_Parameters_With_One_Sort()
        {
            try
            {
                BrightcoveItemCollection<BrightcoveVideo> videos = _api.SearchVideos(AllFieldValues,
                                                                                     AnyFieldValues,
                                                                                     NoneFieldValues,
                                                                                     100,
                                                                                     0,
                                                                                     false,
                                                                                     new Dictionary<SortBy, SortOrder>
                                                                                         {
                                                                                             { SortBy.ModifiedDate, SortOrder.Ascending }
                                                                                         });
            }
            catch (Exception ex)
            {
                if (!(ex is BrightcoveApiException))
                {
                    Assert.Fail();
                }
            }

            String url = ((BrightcoveApiConnector)_api.Connector).RequestUrl;
            StringBuilder builder = new StringBuilder("http://api.brightcove.com/services/library?command=search_videos&token={0}");
            builder.Append("&all=display_name%3amartian&all=tag%3aalien");
            builder.Append("&any=search_text%3aforeigner&any=custom_fields%3axenophobe");
            builder.Append("&none=american&none=reference_id%3a1234");
            builder.Append("&sort_by=MODIFIED_DATE%3aASC");
            builder.Append("&exact=false&page_size=100&page_number=0&get_item_count=true");
            String expectedUrl = String.Format(builder.ToString(), HttpUtility.UrlEncode(_apiKey));

            Assert.AreEqual(expectedUrl, url);
        }

        /// <summary>
        /// Tests if non blank parameters with multiple sort fields products the correct url.
        /// </summary>
        [Test]
        public void SearchVideos_With_Parameters_With_Multiple_Sorts()
        {
            try
            {
                BrightcoveItemCollection<BrightcoveVideo> videos = _api.SearchVideos(AllFieldValues,
                                                                                     AnyFieldValues,
                                                                                     NoneFieldValues,
                                                                                     100,
                                                                                     0,
                                                                                     false,
                                                                                     new Dictionary<SortBy, SortOrder>
                                                                                         {
                                                                                             { SortBy.ModifiedDate, SortOrder.Ascending },
                                                                                             { SortBy.DisplayName, SortOrder.Descending },
                                                                                             { SortBy.PlaysTotal, SortOrder.Descending },
                                                                                         });
            }
            catch (Exception ex)
            {
                if (!(ex is BrightcoveApiException))
                {
                    Assert.Fail();
                }
            }

            String url = ((BrightcoveApiConnector)_api.Connector).RequestUrl;
            StringBuilder builder = new StringBuilder("http://api.brightcove.com/services/library?command=search_videos&token={0}");
            builder.Append("&all=display_name%3amartian&all=tag%3aalien");
            builder.Append("&any=search_text%3aforeigner&any=custom_fields%3axenophobe");
            builder.Append("&none=american&none=reference_id%3a1234");
            builder.Append("&sort_by=MODIFIED_DATE%3aASC%2cDISPLAY_NAME%3aDESC%2cPLAYS_TOTAL%3aDESC");
            builder.Append("&exact=false&page_size=100&page_number=0&get_item_count=true");
            String expectedUrl = String.Format(builder.ToString(), HttpUtility.UrlEncode(_apiKey));

            Assert.AreEqual(expectedUrl, url);
        }
    }
}
