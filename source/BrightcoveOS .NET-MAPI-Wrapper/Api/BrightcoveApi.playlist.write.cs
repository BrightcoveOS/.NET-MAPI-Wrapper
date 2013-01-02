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
		///// <summary>
		///// Creates a playlist
		///// </summary>
		///// <param name="playlist">The playlist you'd like to create.</param>
		///// <returns>The ID of the newly created playlist.</returns>
		//public long CreatePlaylist(BrightcovePlaylist playlist)
		//{
		//    BrightcoveParamCollection parms = CreateWriteParamCollection("create_playlist",
		//                                                                 methodParams => methodParams.Add("playlist", playlist));
		//    return RunPost<BrightcoveResultContainer<long>>(parms).Result;
		//}

		///// <summary>
		///// Updates a playlist, specified by playlist ID or reference ID. Either a playlist ID or a reference ID must be 
		///// supplied. If you are updating the value of the reference ID, then both the playlist ID and reference ID must be supplied.
		///// </summary>
		///// <param name="playlist">The playlist you'd like to update.</param>
		///// <returns>The playlist that was updated</returns>
		//public BrightcovePlaylist UpdatePlaylist(BrightcovePlaylist playlist)
		//{
		//    BrightcoveParamCollection parms = CreateWriteParamCollection("update_playlist",
		//                                                                 methodParams => methodParams.Add("playlist", playlist));
		//    return RunPost<BrightcoveResultContainer<BrightcovePlaylist>>(parms).Result;
		//}

		/// <summary>
		/// Creates a playlist
		/// </summary>
		/// <param name="playlist">The playlist you'd like to create.</param>
		/// <returns>The ID of the newly created playlist.</returns>
		public long CreatePlaylist(BrightcovePlaylist playlist)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.CreatePlaylist,
																		 methodParams => methodParams.Add("playlist", playlist));
			return RunPost<BrightcoveResultContainer<long>>(parms).Result;
		}

		/// <summary>
		/// Updates a playlist, specified by playlist ID or reference ID. Either a playlist ID or a reference ID must be 
		/// supplied. If you are updating the value of the reference ID, then both the playlist ID and reference ID must be supplied.
		/// </summary>
		/// <param name="playlist">The playlist you'd like to update.</param>
		/// <returns>The playlist that was updated</returns>
		public BrightcovePlaylist UpdatePlaylist(BrightcovePlaylist playlist)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.UpdatePlaylist,
																		 methodParams => methodParams.Add("playlist", playlist));
			return RunPost<BrightcoveResultContainer<BrightcovePlaylist>>(parms).Result;
		}

		/// <summary>
		/// Deletes a playlist, specified by playlist ID
		/// </summary>
		/// <param name="playlistId">The ID of the playlist you'd like to delete</param>
		/// <param name="cascade">If true, playlist will be deleted even if it is referenced by players. The playlist will 
		/// be removed from all players in which it appears, then deleted.</param>
		public void DeletePlaylist(long playlistId, bool cascade)
		{
			DoDeletePlaylist(playlistId, null, cascade);
		}

		/// <summary>
		/// Deletes a playlist, specified by the playlist's Reference ID
		/// </summary>
		/// <param name="referenceId">The Reference ID of the playlist you'd like to delete</param>
		/// <param name="cascade">If true, playlist will be deleted even if it is referenced by players. The playlist will 
		/// be removed from all players in which it appears, then deleted.</param>
		public void DeletePlaylist(string referenceId, bool cascade)
		{
			DoDeletePlaylist(-1, referenceId, cascade);
		}

		//private void DoDeletePlaylist(long playlistId, string referenceId, bool cascade)
		//{
		//    string propName;
		//    object propValue;
		//    GetIdValuesForUpload(playlistId, referenceId, "playlist_id", "reference_id", out propName, out propValue);

		//    BrightcoveParamCollection parms = CreateWriteParamCollection("delete_playlist",
		//                                                                 methodParams =>
		//                                                                 {
		//                                                                     methodParams.Add(propName, propValue);
		//                                                                     methodParams.Add("cascade", cascade.ToString().ToLower());
		//                                                                 });

		//    RunPost<BrightcoveResultContainer<long>>(parms);
		//}

		private void DoDeletePlaylist(long playlistId, string referenceId, bool cascade)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(playlistId, referenceId, "playlist_id", "reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.DeletePlaylist,
																		 methodParams =>
																		 {
																			 methodParams.Add(propName, propValue);
																			 methodParams.Add("cascade", cascade.ToString().ToLower());
																		 });

			RunPost<BrightcoveResultContainer<long>>(parms);
		}
	}
}
