using System;
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
		#region FindAllAudioTracks

		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. Maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audiotracks 
		/// contained in the returned object.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of audio tracks matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAllAudioTracks(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_all_audiotracks");

			parms.Add("get_item_count", getItemCount.ToString().ToLower());
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrack>>(parms);
		}

		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. Maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audiotracks 
		/// contained in the returned object.</param>
		/// <returns>A collection of audio tracks matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAllAudioTracks(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields)
		{
			return FindAllAudioTracks(pageSize, pageNumber, sortBy, sortOrder, audioTrackFields, true);
		}

		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. Maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>A collection of audio tracks matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAllAudioTracks(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder)
		{
			return FindAllAudioTracks(pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. Maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>A collection of audio tracks matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAllAudioTracks(int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindAllAudioTracks(pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		/// <param name="pageSize">Number of items returned per page. Maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of audio tracks matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAllAudioTracks(int pageSize, int pageNumber)
		{
			return FindAllAudioTracks(pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		/// <returns>A collection of audio tracks matching the specified search criteria.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAllAudioTracks()
		{
			return FindAllAudioTracks(100, 0);
		}

		#endregion

		#region FindAudioTrackById

		/// <summary>
		/// Finds a single audio track with the specified id.
		/// </summary>
		/// <param name="audioTrackId">The id of the audio track you would like to retrieve.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audiotrack 
		/// contained in the returned object.</param>
		/// <returns>The Audio Track you requested, with the specified fields populated, or null, if there is no audio 
		/// track with that id.</returns>
		public BrightcoveAudioTrack FindAudioTrackById(long audioTrackId, IEnumerable<string> audioTrackFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotrack_by_id");
			parms.Add("audiotrack_id", audioTrackId.ToString());

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveAudioTrack>(parms);
		}

		/// <summary>
		/// Finds a single audio track with the specified id.
		/// </summary>
		/// <param name="audioTrackId">The id of the audio track you would like to retrieve.</param>
		/// <returns>The Audio Track you requested, with the specified fields populated, or null, if there is no audio 
		/// track with that id.</returns>
		public BrightcoveAudioTrack FindAudioTrackById(long audioTrackId)
		{
			return FindAudioTrackById(audioTrackId, null);
		}

		#endregion

		#region FindAudioTrackByReferenceId

		/// <summary>
		/// Find an audio track based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The publisher-assigned reference id for the audio track we're searching for.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audiotrack 
		/// contained in the returned object.</param>
		/// <returns>The Audio Track whose reference id matches the one given, or null if no match is found.</returns>
		public BrightcoveAudioTrack FindAudioTrackByReferenceId(string referenceId, IEnumerable<string> audioTrackFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotrack_by_reference_id");
			parms.Add("reference_id", referenceId);

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveAudioTrack>(parms);
		}

		/// <summary>
		/// Find an audio track based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The publisher-assigned reference id for the audio track we're searching for.</param>
		/// <returns>The Audio Track whose reference id matches the one given, or null if no match is found.</returns>
		public BrightcoveAudioTrack FindAudioTrackByReferenceId(string referenceId)
		{
			return FindAudioTrackByReferenceId(referenceId, null);
		}

		#endregion

		#region FindAudioTracksByIds

		/// <summary>
		/// Find multiple audio tracks, given their ids.
		/// </summary>
		/// <param name="audioTrackIds">The list of audio track ids for the audio tracks we'd like to retrieve.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audiotracks
		/// contained in the returned object.</param>
		/// <returns>A collection that contains the audio track objects corresponding to the audio track ids given.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByIds(IEnumerable<long> audioTrackIds, IEnumerable<string> audioTrackFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotracks_by_ids");
			if (audioTrackIds == null)
			{
				throw new ArgumentNullException("audioTrackIds");
			}
			parms.AddRange("audiotrack_ids", audioTrackIds.Select(o => o.ToString()));

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrack>>(parms);
		}

		/// <summary>
		/// Find multiple audio tracks, given their ids.
		/// </summary>
		/// <param name="audioTrackIds">The list of audio track ids for the audio tracks we'd like to retrieve.</param>
		/// <returns>A collection that contains the audio track objects corresponding to the audio track ids given.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByIds(IEnumerable<long> audioTrackIds)
		{
			return FindAudioTracksByIds(audioTrackIds, null);
		}

		#endregion

		#region FindAudioTracksByReferenceIds

		/// <summary>
		/// Find multiple audio tracks based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The list of reference ids for the audio tracks we'd like to retrieve</param>
		/// <param name="audioTrackFields">A comma-separated list of the fields you wish to have populated in the audio 
		/// tracks contained in the returned object. </param>
		/// <returns>The collection of audio tracks specified by the reference ids provided.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByReferenceIds(IEnumerable<string> referenceIds, IEnumerable<string> audioTrackFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotracks_by_reference_ids");
			if (referenceIds == null)
			{
				throw new ArgumentNullException("referenceIds");
			}
			parms.AddRange("reference_ids", referenceIds);

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrack>>(parms);
		}

		/// <summary>
		/// Find multiple audio tracks based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The list of reference ids for the audio tracks we'd like to retrieve</param>
		/// <returns>The collection of audio tracks specified by the reference ids provided.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByReferenceIds(IEnumerable<string> referenceIds)
		{
			return FindAudioTracksByReferenceIds(referenceIds, null);
		}

		#endregion

		#region FindAudioTracksByTags

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results. In this method, results can be sorted only by MODIFIED_DATE 
		/// and PLAYS_TRAILING_WEEK.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained 
		/// in the returned object.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns></returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber, 
																					SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotracks_by_tags");

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

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrack>>(parms);
		}

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results. In this method, results can be sorted only by MODIFIED_DATE 
		/// and PLAYS_TRAILING_WEEK.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained 
		/// in the returned object.</param>
		/// <returns>A collection of audio tracks whose tags match the tags specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber,
																					SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields)
		{
			return FindAudioTracksByTags(andTags, orTags, pageSize, pageNumber, sortBy, sortOrder, audioTrackFields, true);
		}

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results. In this method, results can be sorted only by MODIFIED_DATE 
		/// and PLAYS_TRAILING_WEEK.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>A collection of audio tracks whose tags match the tags specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber,
																					SortBy sortBy, SortOrder sortOrder)
		{
			return FindAudioTracksByTags(andTags, orTags, pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results. In this method, results can be sorted only by MODIFIED_DATE 
		/// and PLAYS_TRAILING_WEEK.</param>
		/// <returns>A collection of audio tracks whose tags match the tags specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber,
																					SortBy sortBy)
		{
			return FindAudioTracksByTags(andTags, orTags, pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of audio tracks whose tags match the tags specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags, IEnumerable<string> orTags, int pageSize, int pageNumber)
		{
			return FindAudioTracksByTags(andTags, orTags, pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <param name="orTags">Limit the results to those that contain at least one of these tags.</param>
		/// <returns>A collection of audio tracks whose tags match the tags specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags, IEnumerable<string> orTags)
		{
			return FindAudioTracksByTags(andTags, orTags, 100, 0);
		}

		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that 
		/// contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		/// <param name="andTags">Limit the results to those that contain all of these tags.</param>
		/// <returns>A collection of audio tracks whose tags match the tags specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByTags(IEnumerable<string> andTags)
		{
			return FindAudioTracksByTags(andTags, null);
		}

		#endregion

		#region FindAudioTracksByText

		/// <summary>
		/// Searches through all the audio tracks in this account, and returns a collection of audio tracks whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text we're searching for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the returned object. </param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of audio tracks whose name, short description, or long description contain a match for the text specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByText(string text, int pageSize, int pageNumber, IEnumerable<string> audioTrackFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotracks_by_text");

			parms.Add("text", text);
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrack>>(parms);
		}

		/// <summary>
		/// Searches through all the audio tracks in this account, and returns a collection of audio tracks whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text we're searching for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the returned object. </param>
		/// <returns>A collection of audio tracks whose name, short description, or long description contain a match for the text specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByText(string text, int pageSize, int pageNumber, IEnumerable<string> audioTrackFields)
		{
			return FindAudioTracksByText(text, pageSize, pageNumber, audioTrackFields, true);
		}

		/// <summary>
		/// Searches through all the audio tracks in this account, and returns a collection of audio tracks whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text we're searching for.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy the request. 
		/// The maximum page size is 100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of audio tracks whose name, short description, or long description contain a match for the text specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByText(string text, int pageSize, int pageNumber)
		{
			return FindAudioTracksByText(text, pageSize, pageNumber, null);
		}

		/// <summary>
		/// Searches through all the audio tracks in this account, and returns a collection of audio tracks whose name, short description, 
		/// or long description contain a match for the specified text.
		/// </summary>
		/// <param name="text">The text we're searching for.</param>
		/// <returns>A collection of audio tracks whose name, short description, or long description contain a match for the text specified.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindAudioTracksByText(string text)
		{
			return FindAudioTracksByText(text, 100, 0);
		}

		#endregion

		#region FindModifiedAudioTracks

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <param name="filters">A comma-separated list of filters, specifying which categories of audio tracks you would 
		/// like returned. Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy 
		/// the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks 
		/// contained in the returned object.</param>
		/// <param name="getItemCount">If true, also return how many total results there are in this campaign.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber, 
																					  SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_modified_audiotracks");

			parms.Add("from_date", fromDate.ToUnixMinutesUtc().ToString());

			if (filters != null)
			{
				parms.AddRange("filter", filters.Select(o => o.ToBrightcoveName()));
			}

			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());
			parms.Add("sort_by", sortBy.ToBrightcoveName());

			// work around an apparent bug in the API by not specifying sort order when it's "Ascending"
			if (sortOrder != SortOrder.Ascending)
			{
				parms.Add("sort_order", sortOrder.ToBrightcoveName());
			}

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrack>>(parms);
		}

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <param name="filters">A comma-separated list of filters, specifying which categories of audio tracks you would 
		/// like returned. Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy 
		/// the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks 
		/// contained in the returned object.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber,
																					  SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields)
		{
			return FindModifiedAudioTracks(fromDate, filters, pageSize, pageNumber, sortBy, sortOrder, audioTrackFields, true);
		}

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <param name="filters">A comma-separated list of filters, specifying which categories of audio tracks you would 
		/// like returned. Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy 
		/// the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <param name="sortOrder">How to order the results: ascending or descending.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber,
																					  SortBy sortBy, SortOrder sortOrder)
		{
			return FindModifiedAudioTracks(fromDate, filters, pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <param name="filters">A comma-separated list of filters, specifying which categories of audio tracks you would 
		/// like returned. Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy 
		/// the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The field by which to sort the results.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber,
																					  SortBy sortBy)
		{
			return FindModifiedAudioTracks(fromDate, filters, pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <param name="filters">A comma-separated list of filters, specifying which categories of audio tracks you would 
		/// like returned. Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <param name="pageSize">Number of items returned per page. A page is a subset of all of the items that satisfy 
		/// the request. The maximum page size is 25.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters, int pageSize, int pageNumber)
		{
			return FindModifiedAudioTracks(fromDate, filters, pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <param name="filters">A comma-separated list of filters, specifying which categories of audio tracks you would 
		/// like returned. Valid filter values are PLAYABLE, UNSCHEDULED, INACTIVE, and DELETED.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate, IEnumerable<ModifiedVideoFilter> filters)
		{
			return FindModifiedAudioTracks(fromDate, filters, 25, 0);
		}

		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		/// <param name="fromDate">The date of the oldest Audio Track which you would like returned, specified in UTC.</param>
		/// <returns>All audio tracks that have been modified since the given time.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrack> FindModifiedAudioTracks(DateTime fromDate)
		{
			return FindModifiedAudioTracks(fromDate, null);
		}

		#endregion
	}
}
