using System;
namespace BrightcoveMapiWrapper.Model
{
	/// <summary>
	/// The possible sort orders for API read requests
	/// </summary>
	public enum SortOrder
	{
		/// <summary>
		/// No option specified. Will throw an exception when converting to a string parameter.
		/// </summary>
		None = 0,
		/// <summary>
		/// Sort the items in ascending order.
		/// </summary>
		Ascending,
		/// <summary>
		/// Sort the items in descending order.
		/// </summary>
		Descending
	}

	/// <summary>
	/// The possible ways to sort results from an API read request
	/// </summary>
	public enum SortBy
	{
		/// <summary>
		/// No option specified. Will throw an exception when converting to a string parameter.
		/// </summary>
		None = 0,
		/// <summary>
		/// Date title was created.
		/// </summary>
		CreationDate,
		/// <summary>
		/// Date title was last modified.
		/// </summary>
		ModifiedDate,
		/// <summary>
		/// Date title was published.
		/// </summary>
		PublishDate,
		/// <summary>
		/// Date title is scheduled to be available. Video only.
		/// </summary>
		StartDate,
		/// <summary>
		/// Number of times this title has been viewed.
		/// </summary>
		PlaysTotal,
		/// <summary>
		/// Number of times this title has been viewed in the past 7 days (excluding today).
		/// </summary>
		PlaysTrailingWeek,
		/// <summary>
		/// Name of the title. Video only.
		/// </summary>
		DisplayName,
		/// <summary>
		/// Reference ID of the title.
		/// </summary>
		ReferenceId
	}


	/// <summary>
	/// The possible upload statuses returned from Brightcove.
	/// 
	/// Complete: Video upload and processing have completed.
	/// Processing: Video is being processed after upload for transcoding.
	/// Uploading: Video is still in the process of being uploaded.
	/// Error: Indicates an error during upload or processing.
	/// </summary>
	public enum BrightcoveUploadStatus
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Video upload and processing have completed.
		/// </summary>
		Complete,
		/// <summary>
		/// Indicates an error during upload or processing.
		/// </summary>
		Error,
		/// <summary>
		/// Video is being processed after upload for transcoding.
		/// </summary>
		Processing,
		/// <summary>
		/// Video is still in the process of being uploaded.
		/// </summary>
		Uploading 
	}

	/// <summary>
	/// The filters available for the FindModifiedVideos call
	/// </summary>
	public enum ModifiedVideoFilter
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// The video is playable.
		/// </summary>
		Playable, 
		/// <summary>
		/// The video is unscheduled.
		/// </summary>
		Unscheduled, 
		/// <summary>
		/// The video is inactive.
		/// </summary>
		Inactive,
		/// <summary>
		/// The video is deleted.
		/// </summary>
		Deleted
	}

	/// <summary>
	/// Playlist types.
	/// </summary>
	public enum PlaylistType
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// A manual playlist, the videos of which were added individually.
		/// </summary>
		Explicit,
		/// <summary>
		/// A smart playlist, ordered from oldest to newest, by published date.
		/// </summary>
		OldestToNewest,
		/// <summary>
		/// A smart playlist, ordered from newest to oldest, by published date.
		/// </summary>
		NewestToOldest,
		/// <summary>
		/// A smart playlist, ordered alphabetically.
		/// </summary>
		Alphabetical,
		/// <summary>
		/// A smart playlist, ordered by total plays.
		/// </summary>
		PlaysTotal,
		/// <summary>
		/// A smart playlist, ordered by most plays in the past week.
		/// </summary>
		PlaysTrailingWeek,
		/// <summary>
		/// A smart playlist, ordered from oldest to newest, by start date.
		/// </summary>
		StartDateOldestToNewest,
		/// <summary>
		/// A smart playlist, ordered from newest to oldest, by start date.
		/// </summary>
		StartDateNewestToOldest
	}

	/// <summary>
	/// Video codecs
	/// </summary>
	public enum VideoCodec
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Uses the Sorenson codec.
		/// </summary>
		Sorenson,
		/// <summary>
		/// Uses the On2 codec.
		/// </summary>
		On2,
		/// <summary>
		/// Uses the H264 codec.
		/// </summary>
		H264
	}

	/// <summary>
	/// The types required for live streaming renditions
	/// </summary>
	public enum ControllerType
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Uses the Limelight Live controller.
		/// </summary>
		LimelightLive,
		/// <summary>
		/// Uses the Akamai Live controller.
		/// </summary>
		AkamaiLive,
		/// <summary>
		/// Uses the default controller.
		/// </summary>
		Default
	}

	/// <summary>
	/// Tag inclusion rules for smart playlists. Not available in Read API methods.
	/// </summary>
	public enum TagInclusionRule
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Contains all.
		/// </summary>
		And,
		/// <summary>
		/// Contains one or more.
		/// </summary>
		Or
	}

	/// <summary>
	/// The possible states for a media item
	/// </summary>
	public enum ItemState
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Whether the item is active.
		/// </summary>
		Active,
		/// <summary>
		/// Whether the item is inactive.
		/// </summary>
		Inactive,
		/// <summary>
		/// Whether the item is deleted.
		/// </summary>
		Deleted
	}

	/// <summary>
	/// The possible "economics" of media items; that is,
	/// whether they are free or supported by ads.
	/// </summary>
	public enum Economics
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Free item.
		/// </summary>
		Free,
		/// <summary>
		/// Item is supported by ads.
		/// </summary>
		AdSupported
	}

	/// <summary>
	/// The possible encodings for newly created videos
	/// </summary>
	public enum EncodeTo
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Encode to the .flv file format.
		/// </summary>
		Flv,
		/// <summary>
		/// Encode to the .mp4 file format.
		/// </summary>
		Mp4
	}

	/// <summary>
	/// Types of cue points.
	/// </summary>
	public enum CuePointType
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Used to trigger mid-roll ad requests.
		/// </summary>
		Ad,
		/// <summary>
		/// Can be used to indicate a chapter or scene break in the video.
		/// </summary>
		Code
	}

	/// <summary>
	/// The possible image types
	/// </summary>
	public enum ImageType
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Associated as a thumbnail.
		/// </summary>
		Thumbnail,
		/// <summary>
		/// Associated as a video still.
		/// </summary>
		VideoStill,
		/// <summary>
		/// Associated as a logo overlay.
		/// </summary>
		LogoOverlay
	}

	/// <summary>
	/// Alignments for the logo overlay
	/// </summary>
	public enum LogoOverlayAlignment
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Align to the top left of the video display.
		/// </summary>
		TopLeft,
		/// <summary>
		/// Align to the bottom left of the video display.
		/// </summary>
		BottomLeft,
		/// <summary>
		/// Align to the top right of the video display.
		/// </summary>
		TopRight,
		/// <summary>
		/// Align to the bottom right of the video display.
		/// </summary>
		BottomRight
	}

	/// <summary>
	/// Specify the region for setting the general service URL.
	/// </summary>
	public enum BrightcoveRegion
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Any unspecified region. Mapped to the .com generic top-level domain.
		/// </summary>
		Generic,
		/// <summary>
		/// Japan. Mapped to the .co.jp country code top-level domain.
		/// </summary>
		Japan
	}

	/// <summary>
	/// The read methods supported by Brightcove. Available method descriptions are taken from <a href="http://docs.brightcove.com/en/media/">Brightcove Video Cloud Media API Reference</a>.
	/// </summary>
	public enum BrightcoveReadMethod
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None = 0,
		/// <summary>
		/// Any unspecified region. Mapped to the .com generic top-level domain.
		/// </summary>
		Generic,
		/// <summary>
		/// Find all audio track playlists in this account.
		/// </summary>
		FindAllAudiotrackPlaylists,
		/// <summary>
		/// Finds a particular audio track playlist based on its id.
		/// </summary>
		FindAudiotrackPlaylistById,
		/// <summary>
		/// Retrieve an audio track playlist based on its publisher-assigned reference id.
		/// </summary>
		FindAudiotrackPlaylistByReferenceId,
		/// <summary>
		/// Retrieve a set of audio track playlists based on their ids.
		/// </summary>
		FindAudiotrackPlaylistsByIds,
		/// <summary>
		/// Retrieve multiple audio track playlists based on their publisher-assigned reference ids.
		/// </summary>
		FindAudiotrackPlaylistsByReferenceIds,
		/// <summary>
		/// Find all audio tracks in the Brightcove media library for this account.
		/// </summary>
		FindAllAudiotracks,
		/// <summary>
		/// Finds a single audio track with the specified id.
		/// </summary>
		FindAudiotrackById,
		/// <summary>
		/// Find an audio track based on its publisher-assigned reference id.
		/// </summary>
		FindAudiotrackByReferenceId,
		/// <summary>
		/// Find multiple audio tracks, given their ids.
		/// </summary>
		FindAudiotracksByIds,
		/// <summary>
		/// Find multiple audio tracks based on their publisher-assigned reference ids.
		/// </summary>
		FindAudiotracksByReferenceIds,
		/// <summary>
		/// Performs a search on all the tags of the audio tracks in this account, and returns a collection of audio tracks that contain the specified tags. Note that tags are case-sensitive.
		/// </summary>
		FindAudiotracksByTags,
		/// <summary>
		/// Searches through all the audio tracks in this account, and returns a collection of audio tracks whose name, short description, or long description contain a match for the specified text.
		/// </summary>
		FindAudiotracksByText,
		/// <summary>
		/// Gets all the audio tracks that have been modified since the given time.
		/// </summary>
		FindModifiedAudiotracks,
		/// <summary>
		/// Find all playlists in this account.
		/// </summary>
		FindAllPlaylists,
		/// <summary>
		/// Finds a particular playlist based on its ID.
		/// </summary>
		FindPlaylistById,
		/// <summary>
		/// Retrieve a set of playlists based on their IDs.
		/// </summary>
		FindPlaylistsByIds,
		/// <summary>
		/// Retrieve a playlist based on its publisher-assigned reference ID.
		/// </summary>
		FindPlaylistByReferenceId,
		/// <summary>
		/// Retrieve multiple playlists based on their publisher-assigned reference IDs.
		/// </summary>
		FindPlaylistsByReferenceIds,
		/// <summary>
		/// Given the ID of a player, returns all the playlists assigned to that player.
		/// </summary>
		FindPlaylistsForPlayerId,
		/// <summary>
		/// Finds a single video with the specified ID.
		/// </summary>
		FindVideoById,
		/// <summary>
		/// Find multiple videos, given their IDs.
		/// </summary>
		FindVideosByIds,
		/// <summary>
		/// Find a video based on its publisher-assigned reference ID.
		/// </summary>
		FindVideoByReferenceId,
		/// <summary>
		/// Find multiple videos based on their publisher-assigned reference IDs.
		/// </summary>
		FindVideosByReferenceIds,
		/// <summary>
		/// Find all videos in the Video Cloud media library for this account. This method has the limitation of returning only videos available for play, and does not include videos marked as inactive, currently in the upload process, or outside the scheduled play time.
		/// </summary>
		FindAllVideos,
		/// <summary>
		/// Searches videos according to the criteria provided by the user. The criteria are constructed using field/value pairs specified in the command. Consider using the search_videos method for video searches rather than using the other find_video read methods. The search_videos method offers more flexible search and sorting options than the find_video methods, and is especially more flexible than the find_videos_by_text and find_videos_by_tags methods.
		/// </summary>
		SearchVideos,
		/// <summary>
		/// Finds videos related to the given video. Combines the name and short description of the given video and searches for any partial matches in the name, short description, long description, tags, and custom fields of all videos in the Video Cloud media library for this account. More precise ways of finding related videos include tagging your videos by subject and using the find_videos_by_tags method to find videos that share the same tags: or creating a playlist that includes videos that you know are related. Consider using the search_videos method, which offers more flexible search and sorting options.
		/// </summary>
		FindRelatedVideos,
		/// <summary>
		/// Retrieves the videos uploaded by the specified user id. This method can be used to find videos submitted using the old consumer-generated media (CGM) module in Brightcove 2.
		/// </summary>
		[Obsolete("Deprecated. Read about approaches to user-generated content at http://support.brightcove.com/en/video-cloud/docs/user-generated-content.")]
		FindVideosByUserId,
		/// <summary>
		/// Gets all the videos associated with the given campaign ID. Campaigns are a feature of the old consumer-generated media (CGM) module in Brightcove 2.
		/// </summary>
		[Obsolete("Deprecated. Read about approaches to user-generated content at http://support.brightcove.com/en/video-cloud/docs/user-generated-content.")]
		FindVideosByCampaignId,
		/// <summary>
		/// Gets all the videos that have been modified since the given time.
		/// </summary>
		FindModifiedVideos,
		/// <summary>
		/// Searches through all the videos in this account, and returns a collection of videos whose name, short description, or long description contain a match for the specified text. Unlike some other Read methods, this method does not provide parameters for sorting the result set. The result set is sorted by relevance. The find_videos_by_text method returns substring matches - words from your search string plus a wildcard (*) at the end; thus, if your search string is "war", the result set will include results such as "warrior", "warfare", and "warbler." Substrings that don't match the beginning of a word are not returned; thus, if your search string is "war", the result set would not include results such as "swarthy" or "inward".
		/// </summary>
		[Obsolete("Deprecated. Consider using the search_videos method, which offers more flexible search and sorting options.")]
		FindVideosByText,
		/// <summary>
		/// Performs a search on all the tags of the videos in this account, and returns a collection of videos that contain the specified tags. Note that tags are not case-sensitive. This method does not provide parameters for sorting the result set. 
		/// </summary>
		FindVideosByTags,
		/// <summary>
		/// Finds a single video with the specified ID. Unlike find_video_by_id, this unfiltered version also returns videos that are unscheduled, inactive, or deleted.
		/// </summary>
		FindVideoByIdUnfiltered,
		/// <summary>
		/// Find multiple videos, given their IDs. Unlike find_videos_by_ids, this unfiltered version also returns videos that are unscheduled, inactive, or deleted.
		/// </summary>
		FindVideosByIdsUnfiltered,
		/// <summary>
		/// Find a video based on its publisher-assigned reference ID. Unlike find_video_by_reference_id, this unfiltered version also returns videos that are unscheduled, inactive, or deleted.
		/// </summary>
		FindVideoByReferenceIdUnfiltered,
		/// <summary>
		/// Find multiple videos based on their publisher-assigned reference IDs. Unlike find_videos_by_reference_ids, this unfiltered version also returns videos that are unscheduled, inactive, or deleted.
		/// </summary>
		FindVideosByReferenceIdsUnfiltered
	}

	/// <summary>
	/// The write methods supported by Brightcove. Available method descriptions are taken from <a href="http://docs.brightcove.com/en/media/">Brightcove Video Cloud Media API Reference</a>.
	/// </summary>
	public enum BrightcoveWriteMethod
	{
		/// <summary>
		/// No option specified.
		/// </summary>
		None,
		/// <summary>
		/// Creates a playlist.
		/// </summary>
		CreateAudiotrackPlaylist,
		/// <summary>
		/// Updates a playlist.
		/// </summary>
		UpdateAudiotrackPlaylist,
		/// <summary>
		/// Deletes a playlist, specified by playlist ID or reference ID.
		/// </summary>
		DeleteAudiotrackPlaylist,
		/// <summary>
		/// Creates a new audio track in Brightcove by uploading a file.
		/// </summary>
		CreateAudiotrack,
		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		AddAudioImage,
		/// <summary>
		/// Updates the audio track information for a Brightcove audio track.
		/// </summary>
		UpdateAudiotrack,
		/// <summary>
		/// Deletes an audio track.
		/// </summary>
		DeleteAudiotrack,
		/// <summary>
		/// Gets the audiotrack upload status. 
		/// </summary>
		GetAudiotrackUploadStatus,
		/// <summary>
		/// Creates a playlist. This method must be called using an HTTP POST request and JSON parameters. If the playlistType property in the Playlist object you submit is explicit, that means it's a manual playlist. If the playlistType property is not explicit, that means it's a smart playlist.
		/// </summary>
		CreatePlaylist,
		/// <summary>
		/// Updates a playlist, specified by playlist ID or reference ID. Either a playlist ID or a reference ID must be supplied. If you are updating the value of the reference ID, then both the playlist ID and reference ID must be supplied. This method must be called using an HTTP POST request and JSON parameters.
		/// </summary>
		UpdatePlaylist,
		/// <summary>
		/// Deletes a playlist, specified by playlist ID or reference ID.
		/// </summary>
		DeletePlaylist,
		/// <summary>
		/// Use this method to create a single video in your Video Cloud Media Library. You can either upload a new video file, or use the remote assets approach, in which you pass a reference to a video file on your own CDN.
		/// </summary>
		CreateVideo,
		/// <summary>
		/// Use this method to modify the metadata for a single video in your Video Cloud Media Library.
		/// </summary>
		UpdateVideo,
		/// <summary>
		/// Deletes a video.
		/// </summary>
		DeleteVideo,
		/// <summary>
		/// Call this function in an HTTP POST request to determine the status of an upload. Note that there is a brief delay from the moment you submit a create_video method call and the moment the transaction for that method call is complete. During that interval, a get_upload_status method call will return an error message saying, "Illegal value - Cannot find any video", because the video has not yet been assigned an ID and begun uploading.
		/// </summary>
		GetUploadStatus,
		/// <summary>
		/// Shares the specified video with a list of sharee accounts.
		/// </summary>
		ShareVideo,
		/// <summary>
		/// Deletes the specified previously shared video from a list of sharee accounts. If a shared version of the specified video does not exist in a sharee account, no action is taken.
		/// </summary>
		UnshareVideo,
		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		AddImage,
		/// <summary>
		/// Add a logo overlay image to a video.
		/// </summary>
		AddLogoOverlay,
		/// <summary>
		/// Removes a logo overlay previously assigned to a video.
		/// </summary>
		RemoveLogoOverlay,
		/// <summary>
		/// Assigns Captioning to a video via uploading a caption file or providing URL of caption file. Deletes any Captioning previously assigned to a video.
		/// </summary>
		AddCaptioning,
		/// <summary>
		/// Assigns Captioning to a video via uploading a caption file or providing URL of caption file. Deletes any Captioning previously assigned to a video.
		/// </summary>
		DeleteCaptioning
	}
}