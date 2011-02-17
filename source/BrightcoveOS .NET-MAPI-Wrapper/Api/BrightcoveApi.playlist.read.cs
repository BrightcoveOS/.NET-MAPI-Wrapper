using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveMapiWrapper.Api
{
	public partial class BrightcoveApi
	{
		#region FindAllPlaylists

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property that you'd like to sort the results by.</param>
		/// <param name="sortOrder">The order that you'd like the results sorted - ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> videoFields, 
																			 IEnumerable<string> playlistFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_all_playlists");

			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());
			
			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcovePlaylist>>(parms);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property that you'd like to sort the results by.</param>
		/// <param name="sortOrder">The order that you'd like the results sorted - ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> videoFields,
																			 IEnumerable<string> playlistFields, IEnumerable<string> customFields)
		{
			return FindAllPlaylists(pageSize, pageNumber, sortBy, sortOrder, videoFields, playlistFields, customFields, false);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property that you'd like to sort the results by.</param>
		/// <param name="sortOrder">The order that you'd like the results sorted - ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> videoFields,
																			 IEnumerable<string> playlistFields)
		{
			return FindAllPlaylists(pageSize, pageNumber, sortBy, sortOrder, videoFields, playlistFields, null);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property that you'd like to sort the results by.</param>
		/// <param name="sortOrder">The order that you'd like the results sorted - ascending or descending.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> videoFields)
		{
			return FindAllPlaylists(pageSize, pageNumber, sortBy, sortOrder, videoFields, null);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property that you'd like to sort the results by.</param>
		/// <param name="sortOrder">The order that you'd like the results sorted - ascending or descending.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder)
		{
			return FindAllPlaylists(pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property that you'd like to sort the results by.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindAllPlaylists(pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the playlists that 
		/// satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists(int pageSize, int pageNumber)
		{
			return FindAllPlaylists(pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindAllPlaylists()
		{
			return FindAllPlaylists(50, 0);
		}

		#endregion

		#region FindPlaylistById

		/// <summary>
		/// Finds a particular playlist based on its id.
		/// </summary>
		/// <param name="playlistId">The id of the playlist requested.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>The playlist requested, or null, if there is no playlist with that id.</returns>
		public BrightcovePlaylist FindPlaylistById(long playlistId, IEnumerable<string> videoFields, IEnumerable<string> playlistFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_playlist_by_id");

			parms.Add("playlist_id", playlistId.ToString());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcovePlaylist>(parms);
		}

		/// <summary>
		/// Finds a particular playlist based on its id.
		/// </summary>
		/// <param name="playlistId">The id of the playlist requested.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <returns>The playlist requested, or null, if there is no playlist with that id.</returns>
		public BrightcovePlaylist FindPlaylistById(long playlistId, IEnumerable<string> videoFields, IEnumerable<string> playlistFields)
		{
			return FindPlaylistById(playlistId, videoFields, playlistFields, null);
		}

		/// <summary>
		/// Finds a particular playlist based on its id.
		/// </summary>
		/// <param name="playlistId">The id of the playlist requested.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <returns>The playlist requested, or null, if there is no playlist with that id.</returns>
		public BrightcovePlaylist FindPlaylistById(long playlistId, IEnumerable<string> videoFields)
		{
			return FindPlaylistById(playlistId, videoFields, null);
		}

		/// <summary>
		/// Finds a particular playlist based on its id.
		/// </summary>
		/// <param name="playlistId">The id of the playlist requested.</param>
		/// <returns>The playlist requested, or null, if there is no playlist with that id.</returns>
		public BrightcovePlaylist FindPlaylistById(long playlistId)
		{
			return FindPlaylistById(playlistId, null);
		}

		#endregion

		#region FindPlaylistsByIds

		/// <summary>
		/// Retrieve a set of playlists based on their ids.
		/// </summary>
		/// <param name="playlistIds">The ids of the playlists you would like retrieved.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, 
		/// null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByIds(IEnumerable<long> playlistIds, IEnumerable<string> videoFields, 
																			   IEnumerable<string> playlistFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_playlists_by_ids");

			if (playlistIds == null)
			{
				throw new ArgumentNullException("playlistIds");
			}
			parms.AddRange("playlist_ids", playlistIds.Select(o => o.ToString()));

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcovePlaylist>>(parms);
		}

		/// <summary>
		/// Retrieve a set of playlists based on their ids.
		/// </summary>
		/// <param name="playlistIds">The ids of the playlists you would like retrieved.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, 
		/// null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByIds(IEnumerable<long> playlistIds, IEnumerable<string> videoFields,
																			   IEnumerable<string> playlistFields)
		{
			return FindPlaylistsByIds(playlistIds, videoFields, playlistFields, null);
		}

		/// <summary>
		/// Retrieve a set of playlists based on their ids.
		/// </summary>
		/// <param name="playlistIds">The ids of the playlists you would like retrieved.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, 
		/// null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByIds(IEnumerable<long> playlistIds, IEnumerable<string> videoFields)
		{
			return FindPlaylistsByIds(playlistIds, videoFields, null);
		}

		/// <summary>
		/// Retrieve a set of playlists based on their ids.
		/// </summary>
		/// <param name="playlistIds">The ids of the playlists you would like retrieved.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, 
		/// null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByIds(IEnumerable<long> playlistIds)
		{
			return FindPlaylistsByIds(playlistIds, null);
		}

		#endregion

		#region FindPlaylistByReferenceId

		/// <summary>
		/// Retrieve a playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>The playlist that has the given reference id, or null if there is no matching playlist.</returns>
		public BrightcovePlaylist FindPlaylistByReferenceId(string referenceId, IEnumerable<string> videoFields, IEnumerable<string> playlistFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_playlist_by_reference_id");

			parms.Add("reference_id", referenceId);

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcovePlaylist>(parms);
		}

		/// <summary>
		/// Retrieve a playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <returns>The playlist that has the given reference id, or null if there is no matching playlist.</returns>
		public BrightcovePlaylist FindPlaylistByReferenceId(string referenceId, IEnumerable<string> videoFields, IEnumerable<string> playlistFields)
		{
			return FindPlaylistByReferenceId(referenceId, videoFields, playlistFields, null);
		}

		/// <summary>
		/// Retrieve a playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <returns>The playlist that has the given reference id, or null if there is no matching playlist.</returns>
		public BrightcovePlaylist FindPlaylistByReferenceId(string referenceId, IEnumerable<string> videoFields)
		{
			return FindPlaylistByReferenceId(referenceId, videoFields, null);
		}

		/// <summary>
		/// Retrieve a playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <returns>The playlist that has the given reference id, or null if there is no matching playlist.</returns>
		public BrightcovePlaylist FindPlaylistByReferenceId(string referenceId)
		{
			return FindPlaylistByReferenceId(referenceId, null);
		}

		#endregion

		#region FindPlaylistsByReferenceIds

		/// <summary>
		/// Retrieve multiple playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>A collection of the specified playlists, in the order of the reference ids you passed in. If no 
		/// playlist exists for a reference id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByReferenceIds(IEnumerable<string> referenceIds, IEnumerable<string> videoFields,
																						IEnumerable<string> playlistFields, IEnumerable<string> customFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_playlists_by_reference_ids");

			if (referenceIds == null)
			{
				throw new ArgumentNullException("referenceIds");
			}
			parms.AddRange("reference_ids", referenceIds);

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcovePlaylist>>(parms);
		}

		/// <summary>
		/// Retrieve multiple playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <returns>A collection of the specified playlists, in the order of the reference ids you passed in. If no 
		/// playlist exists for a reference id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByReferenceIds(IEnumerable<string> referenceIds, IEnumerable<string> videoFields,
																						IEnumerable<string> playlistFields)
		{
			return FindPlaylistsByReferenceIds(referenceIds, videoFields, playlistFields, null);
		}

		/// <summary>
		/// Retrieve multiple playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <returns>A collection of the specified playlists, in the order of the reference ids you passed in. If no 
		/// playlist exists for a reference id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByReferenceIds(IEnumerable<string> referenceIds, IEnumerable<string> videoFields)
		{
			return FindPlaylistsByReferenceIds(referenceIds, videoFields, null);
		}

		/// <summary>
		/// Retrieve multiple playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <returns>A collection of the specified playlists, in the order of the reference ids you passed in. If no 
		/// playlist exists for a reference id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsByReferenceIds(IEnumerable<string> referenceIds)
		{
			return FindPlaylistsByReferenceIds(referenceIds, null);
		}

		#endregion

		#region FindPlaylistsForPlayerId

		/// <summary>
		/// Given the id of a player, returns all the playlists assigned to that player.
		/// </summary>
		/// <param name="playerId">The player id whose playlists we want to return.</param>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all 
		/// of the playlists that satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>The collection of playlists requested.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsForPlayerId(long playerId, int pageSize, int pageNumber, IEnumerable<string> videoFields,
																					 IEnumerable<string> playlistFields, IEnumerable<string> customFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_playlists_for_player_id");

			parms.Add("player_id", playerId.ToString());
			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (videoFields != null)
			{
				parms.AddRange("video_fields", videoFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", videoFields);
			}

			if (customFields != null)
			{
				parms.AddRange("custom_fields", customFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcovePlaylist>>(parms);
		}

		/// <summary>
		/// Given the id of a player, returns all the playlists assigned to that player.
		/// </summary>
		/// <param name="playerId">The player id whose playlists we want to return.</param>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all 
		/// of the playlists that satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <param name="customFields">A list of the custom fields you wish to have populated in the videos 
		/// contained in the returned object. If you omit this parameter, no custom fields are returned, unless you include 
		/// the value 'customFields' in the video_fields parameter.</param>
		/// <returns>The collection of playlists requested.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsForPlayerId(long playerId, int pageSize, int pageNumber, IEnumerable<string> videoFields,
																					 IEnumerable<string> playlistFields, IEnumerable<string> customFields)
		{
			return FindPlaylistsForPlayerId(playerId, pageSize, pageNumber, videoFields, playlistFields, customFields, true);
		}

		/// <summary>
		/// Given the id of a player, returns all the playlists assigned to that player.
		/// </summary>
		/// <param name="playerId">The player id whose playlists we want to return.</param>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all 
		/// of the playlists that satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the Playlists 
		/// contained in the returned object. If you omit this parameter, all playlist fields are returned.</param>
		/// <returns>The collection of playlists requested.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsForPlayerId(long playerId, int pageSize, int pageNumber, IEnumerable<string> videoFields,
																					 IEnumerable<string> playlistFields)
		{
			return FindPlaylistsForPlayerId(playerId, pageSize, pageNumber, videoFields, playlistFields, null);
		}

		/// <summary>
		/// Given the id of a player, returns all the playlists assigned to that player.
		/// </summary>
		/// <param name="playerId">The player id whose playlists we want to return.</param>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all 
		/// of the playlists that satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="videoFields">A list of the fields you wish to have populated in the Videos 
		/// contained in the playlists. If you omit this parameter, the method returns the following fields of the 
		/// Video: id, name, shortDescription, longDescription, creationDate, publisheddate, lastModifiedDate, linkURL, 
		/// linkText, tags, videoStillURL, thumbnailURL, referenceId, length, economics, playsTotal, playsTrailingWeek. 
		/// If you use a token with URL access, this method also returns the Videos' FLVURL, renditions, FLVFullLength, 
		/// videoFullLength.</param>
		/// <returns>The collection of playlists requested.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsForPlayerId(long playerId, int pageSize, int pageNumber, IEnumerable<string> videoFields)
		{
			return FindPlaylistsForPlayerId(playerId, pageSize, pageNumber, videoFields, null);
		}

		/// <summary>
		/// Given the id of a player, returns all the playlists assigned to that player.
		/// </summary>
		/// <param name="playerId">The player id whose playlists we want to return.</param>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all 
		/// of the playlists that satisfy the request. The maximum page size is 50.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>The collection of playlists requested.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsForPlayerId(long playerId, int pageSize, int pageNumber)
		{
			return FindPlaylistsForPlayerId(playerId, pageSize, pageNumber, null);
		}

		/// <summary>
		/// Given the id of a player, returns all the playlists assigned to that player.
		/// </summary>
		/// <param name="playerId">The player id whose playlists we want to return.</param>
		/// <returns>The collection of playlists requested.</returns>
		public BrightcoveItemCollection<BrightcovePlaylist> FindPlaylistsForPlayerId(long playerId)
		{
			return FindPlaylistsForPlayerId(playerId, 50, 0);
		}

		#endregion
	}
}
