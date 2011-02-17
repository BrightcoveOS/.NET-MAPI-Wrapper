namespace BrightcoveMapiWrapper.Model
{
	/// <summary>
	/// The possible sort orders for API read requests
	/// </summary>
	public enum SortOrder
	{
		None = 0,
		Ascending,
		Descending
	}

	/// <summary>
	/// The possible ways to sort results from an API read request
	/// </summary>
	public enum SortBy
	{
		None = 0,
		CreationDate,
		ModifiedDate,
		PublishDate,
		PlaysTotal,
		PlaysTrailingWeek
	}

	/// <summary>
	/// The possible upload statuses returned from brightcove
	/// 
	/// Complete: Video upload and processing have completed
	/// Processing: Video is being processed after upload for transcoding
	/// Uploading: Video is still in the process of being uploaded
	/// Error: Indicates an error during upload or processing
	/// </summary>
	public enum BrightcoveUploadStatus
	{
		None = 0,
		Complete,
		Error,
		Processing,
		Uploading 
	}

	/// <summary>
	/// The filters available for the FindModifiedVideos call
	/// </summary>
	public enum ModifiedVideoFilter
	{
		None = 0,
		Playable, 
		Unscheduled, 
		Inactive,
		Deleted
	}

	/// <summary>
	/// Playlist types.
	/// 
	/// Explicit: A manual playlist, the videos of which were added individually.
	/// OldestToNewest: A smart playlist, ordered from oldest to newest, by published date.
	/// NewestToOldest: A smart playlist, ordered from newest to oldest, by published date.
	///	Alphabetical: A smart playlist, ordered alphabetically.
	/// PlaysTotal: A smart playlist, ordered by total plays.
	///	PlaysTrailingWeek: A smart playlist, ordered by most plays in the past week.
	/// StartDateOldestToNewest: A smart playlist, ordered from oldest to newest, by start date.
	///	StartDateNewestToOldest: A smart playlist, ordered from newest to oldest, by start date.
	/// </summary>
	public enum PlaylistType
	{
		None = 0,
		Explicit,
		OldestToNewest,
		NewestToOldest,
		Alphabetical,
		PlaysTotal,
		PlaysTrailingWeek,
		StartDateOldestToNewest,
		StartDateNewestToOldest
	}

	/// <summary>
	/// Video codecs
	/// </summary>
	public enum VideoCodec
	{
		None = 0,
		Sorenson,
		On2,
		H264
	}

	/// <summary>
	/// The types required for live streaming renditions
	/// </summary>
	public enum ControllerType
	{
		None = 0,
		LimelightLive,
		AkamaiLive,
		Default
	}

	/// <summary>
	/// Tag inclusion rules for smart playlists
	/// </summary>
	public enum TagInclusionRule
	{
		None = 0,
		And,
		Or
	}

	/// <summary>
	/// The possible states for a media item
	/// </summary>
	public enum ItemState
	{
		None = 0,
		Active,
		Inactive,
		Deleted
	}

	/// <summary>
	/// The possible "economics" of media items; that is,
	/// whether they are free or supported by ads.
	/// </summary>
	public enum Economics
	{
		None = 0,
		Free,
		AdSupported
	}

	/// <summary>
	/// The possible encodings for newly created videos
	/// </summary>
	public enum EncodeTo
	{
		None = 0,
		Flv,
		Mp4
	}

	/// <summary>
	/// Types of cue points
	/// </summary>
	public enum CuePointType
	{
		None = 0,
		Ad,
		Code
	}

	/// <summary>
	/// The possible image types
	/// </summary>
	public enum ImageType
	{
		None = 0,
		Thumbnail,
		VideoStill,
		LogoOverlay
	}

	/// <summary>
	/// Alignments for the logo overlay
	/// </summary>
	public enum LogoOverlayAlignment
	{
		None = 0,
		TopLeft,
		BottomLeft,
		TopRight,
		BottomRight
	}

}
