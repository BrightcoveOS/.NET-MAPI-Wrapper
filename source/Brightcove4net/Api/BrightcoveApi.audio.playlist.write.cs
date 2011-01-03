using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brightcove4net.Model;
using Brightcove4net.Model.Containers;
using Brightcove4net.Model.Items;

namespace Brightcove4net.Api
{
	public partial class BrightcoveApi
	{
		/// <summary>
		/// Creates a playlist
		/// </summary>
		/// <param name="playlist">The playlist you'd like to create.</param>
		/// <returns>The ID of the newly created playlist.</returns>
		public long CreateAudioTrackPlaylist(BrightcoveAudioTrackPlaylist playlist)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("create_audiotrack_playlist",
																		 methodParams => methodParams.Add("audiotrack_playlist", playlist));
			return RunPost<BrightcoveResultContainer<long>>(parms).Result;
		}

		/// <summary>
		/// Creates a playlist
		/// </summary>
		/// <param name="playlist">The playlist you'd like to update.</param>
		/// <returns>The updated playlist.</returns>
		public BrightcoveAudioTrackPlaylist UpdateAudioTrackPlaylist(BrightcoveAudioTrackPlaylist playlist)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("update_audiotrack_playlist",
																		 methodParams => methodParams.Add("audiotrack_playlist", playlist));
			return RunPost<BrightcoveResultContainer<BrightcoveAudioTrackPlaylist>>(parms).Result;
		}
	}
}
