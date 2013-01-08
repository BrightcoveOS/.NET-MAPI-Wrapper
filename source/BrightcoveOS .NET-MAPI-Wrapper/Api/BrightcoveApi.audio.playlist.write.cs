using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveMapiWrapper.Api
{
	public partial class BrightcoveApi
	{
		

		#region CreateAudioTrackPlaylist
		/// <summary>
		/// Creates a playlist.
		/// </summary>
		/// <param name="playlist">The playlist you'd like to create.</param>
		/// <returns>The ID of the newly created playlist.</returns>
		public long CreateAudioTrackPlaylist(BrightcoveAudioTrackPlaylist playlist)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("create_audiotrack_playlist",
																		 methodParams => methodParams.Add("audiotrack_playlist", playlist));
			return RunPost<BrightcoveResultContainer<long>>(parms).Result;
		}
		#endregion

		#region UpdateAudioTrackPlaylist
		/// <summary>
		/// Updates a playlist.
		/// </summary>
		/// <param name="playlist">The playlist you'd like to update.</param>
		/// <returns>The updated playlist.</returns>
		public BrightcoveAudioTrackPlaylist UpdateAudioTrackPlaylist(BrightcoveAudioTrackPlaylist playlist)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("update_audiotrack_playlist",
																		 methodParams => methodParams.Add("audiotrack_playlist", playlist));
			return RunPost<BrightcoveResultContainer<BrightcoveAudioTrackPlaylist>>(parms).Result;
		}
		#endregion

		#region DeleteAudioTrackPlaylist
		/// <summary>
		/// Deletes a playlist, specified by playlist ID
		/// </summary>
		/// <param name="playlistId">The ID of the playlist you'd like to delete</param>
		/// <param name="cascade">If true, playlist will be deleted even if it is referenced by players. The playlist will 
		/// be removed from all players in which it appears, then deleted.</param>
		public void DeleteAudioTrackPlaylist(long playlistId, bool cascade)
		{
			DoDeleteAudioTrackPlaylist(playlistId, null, cascade);
		}

		/// <summary>
		/// Deletes a playlist, specified by the playlist's Reference ID
		/// </summary>
		/// <param name="referenceId">The Reference ID of the playlist you'd like to delete</param>
		/// <param name="cascade">If true, playlist will be deleted even if it is referenced by players. The playlist will 
		/// be removed from all players in which it appears, then deleted.</param>
		public void DeleteAudioTrackPlaylist(string referenceId, bool cascade)
		{
			DoDeleteAudioTrackPlaylist(-1, referenceId, cascade);
		}

		/// <summary>
		/// Deletes the playlist whether you're using a numeric Id or a string reference Id.
		/// </summary>
		/// <param name="playlistId">The ID for the playlist to delete. Either a playlist ID or a reference ID must be supplied.</param>
		/// <param name="referenceId">The publisher-assigned reference ID of the playlist you want to delete. Either a playlist ID or a reference ID must be supplied.</param>
		/// <param name="cascade">Set this to true if you want to delete this playlist even if it is referenced by players. The playlist will be removed from all players in which it appears, then deleted.</param>
		private void DoDeleteAudioTrackPlaylist(long playlistId, string referenceId, bool cascade)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(playlistId, referenceId, "playlist_id", "reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("delete_audiotrack_playlist",
																		 methodParams =>
																		 {
																			 methodParams.Add(propName, propValue);
																			 methodParams.Add("cascade", cascade.ToString().ToLower());
																		 });

			RunPost<BrightcoveResultContainer<long>>(parms);
		}
		#endregion
	}
}
