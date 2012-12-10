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
