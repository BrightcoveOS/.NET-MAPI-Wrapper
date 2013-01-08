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
		#region FindAllAudioTrackPlaylists

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the 
		/// playlists that satisfy the request. The maximum page size is 100; if you do not set this argument, 
		/// or if you set it to an integer > 100, your results will come back as if you had set page_size=100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property by which you'd like to sort the results.</param>
		/// <param name="sortOrder">The order in which you'd like the results sorted - ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained 
		/// in the playlists.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the playlists contained in 
		/// the returned object.</param>
		/// <param name="getItemCount">If true, also return how many total results there are.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields,
																			 IEnumerable<string> playlistFields, bool getItemCount)
		{
			NameValueCollection parms = BuildBasicReadParams("find_all_audiotrack_playlists");

			parms.Add("page_size", pageSize.ToString());
			parms.Add("page_number", pageNumber.ToString());
			parms.Add("sort_by", sortBy.ToBrightcoveName());
			parms.Add("sort_order", sortOrder.ToBrightcoveName());
			parms.Add("get_item_count", getItemCount.ToString().ToLower());

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrackPlaylist>>(parms);
		}

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the 
		/// playlists that satisfy the request. The maximum page size is 100; if you do not set this argument, 
		/// or if you set it to an integer > 100, your results will come back as if you had set page_size=100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property by which you'd like to sort the results.</param>
		/// <param name="sortOrder">The order in which you'd like the results sorted - ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained 
		/// in the playlists.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the playlists contained in 
		/// the returned object.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields,
																			 IEnumerable<string> playlistFields)
		{
			return FindAllAudioTrackPlaylists(pageSize, pageNumber, sortBy, sortOrder, audioTrackFields, playlistFields, true);
		}

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the 
		/// playlists that satisfy the request. The maximum page size is 100; if you do not set this argument, 
		/// or if you set it to an integer > 100, your results will come back as if you had set page_size=100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property by which you'd like to sort the results.</param>
		/// <param name="sortOrder">The order in which you'd like the results sorted - ascending or descending.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained 
		/// in the playlists.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder, IEnumerable<string> audioTrackFields)
		{
			return FindAllAudioTrackPlaylists(pageSize, pageNumber, sortBy, sortOrder, audioTrackFields, null);
		}

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the 
		/// playlists that satisfy the request. The maximum page size is 100; if you do not set this argument, 
		/// or if you set it to an integer > 100, your results will come back as if you had set page_size=100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property by which you'd like to sort the results.</param>
		/// <param name="sortOrder">The order in which you'd like the results sorted - ascending or descending.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists(int pageSize, int pageNumber, SortBy sortBy, SortOrder sortOrder)
		{
			return FindAllAudioTrackPlaylists(pageSize, pageNumber, sortBy, sortOrder, null);
		}

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the 
		/// playlists that satisfy the request. The maximum page size is 100; if you do not set this argument, 
		/// or if you set it to an integer > 100, your results will come back as if you had set page_size=100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <param name="sortBy">The property by which you'd like to sort the results.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists(int pageSize, int pageNumber, SortBy sortBy)
		{
			return FindAllAudioTrackPlaylists(pageSize, pageNumber, sortBy, SortOrder.Ascending);
		}

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <param name="pageSize">Number of playlists returned per page. A page is a subset of all of the 
		/// playlists that satisfy the request. The maximum page size is 100; if you do not set this argument, 
		/// or if you set it to an integer > 100, your results will come back as if you had set page_size=100.</param>
		/// <param name="pageNumber">The zero-indexed number of the page to return.</param>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists(int pageSize, int pageNumber)
		{
			return FindAllAudioTrackPlaylists(pageSize, pageNumber, SortBy.CreationDate);
		}

		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		/// <returns>A collection of Playlists that is the specified subset of all the playlists in this account.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAllAudioTrackPlaylists()
		{
			return FindAllAudioTrackPlaylists(100, 0);
		}

		#endregion 

		#region FindAudioTrackPlaylistById

		/// <summary>
		/// Finds a particular audio track playlist based on its id.
		/// </summary>
		/// <param name="audioTrackPlaylistId">The id of the playlist requested.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the playlists.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the playlists contained in the returned object.</param>
		/// <returns>The playlist requested, or null, if there is no audio track playlist with that id.</returns>
		public BrightcoveAudioTrackPlaylist FindAudioTrackPlaylistById(long audioTrackPlaylistId, IEnumerable<string> audioTrackFields, IEnumerable<string> playlistFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotrack_playlist_by_id");

			parms.Add("audiotrack_playlist_id", audioTrackPlaylistId.ToString());

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			return RunQuery<BrightcoveAudioTrackPlaylist>(parms);
		}

		/// <summary>
		/// Finds a particular audio track playlist based on its id.
		/// </summary>
		/// <param name="audioTrackPlaylistId">The id of the playlist requested.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the playlists.</param>
		/// <returns>The playlist requested, or null, if there is no audio track playlist with that id.</returns>
		public BrightcoveAudioTrackPlaylist FindAudioTrackPlaylistById(long audioTrackPlaylistId, IEnumerable<string> audioTrackFields)
		{
			return FindAudioTrackPlaylistById(audioTrackPlaylistId, audioTrackFields, null);
		}

		/// <summary>
		/// Finds a particular audio track playlist based on its id.
		/// </summary>
		/// <param name="audioTrackPlaylistId">The id of the playlist requested.</param>
		/// <returns>The playlist requested, or null, if there is no audio track playlist with that id.</returns>
		public BrightcoveAudioTrackPlaylist FindAudioTrackPlaylistById(long audioTrackPlaylistId)
		{
			return FindAudioTrackPlaylistById(audioTrackPlaylistId, null);
		}
		
		#endregion

		#region FindAudioTrackPlaylistByReferenceId

		/// <summary>
		/// Retrieve an audio track playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks 
		/// contained in the playlists.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the playlists contained 
		/// in the returned object. Passing null populates with all fields.</param>
		/// <returns>The playlist that has the given reference id.</returns>
		public BrightcoveAudioTrackPlaylist FindAudioTrackPlaylistByReferenceId(string referenceId, IEnumerable<string> audioTrackFields, IEnumerable<string> playlistFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotrack_playlist_by_reference_id");

			parms.Add("reference_id", referenceId);

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			return RunQuery<BrightcoveAudioTrackPlaylist>(parms);
		}

		/// <summary>
		/// Retrieve an audio track playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks 
		/// contained in the playlists.</param>
		/// <returns>The playlist that has the given reference id.</returns>
		public BrightcoveAudioTrackPlaylist FindAudioTrackPlaylistByReferenceId(string referenceId, IEnumerable<string> audioTrackFields)
		{
			return FindAudioTrackPlaylistByReferenceId(referenceId, audioTrackFields, null);
		}

		/// <summary>
		/// Retrieve an audio track playlist based on its publisher-assigned reference id.
		/// </summary>
		/// <param name="referenceId">The reference id of the playlist we'd like to retrieve.</param>
		/// <returns>The playlist that has the given reference id.</returns>
		public BrightcoveAudioTrackPlaylist FindAudioTrackPlaylistByReferenceId(string referenceId)
		{
			return FindAudioTrackPlaylistByReferenceId(referenceId, null);
		}

		#endregion

		#region FindAudioTrackPlaylistsByIds

		/// <summary>
		/// Retrieve a set of audio track playlists based on their ids.
		/// </summary>
		/// <param name="audioTrackPlaylistIds">The ids of the playlists you would like retrieved.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the playlists.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the playlists contained in the returned object.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAudioTrackPlaylistsByIds(IEnumerable<long> audioTrackPlaylistIds,
			IEnumerable<string> audioTrackFields, IEnumerable<string> playlistFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotrack_playlists_by_ids");

			if (audioTrackPlaylistIds == null)
			{
				throw new ArgumentNullException("audioTrackPlaylistIds");
			}
			parms.AddRange("audiotrack_playlist_ids", audioTrackPlaylistIds.Select(o => o.ToString()));

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrackPlaylist>>(parms);
		}

		/// <summary>
		/// Retrieve a set of audio track playlists based on their ids.
		/// </summary>
		/// <param name="audioTrackPlaylistIds">The ids of the playlists you would like retrieved.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the playlists.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAudioTrackPlaylistsByIds(IEnumerable<long> audioTrackPlaylistIds,
			IEnumerable<string> audioTrackFields)
		{
			return FindAudioTrackPlaylistsByIds(audioTrackPlaylistIds, audioTrackFields, null);
		}

		/// <summary>
		/// Retrieve a set of audio track playlists based on their ids.
		/// </summary>
		/// <param name="audioTrackPlaylistIds">The ids of the playlists you would like retrieved.</param>
		/// <returns>The specified playlists, in the order of the ids you passed in. If no playlist exists for an id, null is returned in its place.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAudioTrackPlaylistsByIds(IEnumerable<long> audioTrackPlaylistIds)
		{
			return FindAudioTrackPlaylistsByIds(audioTrackPlaylistIds, null);
		}

		#endregion

		#region FindAudioTrackPlaylistsByReferenceIds

		/// <summary>
		/// Retrieve multiple audio track playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the playlists.</param>
		/// <param name="playlistFields">A list of the fields you wish to have populated in the playlists contained in the returned object. </param>
		/// <returns>The specified playlists, in the order of the reference ids you passed in.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAudioTrackPlaylistsByReferenceIds(IEnumerable<string> referenceIds,
			IEnumerable<string> audioTrackFields, IEnumerable<string> playlistFields)
		{
			NameValueCollection parms = BuildBasicReadParams("find_audiotrack_playlists_by_reference_ids");

			if (referenceIds == null)
			{
				throw new ArgumentNullException("referenceIds");
			}
			parms.AddRange("reference_ids", referenceIds);

			if (audioTrackFields != null)
			{
				parms.AddRange("audiotrack_fields", audioTrackFields);
			}

			if (playlistFields != null)
			{
				parms.AddRange("playlist_fields", playlistFields);
			}

			return RunQuery<BrightcoveItemCollection<BrightcoveAudioTrackPlaylist>>(parms);
		}

		/// <summary>
		/// Retrieve multiple audio track playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <param name="audioTrackFields">A list of the fields you wish to have populated in the audio tracks contained in the playlists.</param>
		/// <returns>The specified playlists, in the order of the reference ids you passed in.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAudioTrackPlaylistsByReferenceIds(IEnumerable<string> referenceIds,
			IEnumerable<string> audioTrackFields)
		{
			return FindAudioTrackPlaylistsByReferenceIds(referenceIds, audioTrackFields, null);
		}

		/// <summary>
		/// Retrieve multiple audio track playlists based on their publisher-assigned reference ids.
		/// </summary>
		/// <param name="referenceIds">The reference ids of the playlists we'd like to retrieve.</param>
		/// <returns>The specified playlists, in the order of the reference ids you passed in.</returns>
		public BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> FindAudioTrackPlaylistsByReferenceIds(IEnumerable<string> referenceIds)
		{
			return FindAudioTrackPlaylistsByReferenceIds(referenceIds, null);
		}

		#endregion
	}
}
