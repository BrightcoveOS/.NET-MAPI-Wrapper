using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api.Connectors;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveMapiWrapper.Api
{
	public partial class BrightcoveApi
	{
		#region CreateVideo

		/// <summary>
		/// Creates a new video by uploading a file.
		/// </summary>
		/// <param name="video">The metadata for the video you want to create.</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="encodeTo">If the file requires transcoding, use this parameter to specify the target encoding. 
		/// Valid values are MP4 or FLV, representing the H264 and VP6 codecs respectively. Note that transcoding of 
		/// FLV files to another codec is not currently supported. This parameter is optional and defaults to FLV.</param>
		/// <param name="createMultipleRenditions">If the file is a supported transcodeable type, this optional flag can be 
		/// used to control the number of transcoded renditions. If true (default), multiple renditions at varying encoding 
		/// rates and dimensions are created. Setting this to false will cause a single transcoded VP6 rendition to be created 
		/// at the standard encoding rate and dimensions.</param>
		/// <param name="preserveSourceRendition">If the video file is H.264 encoded and if createMultipleRenditions is true, 
		/// then multiple VP6 renditions are created and in addition the H.264 source is retained as an additional rendition.</param>
		/// <param name="h264NoProcessing">Use this option to prevent H.264 source files from being transcoded. This parameter cannot
		/// be used in combination with create_multiple_renditions. It is optional and defaults to false.</param>
		/// <returns>The numeric ID of the newly created video.</returns>
		public long CreateVideo(BrightcoveVideo video, FileUploadInfo fileUploadInfo, EncodeTo encodeTo, bool createMultipleRenditions, bool preserveSourceRendition, bool h264NoProcessing)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("create_video",
																		 methodParams =>
																		 {
																			 methodParams.Add("video", video);
																			 if (encodeTo != EncodeTo.None)
																			 {
																				 methodParams.Add("encode_to", encodeTo.ToString().ToUpper());
																			 }
																			 methodParams.Add("create_multiple_renditions", createMultipleRenditions.ToString().ToLower());
																			 methodParams.Add("preserve_source_rendition", preserveSourceRendition.ToString().ToLower());
																			 methodParams.Add("H264NoProcessing ", h264NoProcessing.ToString().ToLower());
																		 });
			return RunFilePost<BrightcoveResultContainer<long>>(parms, fileUploadInfo).Result;
		}

		/// <summary>
		/// Creates a new video by uploading a file.
		/// </summary>
		/// <param name="video">The metadata for the video you want to create.</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <param name="encodeTo">If the file requires transcoding, use this parameter to specify the target encoding. 
		/// Valid values are MP4 or FLV, representing the H264 and VP6 codecs respectively. Note that transcoding of 
		/// FLV files to another codec is not currently supported. This parameter is optional and defaults to FLV.</param>
		/// <param name="createMultipleRenditions">If the file is a supported transcodeable type, this optional flag can be 
		/// used to control the number of transcoded renditions. If true (default), multiple renditions at varying encoding 
		/// rates and dimensions are created. Setting this to false will cause a single transcoded VP6 rendition to be created 
		/// at the standard encoding rate and dimensions.</param>
		/// <param name="preserveSourceRendition">If the video file is H.264 encoded and if createMultipleRenditions is true, 
		/// then multiple VP6 renditions are created and in addition the H.264 source is retained as an additional rendition.</param>
		/// <param name="h264NoProcessing">Use this option to prevent H.264 source files from being transcoded. This parameter cannot
		/// be used in combination with create_multiple_renditions. It is optional and defaults to false.</param>
		/// <returns>The numeric ID of the newly created video.</returns>
		public long CreateVideo(BrightcoveVideo video, string fileToUpload, EncodeTo encodeTo, bool createMultipleRenditions, bool preserveSourceRendition, bool h264NoProcessing)
		{
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return CreateVideo(video, new FileUploadInfo(fs, fileName), encodeTo, createMultipleRenditions, preserveSourceRendition,
			                   h264NoProcessing);
			}
		}

		/// <summary>
		/// Creates a new video by uploading a file.
		/// </summary>
		/// <param name="video">The metadata for the video you want to create.</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <param name="encodeTo">If the file requires transcoding, use this parameter to specify the target encoding. 
		/// Valid values are MP4 or FLV, representing the H264 and VP6 codecs respectively. Note that transcoding of 
		/// FLV files to another codec is not currently supported. This parameter is optional and defaults to FLV.</param>
		/// <param name="createMultipleRenditions">If the file is a supported transcodeable type, this optional flag can be 
		/// used to control the number of transcoded renditions. If true (default), multiple renditions at varying encoding 
		/// rates and dimensions are created. Setting this to false will cause a single transcoded VP6 rendition to be created 
		/// at the standard encoding rate and dimensions.</param>
		/// <param name="preserveSourceRendition">If the video file is H.264 encoded and if createMultipleRenditions is true, 
		/// then multiple VP6 renditions are created and in addition the H.264 source is retained as an additional rendition.</param>
		/// <returns>The numeric ID of the newly created video.</returns>
		public long CreateVideo(BrightcoveVideo video, string fileToUpload, EncodeTo encodeTo, bool createMultipleRenditions, bool preserveSourceRendition)
		{
			return CreateVideo(video, fileToUpload, encodeTo, createMultipleRenditions, preserveSourceRendition, false);
		}

		/// <summary>
		/// Creates a new video by uploading a file.
		/// </summary>
		/// <param name="video">The metadata for the video you want to create.</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <param name="encodeTo">If the file requires transcoding, use this parameter to specify the target encoding. 
		/// Valid values are MP4 or FLV, representing the H264 and VP6 codecs respectively. Note that transcoding of 
		/// FLV files to another codec is not currently supported. This parameter is optional and defaults to FLV.</param>
		/// <param name="createMultipleRenditions">If the file is a supported transcodeable type, this optional flag can be 
		/// used to control the number of transcoded renditions. If true (default), multiple renditions at varying encoding 
		/// rates and dimensions are created. Setting this to false will cause a single transcoded VP6 rendition to be created 
		/// at the standard encoding rate and dimensions.</param>
		/// <returns>The numeric ID of the newly created video.</returns>
		public long CreateVideo(BrightcoveVideo video, string fileToUpload, EncodeTo encodeTo, bool createMultipleRenditions)
		{
			return CreateVideo(video, fileToUpload, encodeTo, createMultipleRenditions, false);
		}

		/// <summary>
		/// Creates a new video by uploading a file.
		/// </summary>
		/// <param name="video">The metadata for the video you want to create.</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <param name="encodeTo">If the file requires transcoding, use this parameter to specify the target encoding. 
		/// Valid values are MP4 or FLV, representing the H264 and VP6 codecs respectively. Note that transcoding of 
		/// FLV files to another codec is not currently supported. This parameter is optional and defaults to FLV.</param>
		/// <returns>The numeric ID of the newly created video.</returns>
		public long CreateVideo(BrightcoveVideo video, string fileToUpload, EncodeTo encodeTo)
		{
			return CreateVideo(video, fileToUpload, encodeTo, true);
		}

		/// <summary>
		/// Creates a new video by uploading a file.
		/// </summary>
		/// <param name="video">The metadata for the video you want to create.</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <returns>The numeric ID of the newly created video.</returns>
		public long CreateVideo(BrightcoveVideo video, string fileToUpload)
		{
			return CreateVideo(video, fileToUpload, EncodeTo.None);
		}

		#endregion

		#region UpdateVideo

		/// <summary>
		/// Updates the specified video.
		/// </summary>
		/// <param name="video"></param>
		/// <returns></returns>
		public BrightcoveVideo UpdateVideo(BrightcoveVideo video)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("update_video",
																		 methodParams => methodParams.Add("video", video));
			return RunPost<BrightcoveResultContainer<BrightcoveVideo>>(parms).Result;
		}

		#endregion

		#region DeleteVideo

		/// <summary>
		/// Deletes a video, specified by video ID
		/// </summary>
		/// <param name="videoId">The ID of the video you'd like to delete</param>
		/// <param name="cascade">If true, video will be deleted even if it is part of a manual playlist or assigned to 
		/// a player. The video will be removed from all playlists and players in which it appears, then deleted.</param>
		/// <param name="deleteShares">Set this to true if you want also to delete shared copies of this video. Note that 
		/// this will delete all shared copies from your account, as well as from all accounts with which the video has 
		/// been shared, regardless of whether or not those accounts are currently using the video in playlists or players.</param>
		public void DeleteVideo(long videoId, bool cascade, bool deleteShares)
		{
			DoDeleteVideo(videoId, null, cascade, deleteShares);
		}

		/// <summary>
		/// Deletes a video, specified by the video's reference ID
		/// </summary>
		/// <param name="referenceId">The reference ID of the video you'd like to delete</param>
		/// <param name="cascade">If true, video will be deleted even if it is part of a manual playlist or assigned to 
		/// a player. The video will be removed from all playlists and players in which it appears, then deleted.</param>
		/// <param name="deleteShares">Set this to true if you want also to delete shared copies of this video. Note that 
		/// this will delete all shared copies from your account, as well as from all accounts with which the video has 
		/// been shared, regardless of whether or not those accounts are currently using the video in playlists or players.</param>
		public void DeleteVideo(string referenceId, bool cascade, bool deleteShares)
		{
			DoDeleteVideo(-1, referenceId, cascade, deleteShares);
		}

		/// <summary>
		/// Deletes a video, specified by video ID or reference ID.
		/// </summary>
		/// <param name="videoId">The ID for the video to delete. Either a video ID or a reference ID must be supplied.</param>
		/// <param name="referenceId">The publisher-assigned reference ID of the video you want to delete. Either a video ID or a reference ID must be supplied.</param>
		/// <param name="cascade">Set this to true if you want to delete this video even if it is part of a manual playlist or assigned to a player. The video will be removed from all playlists and players in which it appears, then deleted.</param>
		/// <param name="deleteShares">Set this to true if you want also to delete shared copies of this video. Note that this will delete all shared copies from your account, as well as from all accounts with which the video has been shared, regardless of whether or not those accounts are currently using the video in playlists or players.</param>
		private void DoDeleteVideo(long videoId, string referenceId, bool cascade, bool deleteShares)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(videoId, referenceId, "video_id", "reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("delete_video",
																		 methodParams =>
																		 {
																			 methodParams.Add(propName, propValue);
																			 methodParams.Add("cascade", cascade.ToString().ToLower());
																			 methodParams.Add("delete_shares", deleteShares.ToString().ToLower());
																		 });

			RunPost<BrightcoveResultContainer<long>>(parms);
		}

		#endregion

		#region GetUploadStatus

		/// <summary>
		/// Determines the status of an upload.
		/// </summary>
		/// <param name="videoId">The ID of the video whose status you'd like to get.</param>
		/// <returns>A <see cref="BrightcoveUploadStatus"/> that specifies the current state of the upload.</returns>
		public BrightcoveUploadStatus GetUploadStatus(long videoId)
		{
			return DoGetUploadStatus(videoId, null);
		}

		/// <summary>
		/// Determines the status of an upload.
		/// </summary>
		/// <param name="referenceId">The reference ID of the video whose status you'd like to get.</param>
		/// <returns>A <see cref="BrightcoveUploadStatus"/> that specifies the current state of the upload.</returns>
		public BrightcoveUploadStatus GetUploadStatus(string referenceId)
		{
			return DoGetUploadStatus(-1, referenceId);
		}

		/// <summary>
		/// Determines the status of an upload.
		/// </summary>
		/// <param name="videoId">The ID of the video whose status you'd like to get.</param>
		/// <param name="referenceId">The reference ID of the video whose status you'd like to get.</param>
		/// <returns>A <see cref="BrightcoveUploadStatus"/> that specifies the current state of the upload.</returns>
		private BrightcoveUploadStatus DoGetUploadStatus(long videoId, string referenceId)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(videoId, referenceId, "video_id", "reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("get_upload_status",
																		 methodParams => methodParams.Add(propName, propValue));

			return RunPost<BrightcoveResultContainer<BrightcoveUploadStatus>>(parms).Result;
		}

		#endregion

		#region ShareVideo

		/// <summary>
		/// Shares the specified video with a list of sharee accounts.
		/// </summary>
		/// <param name="videoId">The id for video that will be shared.</param>
		/// <param name="autoAccept">If the target account has the option enabled, setting this flag to true will bypass 
		/// the approval process, causing the shared video to automatically appear in the target account's library. If the 
		/// target account does not have the option enabled, or this flag is unspecified or false, then the shared video 
		/// will be queued up to be approved by the target account before appearing in their library.</param>
		/// <param name="forceReshare">If true, indicates that if the shared video already exists in the target account's 
		/// library, it should be overwritten by the video in the sharer's account.</param>
		/// <param name="shareeAccountIds">List of Account IDs to share video with.</param>
		/// <returns>List of new video IDs (one for each account ID).</returns>
		public ICollection<long> ShareVideo(long videoId, bool autoAccept, bool forceReshare, IEnumerable<long> shareeAccountIds)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("share_video",
																		 methodParams =>
																		 {
																			 methodParams.Add("video_id", videoId);
																			 methodParams.Add("auto_accept", autoAccept.ToString().ToLower());
																			 methodParams.Add("force_reshare", forceReshare.ToString().ToLower());
																			 methodParams.Add("sharee_account_ids", shareeAccountIds);
																		 });

			return RunPost<BrightcoveResultContainer<long[]>>(parms).Result;
		}

		#endregion

		#region UnshareVideo

		/// <summary>
		/// Deletes the specified previously shared video from a list of sharee accounts. If a shared version of the specified video does not exist in a sharee account, no action is taken.
		/// </summary>
		/// <param name="videoId">The id for the video that is shared.</param>
		/// <param name="shareeAccountIds">List of Account IDs from which to stop sharing the video.</param>
		/// <returns>A collection of sharee account IDs for accounts previously containing shared videos specifically removed by this method.</returns>
		public ICollection<long> UnshareVideo(long videoId, IEnumerable<long> shareeAccountIds)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("unshare_video",
																		 methodParams =>
																		 {
																			 methodParams.Add("video_id", videoId);
																			 methodParams.Add("sharee_account_ids", shareeAccountIds);
																		 });

			return RunPost<BrightcoveResultContainer<long[]>>(parms).Result;
		}

		#endregion

		#region AddImage

		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		/// <param name="image">The metadata for the image you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="videoId">The ID of the video to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated</returns>
		public BrightcoveImage AddImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, long videoId, bool resize)
		{
			return DoAddImage(image, fileUploadInfo, videoId, null, resize);
		}

		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		/// <param name="image">The metadata for the image you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="videoReferenceId">The reference ID of the video to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated</returns>
		public BrightcoveImage AddImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, string videoReferenceId, bool resize)
		{
			return DoAddImage(image, fileUploadInfo, -1, videoReferenceId, resize);
		}

		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		/// <param name="image">The metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="videoId">The ID of the video to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated</returns>
		public BrightcoveImage AddImage(BrightcoveImage image, string fileToUpload, long videoId, bool resize)
		{
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return AddImage(image, new FileUploadInfo(fs, fileName), videoId, resize);
			}
		}

		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		/// <param name="image">The metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="videoReferenceId">The reference ID of the video to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated</returns>
		public BrightcoveImage AddImage(BrightcoveImage image, string fileToUpload, string videoReferenceId, bool resize)
		{
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return AddImage(image, new FileUploadInfo(fs, fileName), videoReferenceId, resize);
			}
		}

		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		/// <param name="image">The metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="videoId">The ID of the video to which you'd like to assign the image.</param>
		/// <returns>The image that was added or updated</returns>
		public BrightcoveImage AddImage(BrightcoveImage image, string fileToUpload, long videoId)
		{
			return AddImage(image, fileToUpload, videoId, true);
		}

		/// <summary>
		/// Add a new thumbnail or video still image to a video, or assign an existing image to another video.
		/// </summary>
		/// <param name="image">The metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="videoReferenceId">The reference ID of the video to which you'd like to assign the image.</param>
		/// <returns>The image that was added or updated</returns>
		public BrightcoveImage AddImage(BrightcoveImage image, string fileToUpload, string videoReferenceId)
		{
			return AddImage(image, fileToUpload, videoReferenceId, true);
		}


		private BrightcoveImage DoAddImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, long videoId, string videoReferenceId, bool resize)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(videoId, videoReferenceId, "video_id", "video_reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("add_image",
																		 methodParams =>
																		 {
																			 methodParams.Add("image", image);
																			 methodParams.Add("resize", resize.ToString().ToLower());
																			 methodParams.Add(propName, propValue);
																		 });

			return RunFilePost<BrightcoveResultContainer<BrightcoveImage>>(parms, fileUploadInfo).Result;
		}

		#endregion

		#region AddLogoOverlay

		/// <summary>
		/// Adds a logo overlay image to a video.
		/// </summary>
		/// <param name="logoOverlay">The metadata for the logo overlay you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="videoId">The ID of the video you want to assign a logo overlay to.</param>
		/// <returns>The newly created or updated BrightcoveLogoOverlay</returns>
		public BrightcoveLogoOverlay AddLogoOverlay(BrightcoveLogoOverlay logoOverlay, FileUploadInfo fileUploadInfo, long videoId)
		{
			return DoAddLogoOverlay(logoOverlay, fileUploadInfo, videoId, null);
		}

		/// <summary>
		/// Adds a logo overlay image to a video.
		/// </summary>
		/// <param name="logoOverlay">The metadata for the logo overlay you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="videoReferenceId">The reference ID of the video you want to assign a logo overlay to.</param>
		/// <returns>The newly created or updated BrightcoveLogoOverlay</returns>
		public BrightcoveLogoOverlay AddLogoOverlay(BrightcoveLogoOverlay logoOverlay, FileUploadInfo fileUploadInfo, string videoReferenceId)
		{
			return DoAddLogoOverlay(logoOverlay, fileUploadInfo, -1, videoReferenceId);
		}

		/// <summary>
		/// Adds a logo overlay image to a video.
		/// </summary>
		/// <param name="logoOverlay">The metadata for the logo overlay you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="videoId">The ID of the video you want to assign a logo overlay to.</param>
		/// <returns>The newly created or updated BrightcoveLogoOverlay</returns>
		public BrightcoveLogoOverlay AddLogoOverlay(BrightcoveLogoOverlay logoOverlay, string fileToUpload, long videoId)
		{
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return AddLogoOverlay(logoOverlay, new FileUploadInfo(fs, fileName), videoId);
			}
		}

		/// <summary>
		/// Adds a logo overlay image to a video.
		/// </summary>
		/// <param name="logoOverlay">The metadata for the logo overlay you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="videoReferenceId">The reference ID of the video you want to assign a logo overlay to.</param>
		/// <returns>The newly created or updated BrightcoveLogoOverlay</returns>
		public BrightcoveLogoOverlay AddLogoOverlay(BrightcoveLogoOverlay logoOverlay, string fileToUpload, string videoReferenceId)
		{
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return AddLogoOverlay(logoOverlay, new FileUploadInfo(fs, fileName), videoReferenceId);
			}
		}

		private BrightcoveLogoOverlay DoAddLogoOverlay(BrightcoveLogoOverlay logoOverlay, FileUploadInfo fileUploadInfo, long videoId, string videoReferenceId)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(videoId, videoReferenceId, "video_id", "video_reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("add_logo_overlay",
																		 methodParams =>
																		 {
																			 methodParams.Add("logooverlay", logoOverlay);
																			 methodParams.Add(propName, propValue);
																		 });

			return RunFilePost<BrightcoveResultContainer<BrightcoveLogoOverlay>>(parms, fileUploadInfo).Result;
		}

		#endregion

		#region RemoveLogoOverlay

		/// <summary>
		/// Removes a logo overlay previously assigned to a video.
		/// </summary>
		/// <param name="videoId">The ID of the video to remove the logo overlay from.</param>
		public void RemoveLogoOverlay(long videoId)
		{
			DoRemoveLogoOverlay(videoId, null);
		}

		/// <summary>
		/// Removes a logo overlay previously assigned to a video.
		/// </summary>
		/// <param name="videoReferenceId">The publisher-assigned reference ID of the video to remove 
		/// the logo overlay from.</param>
		public void RemoveLogoOverlay(string videoReferenceId)
		{
			DoRemoveLogoOverlay(-1, videoReferenceId);
		}

		private void DoRemoveLogoOverlay(long videoId, string videoReferenceId)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(videoId, videoReferenceId, "video_id", "video_reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("remove_logo_overlay",
																		 methodParams => methodParams.Add(propName, propValue));

			RunPost<BrightcoveResultContainer<long>>(parms);
		}

		#endregion
	}
}
