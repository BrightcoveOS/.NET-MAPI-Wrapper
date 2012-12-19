using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Util;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveMapiWrapper.Api
{
	public partial class BrightcoveApi
	{
		#region FindVideoById

		/// <summary>
		/// Finds a single video with the specified id.
		/// </summary>
		/// <param name="videoId">The id of the video you would like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Videos: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If 
		/// you use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>The Video you requested, with the specified fields populated, or null, if there is no video with that id.</returns>
		public BrightcoveVideo FindVideoById(long videoId, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_video_by_id");
			parms.Add("video_id", videoId.ToString());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveVideo>(parms);
		}

		/// <summary>
		/// Finds a single video with the specified id.
		/// </summary>
		/// <param name="videoId">The id of the video you would like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Videos: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If 
		/// you use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>The Video you requested, with the specified fields populated, or null, if there is no video with that id.</returns>
		public BrightcoveVideo FindVideoById(long videoId, IEnumerable<string> videoFields)
		{
			return FindVideoById(videoId, videoFields, null);
		}

		/// <summary>
		/// Finds a single video with the specified id.
		/// </summary>
		/// <param name="videoId">The id of the video you would like to retrieve.</param>
		/// <returns>The Video you requested, with the specified fields populated, or null, if there is no video with that id.</returns>
		public BrightcoveVideo FindVideoById(long videoId)
		{
			return FindVideoById(videoId, null);
		}

		#endregion

		#region FindVideosByIds

		/// <summary>
		/// Find multiple videos, given their ids.
		/// </summary>
		/// <param name="videoIds">The list of video ids for the videos to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the 
		/// videos contained in the returned object. If you omit this parameter, no custom fields are returned, unless 
		/// you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection that contains the video objects corresponding to the video ids given. Note that if 
		/// you pass in ids that belong to videos that are either not active or not playable because of schedule 
		/// constraints, then the ItemCollection will contain null elements for the ids that are filtered out.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByIds(IEnumerable<long> videoIds, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_videos_by_ids");

			if (videoIds == null)
			{
				throw new ArgumentNullException("videoIds");
			}
			parms.AddRange("video_ids", videoIds.Select(o => o.ToString()));

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Find multiple videos, given their ids.
		/// </summary>
		/// <param name="videoIds">The list of video ids for the videos to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>A collection that contains the video objects corresponding to the video ids given. Note that if 
		/// you pass in ids that belong to videos that are either not active or not playable because of schedule 
		/// constraints, then the ItemCollection will contain null elements for the ids that are filtered out.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByIds(IEnumerable<long> videoIds, IEnumerable<string> videoFields)
		{
			return FindVideosByIds(videoIds, videoFields, null);
		}

		/// <summary>
		/// Find multiple videos, given their ids.
		/// </summary>
		/// <param name="videoIds">The list of video ids for the videos to retrieve.</param>
		/// <returns>A collection that contains the video objects corresponding to the video ids given. Note that if 
		/// you pass in ids that belong to videos that are either not active or not playable because of schedule 
		/// constraints, then the ItemCollection will contain null elements for the ids that are filtered out.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByIds(IEnumerable<long> videoIds)
		{
			return FindVideosByIds(videoIds, null);
		}

		#endregion

		#region FindVideoByReferenceId

		/// <summary>
		/// Find a video based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The publisher-assigned reference id for the video we're searching for.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained in the returned object. 
		/// If you omit this parameter, the method returns the following fields of the Video: id, name, shortDescription, 
		/// longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL,
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL access, this method also returns 
		/// FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos contained in the returned 
		/// object. If you omit this parameter, no custom fields are returned, unless you include the value 'customFields' in the 
		/// video_fields parameter.</param>
		/// <returns>The video whose reference id matches the one given.</returns>
		public BrightcoveVideo FindVideoByReferenceId(string referenceId, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_video_by_reference_id");
			parms.Add("reference_id", referenceId);

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveVideo>(parms);
		}

		/// <summary>
		/// Find a video based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The publisher-assigned reference id for the video we're searching for.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained in the returned object. 
		/// If you omit this parameter, the method returns the following fields of the Video: id, name, shortDescription, 
		/// longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL,
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL access, this method also returns 
		/// FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>The video whose reference id matches the one given.</returns>
		public BrightcoveVideo FindVideoByReferenceId(string referenceId, IEnumerable<string> videoFields)
		{
			return FindVideoByReferenceId(referenceId, videoFields, null);
		}

		/// <summary>
		/// Find a video based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The publisher-assigned reference id for the video we're searching for.</param>
		/// <returns>The video whose reference id matches the one given.</returns>
		public BrightcoveVideo FindVideoByReferenceId(string referenceId)
		{
			return FindVideoByReferenceId(referenceId, null);
		}


		#endregion

		#region FindVideosByReferenceIds

		/// <summary>
		/// Find multiple videos based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The list of reference ids for the videos to retrieve</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the 
		/// videos contained in the returned object. If you omit this parameter, no custom fields are returned, unless 
		/// you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos matching the specified reference ids. Note that if you pass in ids 
		/// that belong to videos that are either not active or not playable because of schedule constraints, then 
		/// the collection will contain null elements for the ids that are filtered out.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByReferenceIds(IEnumerable<string> referenceIds, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_videos_by_reference_ids");

			if (referenceIds == null)
			{
				throw new ArgumentNullException("referenceIds");
			}
			parms.AddRange("reference_ids", referenceIds);

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Find multiple videos based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The list of reference ids for the videos to retrieve</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos matching the specified reference ids. Note that if you pass in ids 
		/// that belong to videos that are either not active or not playable because of schedule constraints, then 
		/// the collection will contain null elements for the ids that are filtered out.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByReferenceIds(IEnumerable<string> referenceIds, IEnumerable<string> videoFields)
		{
			return FindVideosByReferenceIds(referenceIds, videoFields, null);
		}

		/// <summary>
		/// Find multiple videos based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The list of reference ids for the videos to retrieve</param>
		/// <returns>A collection of videos matching the specified reference ids. Note that if you pass in ids 
		/// that belong to videos that are either not active or not playable because of schedule constraints, then 
		/// the collection will contain null elements for the ids that are filtered out.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByReferenceIds(IEnumerable<string> referenceIds)
		{
			return FindVideosByReferenceIds(referenceIds, null);
		}

		#endregion

		#region FindAllVideos

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the 
		/// videos contained in the returned object. If you omit this parameter, no custom fields are returned, unless 
		/// you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
														 IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_all_videos");

			parms.Add("get_item_count", getItemCount.ToString().ToLower());
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the 
		/// videos contained in the returned object. If you omit this parameter, no custom fields are returned, unless 
		/// you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
														 IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindAllVideos(pageSize, pageNumber, sortBy, sortOrder, videoFields, customFields, true);
		}

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the videos contained in the 
		/// returned object. If you omit this parameter, the method returns the following fields of the Video: id, 
		/// name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, linkText, 
		/// tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. If you
		/// use a token with URL access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
																	   IEnumerable<string> videoFields)
		{
			return FindAllVideos(pageSize, pageNumber, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder)
		{
			return FindAllVideos(pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos(int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindAllVideos(pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos(int pageSize, int pageNumber)
		{
			return FindAllVideos(pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Find all videos in the Brightcove media library for this account.
		/// </summary>
		/// <returns>A collection of videos matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindAllVideos()
		{
			return FindAllVideos(100, 0);
		}

		#endregion

		#region SearchVideos

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortFields">Specifies the <see cref="SortedFieldDictionary"/> by which to sort results.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained 
		/// in the returned object. If you omit this parameter, the method returns the following fields of 
		/// the video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, 
		/// linkURL, linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, 
		/// playsTrailingWeek. If you use a token with URL access, this method also returns FLVURL, renditions, 
		/// FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you 
		/// include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortedFieldDictionary sortFields,
																	  IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("search_videos");

			if (all != null)
			{
				parms.AddRange("all", all.Select(o => o.ToBrightcoveString()));
			}

			if (any != null)
			{
				parms.AddRange("any", any.Select(o => o.ToBrightcoveString()));
			}

			if (none != null)
			{
				parms.AddRange("none", none.Select(o => o.ToBrightcoveString()));
			}

			if (sortFields != null)
			{
				string[] orderedFields = sortFields.OrderedDictionary.Cast<DictionaryEntry>()
					.Where(x => x.Key is SortBy)
					.Where(x => x.Value is SortOrder)
					.Select(x => String.Format("{0}:{1}", ( (SortBy)x.Key ).ToBrightcoveName(), ( (SortOrder)x.Value ).ToBrightcoveName()))
					.ToArray();

				parms.Add("sort_by", String.Join(",", orderedFields));
			}

			parms.Add("exact", exact.ToString().ToLower());
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortFields">Specifies the unique list of fields by which to sort results.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained 
		/// in the returned object. If you omit this parameter, the method returns the following fields of 
		/// the video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, 
		/// linkURL, linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, 
		/// playsTrailingWeek. If you use a token with URL access, this method also returns FLVURL, renditions, 
		/// FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you 
		/// include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortedFieldDictionary sortFields,
																	  IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, sortFields, videoFields, customFields, true);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortFields">Specifies the unique list of fields by which to sort results.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained 
		/// in the returned object. If you omit this parameter, the method returns the following fields of 
		/// the video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, 
		/// linkURL, linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, 
		/// playsTrailingWeek. If you use a token with URL access, this method also returns FLVURL, renditions, 
		/// FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortedFieldDictionary sortFields,
																	  IEnumerable<string> videoFields)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, sortFields, videoFields, null);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortFields">Specifies the unique list of fields by which to sort results.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortedFieldDictionary sortFields)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, sortFields, null);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortBy">Specifies the field by which to sort results.</param>
		/// <param name="sortOrder">Specifies the direction in which to sort results.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained 
		/// in the returned object. If you omit this parameter, the method returns the following fields of 
		/// the video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, 
		/// linkURL, linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, 
		/// playsTrailingWeek. If you use a token with URL access, this method also returns FLVURL, renditions, 
		/// FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you 
		/// include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortBy sortBy, SortOrder sortOrder,
																	  IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, new SortedFieldDictionary(sortBy, sortOrder), videoFields,
			                    customFields, getItemCount);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortBy">Specifies the field by which to sort results.</param>
		/// <param name="sortOrder">Specifies the direction in which to sort results.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained 
		/// in the returned object. If you omit this parameter, the method returns the following fields of 
		/// the video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, 
		/// linkURL, linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, 
		/// playsTrailingWeek. If you use a token with URL access, this method also returns FLVURL, renditions, 
		/// FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you 
		/// include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortBy sortBy, SortOrder sortOrder,
																	  IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, sortBy, sortOrder, videoFields, customFields, true);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortBy">Specifies the field by which to sort results.</param>
		/// <param name="sortOrder">Specifies the direction in which to sort results.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos contained 
		/// in the returned object. If you omit this parameter, the method returns the following fields of 
		/// the video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, 
		/// linkURL, linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, 
		/// playsTrailingWeek. If you use a token with URL access, this method also returns FLVURL, renditions, 
		/// FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortBy sortBy, SortOrder sortOrder,
																	  IEnumerable<string> videoFields)
		{
		    return SearchVideos(all, any, none, pageSize, pageNumber, exact, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <param name="sortBy">Specifies the field by which to sort results.</param>
		/// <param name="sortOrder">Specifies the direction in which to sort results.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact, SortBy sortBy, SortOrder sortOrder)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="exact">If true, disables fuzzy search and requires an exact match of search terms. 
		/// A fuzzy search does not require an exact match of the indexed terms, but will return a hit for 
		/// terms that are closely related based on language-specific criteria. The fuzzy search is 
		/// available only if your account is based in the United States.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber, bool exact)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, exact, SortBy.CreationDate, SortOrder.Ascending);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="pageSize">Number of items returned per page. (max 100)</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none,
																	  int pageSize, int pageNumber)
		{
			return SearchVideos(all, any, none, pageSize, pageNumber, false);
		}

		/// <summary>
		/// Searches videos according to the criteria provided by the user.
		/// </summary>
		/// <param name="all">Specifies the field:value pairs for search criteria that MUST be present in 
		/// the index in order to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="any">Specifies the field:value pairs for search criteria AT LEAST ONE of which 
		/// must be present to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <param name="none">Specifies the field:value pairs for search criteria that MUST NOT be present 
		/// to return a hit in the result set. If the field's name is not present, it will 
		/// search among the name, shortDescription, and longDescription fields by default.</param>
		/// <returns>A collection of videos matching the specified criteria.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> SearchVideos(IEnumerable<FieldValuePair> all, IEnumerable<FieldValuePair> any, IEnumerable<FieldValuePair> none)
		{
			return SearchVideos(all, any, none, 100, 0);
		}

		#endregion

		#region FindRelatedVideos

		private BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideos(string searchParam, string searchValue, int pageSize, int pageNumber,
																			IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_related_videos");

			parms.Add(searchParam, searchValue);
			parms.Add("get_item_count", getItemCount.ToString().ToLower());
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="videoId">The id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosById(long videoId, int pageSize, int pageNumber,
																			   IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			return FindRelatedVideos("video_id", videoId.ToString(), pageSize, pageNumber, videoFields, customFields, getItemCount);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="videoId">The id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosById(long videoId, int pageSize, int pageNumber,
																			   IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindRelatedVideosById(videoId, pageSize, pageNumber, videoFields, customFields, true);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="videoId">The id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosById(long videoId, int pageSize, int pageNumber,
																			   IEnumerable<string> videoFields)
		{
			return FindRelatedVideosById(videoId, pageSize, pageNumber, videoFields, null);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="videoId">The id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosById(long videoId, int pageSize, int pageNumber)
		{
			return FindRelatedVideosById(videoId, pageSize, pageNumber, null, null);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="videoId">The id of the video we'd like related videos for.</param>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosById(long videoId)
		{
			return FindRelatedVideosById(videoId, 100, 0);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="referenceId">The reference id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosByReferenceId(string referenceId, int pageSize, int pageNumber, IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			return FindRelatedVideos("reference_id", referenceId, pageSize, pageNumber, videoFields, customFields, getItemCount);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="referenceId">The reference id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosByReferenceId(string referenceId, int pageSize, int pageNumber, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindRelatedVideosByReferenceId(referenceId, pageSize, pageNumber, videoFields, customFields, true);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="referenceId">The reference id of the video we'd like related videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosByReferenceId(string referenceId, int pageSize, int pageNumber)
		{
			return FindRelatedVideosByReferenceId(referenceId, pageSize, pageNumber, null, null);
		}

		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given 
		/// video and searches for any partial matches in the name, description, and tags of all videos in 
		/// the Brightcove media library for this account.
		/// </summary>
		/// <param name="referenceId">The reference id of the video we'd like related videos for.</param>
		/// <returns>A collection of videos, ordered by relevance to the provided video.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindRelatedVideosByReferenceId(string referenceId)
		{
			return FindRelatedVideosByReferenceId(referenceId, 100, 0);
		}

		#endregion

		#region FindVideosByUserId

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
																			IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_videos_by_user_id");

			parms.Add("user_id", userId);
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
																			IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindVideosByUserId(userId, pageSize, pageNumber, sortBy, sortOrder, videoFields, customFields, true);
		}

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
																			IEnumerable<string> videoFields)
		{
			return FindVideosByUserId(userId, pageSize, pageNumber, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder)
		{
			return FindVideosByUserId(userId, pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId, int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindVideosByUserId(userId, pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId, int pageSize, int pageNumber)
		{
			return FindVideosByUserId(userId, pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using
		/// the consumer-generated media (CGM) module.
		/// </summary>
		/// <param name="userId">The id of the user whose videos we'd like to retrieve.</param>
		/// <returns>An ItemCollection representing the requested page of Videos uploaded by the specified user, 
		/// in the order specified.</returns>
		[Obsolete("The find_videos_by_user_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByUserId(string userId)
		{
			return FindVideosByUserId(userId, 100, 0);
		}

		#endregion

		#region FindVideosByCampaignId

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. The 
		/// maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are in this campaign.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, 
																				IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_videos_by_campaign_id");

			parms.Add("campaign_id", campaignId.ToString());
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. The 
		/// maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
																				IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindVideosByCampaignId(campaignId, pageSize, pageNumber, sortBy, sortOrder, videoFields, customFields, true);
		}

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. The 
		/// maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder,
																				IEnumerable<string> videoFields)
		{
			return FindVideosByCampaignId(campaignId, pageSize, pageNumber, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. The 
		/// maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId, int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder)
		{
			return FindVideosByCampaignId(campaignId, pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. The 
		/// maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId, int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindVideosByCampaignId(campaignId, pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. The 
		/// maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId, int pageSize, int pageNumber)
		{
			return FindVideosByCampaignId(campaignId, pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Gets all the videos associated with the given campaign id. Campaigns are a feature of the consumer-generated media (CGM) module
		/// </summary>
		/// <param name="campaignId">The id of the campaign you'd like to fetch videos for.</param>
		/// <returns>The requested subset of all videos for the given campaign.</returns>
		[Obsolete("The find_videos_by_campaign_id call has been deprecated by Brightcove")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByCampaignId(long campaignId)
		{
			return FindVideosByCampaignId(campaignId, 100, 0);
		}

		#endregion

		#region FindModifiedVideos

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC time.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber, SortBy sortBy, 
																			SortOrder sortOrder, IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_modified_videos");

			parms.Add("from_date", fromDate.ToUnixMinutesUtc().ToString());

			if (filters != null)
			{
				parms.AddRange("filter", filters.Select(o => o.ToBrightcoveName()));	
			}

			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber, SortBy sortBy,
																			SortOrder sortOrder, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindModifiedVideos(fromDate, filters, pageSize, pageNumber, sortBy, sortOrder, videoFields, customFields, true);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber, SortBy sortBy,
																			SortOrder sortOrder, IEnumerable<string> videoFields)
		{
			return FindModifiedVideos(fromDate, filters, pageSize, pageNumber, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber, SortBy sortBy,
																			SortOrder sortOrder)
		{
			return FindModifiedVideos(fromDate, filters, pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindModifiedVideos(fromDate, filters, pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that 
		/// satisfy the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber)
		{
			return FindModifiedVideos(fromDate, filters, pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned, specified in UTC.</param>
		/// <param name="filters">A list of filters, specifying which categories of videos you would like returned. 
		/// Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters)
		{
			return FindModifiedVideos(fromDate, filters, 25, 0);
		}

		/// <summary>
		/// Gets all the videos that have been modified since the given time, specified in UTC.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Video which you would like returned.</param>
		/// <returns>All videos that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveVideo> FindModifiedVideos(DateTime fromDate)
		{
			return FindModifiedVideos(fromDate, null);
		}

		#endregion

		#region FindVideosByText

		/// <summary>
		/// Searches through all the videos in this account, and returns a collection of videos whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text to search for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos whose name, short description, or long description contain a match for the text specified.</returns>
		[Obsolete("The find_videos_by_text call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByText(string text, int pageSize, int pageNumber, IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_videos_by_text");

			parms.Add("text", text);
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Searches through all the videos in this account, and returns a collection of videos whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text to search for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos whose name, short description, or long description contain a match for the text specified.</returns>
		[Obsolete("The find_videos_by_text call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByText(string text, int pageSize, int pageNumber, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindVideosByText(text, pageSize, pageNumber, videoFields, customFields, true);
		}

		/// <summary>
		/// Searches through all the videos in this account, and returns a collection of videos whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text to search for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos whose name, short description, or long description contain a match for the text specified.</returns>
		[Obsolete("The find_videos_by_text call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByText(string text, int pageSize, int pageNumber, IEnumerable<string> videoFields)
		{
			return FindVideosByText(text, pageSize, pageNumber, videoFields, null);
		}

		/// <summary>
		/// Searches through all the videos in this account, and returns a collection of videos whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text to search for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the 
		/// request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of videos whose name, short description, or long description contain a match for the text specified.</returns>
		[Obsolete("The find_videos_by_text call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByText(string text, int pageSize, int pageNumber)
		{
			return FindVideosByText(text, pageSize, pageNumber, null);
		}

		/// <summary>
		/// Searches through all the videos in this account, and returns a collection of videos whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text to search for.</param>
		/// <returns>A collection of videos whose name, short description, or long description contain a match for the text specified.</returns>
		[Obsolete("The find_videos_by_text call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByText(string text)
		{
			return FindVideosByText(text, 100, 0);
		}

		#endregion

		#region FindVideosByTags
		
		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber, SortBy sortBy, 
			SortOrder sortOrder, IEnumerable<string> videoFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_videos_by_tags");

			if (andTags != null)
			{
				parms.AddRange("and_tags", andTags);
			}

			if (orTags != null)
			{
				parms.AddRange("or_tags", orTags);
			}

			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveVideo>>(parms);
		}

		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated 
		/// in the videos contained in the returned object. If you omit this parameter, no custom fields are 
		/// returned, unless you include the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber, SortBy sortBy,
			SortOrder sortOrder, IEnumerable<string> videoFields, IEnumerable<string> customFields)
		{
			return FindVideosByTags(andTags, orTags, pageSize, pageNumber, sortBy, sortOrder, videoFields, customFields, true);
		}

		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the 
		/// Videos contained in the returned object. If you omit this parameter, the method returns the 
		/// following fields of the video: id, name, shortDescription, longDescription, creationDate, 
		/// publisheddate, lastModifiedDate, linkURL, linkText, tags, videoStillURL, thumbnailURL, 
		/// referenceId, length, economics, playsTotal, playsTrailingWeek. If you use a token with URL 
		/// access, this method also returns FLVURL, renditions, FLVFullLength, videoFullLength.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber, SortBy sortBy,
			SortOrder sortOrder, IEnumerable<string> videoFields)
		{
			return FindVideosByTags(andTags, orTags, pageSize, pageNumber, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber, SortBy sortBy,
			SortOrder sortOrder)
		{
			return FindVideosByTags(andTags, orTags, pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindVideosByTags(andTags, orTags, pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items 
		/// that satisfy the request. The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber)
		{
			return FindVideosByTags(andTags, orTags, pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that 
		/// contain the specified tags. Note that tags are not case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <returns>A collection of videos whose tags match the tags specified.</returns>
		[Obsolete("The find_videos_by_tags call has been deprecated by Brightcove in favor of the search_videos call")]
		public BrightcoveItemCollection<BrightcoveVideo> FindVideosByTags(IEnumerable<string> andTags, IEnumerable<string> orTags)
		{
			return FindVideosByTags(andTags, orTags, 100, 0);
		}

		#endregion
	}
}
