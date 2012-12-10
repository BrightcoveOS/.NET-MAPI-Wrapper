using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
    [TestFixture("ZY4Ls9Hq6LCBgleGDTaFRDLWWBC8uoXQun0xEEXtlDUHBDPZBCOzbw..")]
    public class SearchVideosTests
    {
        public BrightcoveApi Api;
        public string ApiKey;

        public SearchVideosTests(string apiKey)
        {
            ApiKey = apiKey;
        }

        public SearchVideosTests() : this(null)
        {
        }

        private List<BrightcoveVideo> _allVideos;
        public List<BrightcoveVideo> AllVideos
        {
            get
            {
                if (_allVideos == null)
                {
                    _allVideos = new List<BrightcoveVideo>();
                }
                return _allVideos;
            }
            set
            {
                _allVideos = value;
            }
        }

        [SetUp]
        public void FindAllVideos()
        {
            Api = BrightcoveApiFactory.CreateApi(ApiKey);
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>(),
                                                                                new List<FieldValuePair>(),
                                                                                new List<FieldValuePair>());

            int k = 0;

            while (k <= Math.Floor((decimal)videos.TotalCount / (decimal)videos.PageSize))
            {
                if (k != 0)
                {
                    videos = Api.SearchVideos(new List<FieldValuePair>(),
                                               new List<FieldValuePair>(),
                                               new List<FieldValuePair>(),
                                               videos.PageSize,
                                               k);
                }

                AllVideos.AddRange(videos.Select(x => x));

                k++;
            }
        }

        [TearDown]
        public void ClearVideos()
        {
            if (AllVideos != null)
            {
                AllVideos.Clear();
            }
        }

        [Test]
        public void Sort_Videos_By_Creation_Date_No_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>(),
                                                                                 new List<FieldValuePair>(),
                                                                                 new List<FieldValuePair>());

            BrightcoveVideo firstVideo = videos.First();
            BrightcoveVideo expectedFirstVideo = AllVideos.OrderBy(x => x.CreationDate)
                .First();
            BrightcoveVideo lastVideoOnPage = videos.Last();
            BrightcoveVideo expectedLastVideoInRange = AllVideos.OrderBy(x => x.CreationDate)
                .Skip(videos.PageSize - 1)
                .First();

            Assert.AreEqual(expectedFirstVideo.Id, firstVideo.Id);
            Assert.AreEqual(expectedLastVideoInRange.Id, lastVideoOnPage.Id);
        }

        [Test]
        public void Sort_Videos_By_Creation_Date_Desc_No_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>(),
                                                                                 new List<FieldValuePair>(),
                                                                                 new List<FieldValuePair>(),
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.CreationDate, SortOrder.Descending}
                                                                                     });

            BrightcoveVideo firstVideo = videos.First();
            BrightcoveVideo expectedFirstVideo = AllVideos.OrderByDescending(x => x.CreationDate)
                .First();
            BrightcoveVideo lastVideoOnPage = videos.Last();
            BrightcoveVideo expectedLastVideoInRange = AllVideos.OrderByDescending(x => x.CreationDate)
                .Skip(videos.PageSize - 1)
                .First();

            Assert.AreEqual(videos.TotalCount, AllVideos.Count);
            Assert.AreEqual(expectedFirstVideo.Id, firstVideo.Id);
        }

        [Test]
        public void Sort_Videos_By_Creation_Date_Desc_With_All_Any_None_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "sea")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "lion"),
                                                                                         new FieldValuePair(null, "clown"),
                                                                                         new FieldValuePair(null, "crab"),
                                                                                         new FieldValuePair(null, "turtle"),
                                                                                         new FieldValuePair(null, "seagulls")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "fish")
                                                                                     },
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.CreationDate, SortOrder.Descending}
                                                                                     });


            // Assume data is searched correctly based on the parameters, but check to see if the dates are in fact sorted correctly.
            List<BrightcoveVideo> expectedVideos = AllVideos
                .Where(x => videos.Select(y => y.Id).Contains(x.Id))
                .OrderByDescending(x => x.CreationDate)
                .ToList();

            bool hasCorrectIndexes = expectedVideos
                .Select((x, i) => new
                                      {
                                          Id = x.Id,
                                          Index = i
                                      })
                .All(x => x.Index == videos.IndexOf(videos.Single(y => y.Id == x.Id)));

            Assert.AreEqual(expectedVideos.Count, videos.Count);
            Assert.IsTrue(hasCorrectIndexes);
        }

        [Test]
        public void Sort_Videos_By_DisplayName_Desc_Creation_Date_Desc_With_All_Any_None_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "sea")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "lion"),
                                                                                         new FieldValuePair(null, "clown"),
                                                                                         new FieldValuePair(null, "crab"),
                                                                                         new FieldValuePair(null, "turtle"),
                                                                                         new FieldValuePair(null, "seagulls")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "fish")
                                                                                     },
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.DisplayName, SortOrder.Descending},
                                                                                         {SortBy.CreationDate, SortOrder.Descending}
                                                                                     });

            List<BrightcoveVideo> expectedVideos = AllVideos
                .Where(x => videos.Select(y => y.Id).Contains(x.Id))
                .OrderByDescending(x => x.Name.Replace("-", "").Replace("_", "")) // Brightcove search doesn't seem to take dashes and underscores into consideration when ordering; perhaps all special characters?
                .ThenByDescending(x => x.CreationDate)
                .ToList();

            bool hasCorrectIndexes = expectedVideos
                .Select((x, i) => new
                {
                    Id = x.Id,
                    Index = i
                })
                .All(x => x.Index == videos.IndexOf(videos.Single(y => y.Id == x.Id)));

            Assert.AreEqual(expectedVideos.Count, videos.Count);
            Assert.IsTrue(hasCorrectIndexes);
        }

        [Test]
        public void Sort_Videos_By_DisplayName_Asc_Creation_Date_Desc_With_All_Any_None_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "sea")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "lion"),
                                                                                         new FieldValuePair(null, "clown"),
                                                                                         new FieldValuePair(null, "crab"),
                                                                                         new FieldValuePair(null, "turtle"),
                                                                                         new FieldValuePair(null, "seagulls")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "fish")
                                                                                     },
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.DisplayName, SortOrder.Ascending},
                                                                                         {SortBy.CreationDate, SortOrder.Descending}
                                                                                     });

            List<BrightcoveVideo> expectedVideos = AllVideos
                .Where(x => videos.Select(y => y.Id).Contains(x.Id))
                .OrderBy(x => x.Name.Replace("-", "").Replace("_", "")) // Brightcove search doesn't seem to take dashes and underscores into consideration when ordering; perhaps all special characters?
                .ThenByDescending(x => x.CreationDate)
                .ToList();

            bool hasCorrectIndexes = expectedVideos
                .Select((x, i) => new
                {
                    Id = x.Id,
                    Index = i
                })
                .All(x => x.Index == videos.IndexOf(videos.Single(y => y.Id == x.Id)));

            Assert.AreEqual(expectedVideos.Count, videos.Count);
            Assert.IsTrue(hasCorrectIndexes);
        }

        [Test]
        public void Sort_Videos_By_DisplayName_Asc_Creation_Date_Asc_With_All_Any_None_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "sea")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "lion"),
                                                                                         new FieldValuePair(null, "clown"),
                                                                                         new FieldValuePair(null, "crab"),
                                                                                         new FieldValuePair(null, "turtle"),
                                                                                         new FieldValuePair(null, "seagulls")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "fish")
                                                                                     },
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.DisplayName, SortOrder.Ascending},
                                                                                         {SortBy.CreationDate, SortOrder.Ascending}
                                                                                     });

            List<BrightcoveVideo> expectedVideos = AllVideos
                .Where(x => videos.Select(y => y.Id).Contains(x.Id))
                .OrderBy(x => x.Name.Replace("-", "").Replace("_", "")) // Brightcove search doesn't seem to take dashes and underscores into consideration when ordering; perhaps all special characters?
                .ThenBy(x => x.CreationDate)
                .ToList();

            bool hasCorrectIndexes = expectedVideos
                .Select((x, i) => new
                {
                    Id = x.Id,
                    Index = i
                })
                .All(x => x.Index == videos.IndexOf(videos.Single(y => y.Id == x.Id)));

            Assert.AreEqual(expectedVideos.Count, videos.Count);
            Assert.IsTrue(hasCorrectIndexes);
        }

        [Test]
        public void Sort_Videos_By_DisplayName_Desc_Creation_Date_Asc_With_All_Any_None_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "sea")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "lion"),
                                                                                         new FieldValuePair(null, "clown"),
                                                                                         new FieldValuePair(null, "crab"),
                                                                                         new FieldValuePair(null, "turtle"),
                                                                                         new FieldValuePair(null, "seagulls")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "fish")
                                                                                     },
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.DisplayName, SortOrder.Descending},
                                                                                         {SortBy.CreationDate, SortOrder.Ascending}
                                                                                     });

            List<BrightcoveVideo> expectedVideos = AllVideos
                .Where(x => videos.Select(y => y.Id).Contains(x.Id))
                .OrderByDescending(x => x.Name.Replace("-", "").Replace("_", "")) // Brightcove search doesn't seem to take dashes and underscores into consideration when ordering; perhaps all special characters?
                .ThenBy(x => x.CreationDate)
                .ToList();

            bool hasCorrectIndexes = expectedVideos
                .Select((x, i) => new
                {
                    Id = x.Id,
                    Index = i
                })
                .All(x => x.Index == videos.IndexOf(videos.Single(y => y.Id == x.Id)));

            Assert.AreEqual(expectedVideos.Count, videos.Count);
            Assert.IsTrue(hasCorrectIndexes);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Sort_Videos_By_None_Desc_Creation_Date_Asc_With_All_Any_None_Parameters()
        {
            // Perform the API call   
            BrightcoveItemCollection<BrightcoveVideo> videos = Api.SearchVideos(new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "sea")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "lion"),
                                                                                         new FieldValuePair(null, "clown"),
                                                                                         new FieldValuePair(null, "crab"),
                                                                                         new FieldValuePair(null, "turtle"),
                                                                                         new FieldValuePair(null, "seagulls")
                                                                                     },
                                                                                 new List<FieldValuePair>
                                                                                     {
                                                                                         new FieldValuePair(null, "fish")
                                                                                     },
                                                                                 100,
                                                                                 0,
                                                                                 false,
                                                                                 new Dictionary<SortBy, SortOrder>
                                                                                     {
                                                                                         {SortBy.None, SortOrder.Descending},
                                                                                         {SortBy.CreationDate, SortOrder.Ascending}
                                                                                     });

            List<BrightcoveVideo> expectedVideos = AllVideos
                .Where(x => videos.Select(y => y.Id).Contains(x.Id))
                .OrderBy(x => x.CreationDate)
                .ToList();

            bool hasCorrectIndexes = expectedVideos
                .Select((x, i) => new
                {
                    Id = x.Id,
                    Index = i
                })
                .All(x => x.Index == videos.IndexOf(videos.Single(y => y.Id == x.Id)));

            Assert.AreEqual(expectedVideos.Count, videos.Count);
            Assert.IsTrue(hasCorrectIndexes);
        }
    }
}
