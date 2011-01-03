using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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
		/// Creates a new audio track in Brightcove by uploading a file.
		/// </summary>
		/// <param name="audioTrack">The audio track to create</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <returns>The numeric ID of the uploaded track</returns>
		public long CreateAudioTrack(BrightcoveAudioTrack audioTrack, string fileToUpload)
		{
			string fileName;
			byte[] fileBytes;
			GetFileUploadInfo(fileToUpload, out fileName, out fileBytes);

			BrightcoveParamCollection parms = CreateWriteParamCollection("create_audiotrack",
																		 methodParams => methodParams.Add("audiotrack", audioTrack));
			return RunFilePost<BrightcoveResultContainer<long>>(parms, fileName, fileBytes).Result;
		}

		#region AddAudioImage

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="audioTrackId">The ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated.</returns>
		public BrightcoveImage AddAudioImage(BrightcoveImage image, string fileToUpload, long audioTrackId, bool resize)
		{
			return DoAddAudioImage(image, fileToUpload, audioTrackId, null, resize);
		}

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="audioTrackReferenceId">The reference ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated.</returns>
		public BrightcoveImage AddAudioImage(BrightcoveImage image, string fileToUpload, string audioTrackReferenceId, bool resize)
		{
			return DoAddAudioImage(image, fileToUpload, -1, audioTrackReferenceId, resize);
		}

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="audioTrackId">The ID of the audio track to which you'd like to assign the image.</param>
		/// <returns>The image that was added or updated.</returns>
		public BrightcoveImage AddAudioImage(BrightcoveImage image, string fileToUpload, long audioTrackId)
		{
			return AddAudioImage(image, fileToUpload, audioTrackId, true);
		}

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="audioTrackReferenceId">The reference ID of the audio track to which you'd like to assign the image.</param>
		/// <returns>The image that was added or updated.</returns>
		public BrightcoveImage AddAudioImage(BrightcoveImage image, string fileToUpload, string audioTrackReferenceId)
		{
			return AddAudioImage(image, fileToUpload, audioTrackReferenceId, true);
		}

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileToUpload">The full path of the file to be uploaded.</param>
		/// <param name="audioTrackId">The ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="audioTrackReferenceId">The reference ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated.</returns>
		private BrightcoveImage DoAddAudioImage(BrightcoveImage image, string fileToUpload, long audioTrackId, string audioTrackReferenceId, bool resize)
		{
			string fileName;
			byte[] fileBytes;
			GetFileUploadInfo(fileToUpload, out fileName, out fileBytes);

			string propName;
			object propValue;
			GetIdValuesForUpload(audioTrackId, audioTrackReferenceId, "audiotrack_id", "audiotrack_reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection("add_audio_image",
																		 methodParams =>
																		 {
																			 methodParams.Add("image", image);
																			 methodParams.Add("resize", resize.ToString().ToLower());
																			 methodParams.Add(propName, propValue);
																		 });

			return RunFilePost<BrightcoveResultContainer<BrightcoveImage>>(parms, fileName, fileBytes).Result;
		}

		#endregion

		/// <summary>
		/// Updates the audio track information for a Brightcove audio track.
		/// </summary>
		/// <param name="audioTrack"></param>
		/// <returns>The updated BrightcoveAudioTrack</returns>
		public BrightcoveAudioTrack UpdateAudioTrack(BrightcoveAudioTrack audioTrack)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("update_audiotrack",
																		 methodParams => methodParams.Add("audiotrack", audioTrack));
			return RunPost<BrightcoveResultContainer<BrightcoveAudioTrack>>(parms).Result;
		}

		/// <summary>
		/// Gets the audiotrack upload status. 
		/// </summary>
		/// <param name="referenceId">The reference id.</param>
		/// <returns>The status of the upload</returns>
		public BrightcoveUploadStatus GetAudioTrackUploadStatus(string referenceId)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection("get_audiotrack_upload_status",
																		 methodParams => methodParams.Add("reference_id", referenceId));
			return RunPost<BrightcoveResultContainer<BrightcoveUploadStatus>>(parms).Result;
		}
	}
}
