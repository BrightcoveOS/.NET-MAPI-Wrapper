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
	/// The valid values of the output argument for the read methods.
	/// </summary>
	public enum Output
	{
		/// <summary>
		/// Default.
		/// </summary>
		Json,
		/// <summary>
		/// RSS with Media RSS and Video Cloud extensions.
		/// </summary>
		Mrss,
		/// <summary>
		/// For distribution through TubeMogul OneLoad.
		/// </summary>
		Tm
	}

	/// <summary>
	/// Specify the region for setting the general service URL.
	/// </summary>
	public enum BrightcoveRegion
	{
		/// <summary>
		/// Any unspecified region. Mapped to the .com generic top-level domain.
		/// </summary>
		Generic = 0,
		/// <summary>
		/// Japan. Mapped to the .co.jp country code top-level domain.
		/// </summary>
		Japan
	}
}