using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
		#region CreateAudioTrack
		///// <summary>
		///// Creates a new audio track in Brightcove by uploading a file.
		///// </summary>
		///// <param name="audioTrack">The audio track to create</param>
		///// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		///// <returns>The numeric ID of the uploaded track</returns>
		//public long CreateAudioTrack(BrightcoveAudioTrack audioTrack, FileUploadInfo fileUploadInfo)
		//{
		//    BrightcoveParamCollection parms = CreateWriteParamCollection("create_audiotrack",
		//                                                                 methodParams => methodParams.Add("audiotrack", audioTrack));
		//    return RunFilePost<BrightcoveResultContainer<long>>(parms, fileUploadInfo).Result;
		//}

		/// <summary>
		/// Creates a new audio track in Brightcove by uploading a file.
		/// </summary>
		/// <param name="audioTrack">The audio track to create</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <returns>The numeric ID of the uploaded track</returns>
		public long CreateAudioTrack(BrightcoveAudioTrack audioTrack, FileUploadInfo fileUploadInfo)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.CreateAudiotrack,
																		 methodParams => methodParams.Add("audiotrack", audioTrack));
			return RunFilePost<BrightcoveResultContainer<long>>(parms, fileUploadInfo).Result;
		}

		/// <summary>
		/// Creates a new audio track in Brightcove by uploading a file.
		/// </summary>
		/// <param name="audioTrack">The audio track to create</param>
		/// <param name="fileToUpload">The full path to the file to be uploaded.</param>
		/// <returns>The numeric ID of the uploaded track</returns>
		public long CreateAudioTrack(BrightcoveAudioTrack audioTrack, string fileToUpload)
		{
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return CreateAudioTrack(audioTrack, new FileUploadInfo(fs, fileName));
			}
		}
		#endregion

		#region AddAudioImage

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="audioTrackId">The ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated.</returns>
		public BrightcoveImage AddAudioImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, long audioTrackId, bool resize)
		{
			return DoAddAudioImage(image, fileUploadInfo, audioTrackId, null, resize);
		}

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="audioTrackReferenceId">The reference ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated.</returns>
		public BrightcoveImage AddAudioImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, string audioTrackReferenceId, bool resize)
		{
			return DoAddAudioImage(image, fileUploadInfo, -1, audioTrackReferenceId, resize);
		}

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
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return AddAudioImage(image, new FileUploadInfo(fs, fileName), audioTrackId, resize);
			}
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
			using (FileStream fs = File.OpenRead(fileToUpload))
			{
				string fileName = new FileInfo(fileToUpload).Name;
				return AddAudioImage(image, new FileUploadInfo(fs, fileName), audioTrackReferenceId, resize);
			}
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

		///// <summary>
		///// Add a thumbnail asset to the specified audio track.
		///// </summary>
		///// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		///// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		///// <param name="audioTrackId">The ID of the audio track to which you'd like to assign the image.</param>
		///// <param name="audioTrackReferenceId">The reference ID of the audio track to which you'd like to assign the image.</param>
		///// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		///// By default images will be resized.</param>
		///// <returns>The image that was added or updated.</returns>
		//private BrightcoveImage DoAddAudioImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, long audioTrackId, string audioTrackReferenceId, bool resize)
		//{
		//    string propName;
		//    object propValue;
		//    GetIdValuesForUpload(audioTrackId, audioTrackReferenceId, "audiotrack_id", "audiotrack_reference_id", out propName, out propValue);

		//    BrightcoveParamCollection parms = CreateWriteParamCollection("add_audio_image",
		//                                                                 methodParams =>
		//                                                                 {
		//                                                                     methodParams.Add("image", image);
		//                                                                     methodParams.Add("resize", resize.ToString().ToLower());
		//                                                                     methodParams.Add(propName, propValue);
		//                                                                 });

		//    return RunFilePost<BrightcoveResultContainer<BrightcoveImage>>(parms, fileUploadInfo).Result;
		//}

		/// <summary>
		/// Add a thumbnail asset to the specified audio track.
		/// </summary>
		/// <param name="image">A BrightcoveImage containing the metadata for the image you'd like to create (or update).</param>
		/// <param name="fileUploadInfo">Information for the file to be uploaded.</param>
		/// <param name="audioTrackId">The ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="audioTrackReferenceId">The reference ID of the audio track to which you'd like to assign the image.</param>
		/// <param name="resize">Set this to false if you don't want your image to be automatically resized to the default size for its type. 
		/// By default images will be resized.</param>
		/// <returns>The image that was added or updated.</returns>
		private BrightcoveImage DoAddAudioImage(BrightcoveImage image, FileUploadInfo fileUploadInfo, long audioTrackId, string audioTrackReferenceId, bool resize)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(audioTrackId, audioTrackReferenceId, "audiotrack_id", "audiotrack_reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.AddAudioImage,
																		 methodParams =>
																		 {
																			 methodParams.Add("image", image);
																			 methodParams.Add("resize", resize.ToString().ToLower());
																			 methodParams.Add(propName, propValue);
																		 });

			return RunFilePost<BrightcoveResultContainer<BrightcoveImage>>(parms, fileUploadInfo).Result;
		}

		#endregion

		#region UpdateAudioTrack
		///// <summary>
		///// Updates the audio track information for a Brightcove audio track.
		///// </summary>
		///// <param name="audioTrack"></param>
		///// <returns>The updated BrightcoveAudioTrack</returns>
		//public BrightcoveAudioTrack UpdateAudioTrack(BrightcoveAudioTrack audioTrack)
		//{
		//    BrightcoveParamCollection parms = CreateWriteParamCollection("update_audiotrack",
		//                                                                 methodParams => methodParams.Add("audiotrack", audioTrack));
		//    return RunPost<BrightcoveResultContainer<BrightcoveAudioTrack>>(parms).Result;
		//}

		///// <summary>
		///// Gets the audiotrack upload status. 
		///// </summary>
		///// <param name="referenceId">The reference id.</param>
		///// <returns>The status of the upload</returns>
		//public BrightcoveUploadStatus GetAudioTrackUploadStatus(string referenceId)
		//{
		//    BrightcoveParamCollection parms = CreateWriteParamCollection("get_audiotrack_upload_status",
		//                                                                 methodParams => methodParams.Add("reference_id", referenceId));
		//    return RunPost<BrightcoveResultContainer<BrightcoveUploadStatus>>(parms).Result;
		//}

		/// <summary>
		/// Updates the audio track information for a Brightcove audio track.
		/// </summary>
		/// <param name="audioTrack"></param>
		/// <returns>The updated BrightcoveAudioTrack</returns>
		public BrightcoveAudioTrack UpdateAudioTrack(BrightcoveAudioTrack audioTrack)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.UpdateAudiotrack,
																		 methodParams => methodParams.Add("audiotrack", audioTrack));
			return RunPost<BrightcoveResultContainer<BrightcoveAudioTrack>>(parms).Result;
		}
		#endregion

		#region GetAudioTrackUploadStatus
		/// <summary>
		/// Gets the audiotrack upload status. 
		/// </summary>
		/// <param name="referenceId">The reference id.</param>
		/// <returns>The status of the upload</returns>
		public BrightcoveUploadStatus GetAudioTrackUploadStatus(string referenceId)
		{
			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.GetAudiotrackUploadStatus,
																		 methodParams => methodParams.Add("reference_id", referenceId));
			return RunPost<BrightcoveResultContainer<BrightcoveUploadStatus>>(parms).Result;
		}
		#endregion

		#region DeleteAudioTrack
		/// <summary>
		/// Deletes an <see cref="BrightcoveAudioTrack">audio track</see>, specified by ID.
		/// </summary>
		/// <param name="audioTrackId">The ID of the <see cref="BrightcoveAudioTrack">audio track</see> you'd like to delete</param>
		/// <param name="cascade">If true, <see cref="BrightcoveAudioTrack">audio track</see> will be deleted even if it is part of a manual playlist or assigned to 
		/// a player. The <see cref="BrightcoveAudioTrack">audio track</see> will be removed from all playlists and players in which it appears, then deleted.</param>
		/// <param name="deleteShares">Set this to true if you want also to delete shared copies of this <see cref="BrightcoveAudioTrack">audio track</see>. Note that 
		/// this will delete all shared copies from your account, as well as from all accounts with which the <see cref="BrightcoveAudioTrack">audio track</see> has 
		/// been shared, regardless of whether or not those accounts are currently using the <see cref="BrightcoveAudioTrack">audio track</see> in playlists or players.</param>
		public void DeleteAudioTrack(long audioTrackId, bool cascade, bool deleteShares)
		{
			DoDeleteAudioTrack(audioTrackId, null, cascade, deleteShares);
		}

		/// <summary>
		/// Deletes a <see cref="BrightcoveAudioTrack">audio track</see>, specified by the reference ID.
		/// </summary>
		/// <param name="referenceId">The reference ID of the <see cref="BrightcoveAudioTrack">audio track</see> you'd like to delete</param>
		/// <param name="cascade">If true, <see cref="BrightcoveAudioTrack">audio track</see> will be deleted even if it is part of a manual playlist or assigned to 
		/// a player. The <see cref="BrightcoveAudioTrack">audio track</see> will be removed from all playlists and players in which it appears, then deleted.</param>
		/// <param name="deleteShares">Set this to true if you want also to delete shared copies of this <see cref="BrightcoveAudioTrack">audio track</see>. Note that 
		/// this will delete all shared copies from your account, as well as from all accounts with which the <see cref="BrightcoveAudioTrack">audio track</see> has 
		/// been shared, regardless of whether or not those accounts are currently using the <see cref="BrightcoveAudioTrack">audio track</see> in playlists or players.</param>
		public void DeleteAudioTrack(string referenceId, bool cascade, bool deleteShares)
		{
			DoDeleteAudioTrack(-1, referenceId, cascade, deleteShares);
		}

		/// <summary>
		/// Figures out whether the user wants to delete an audio track by ID or reference Id, then performs the action.
		/// </summary>
		/// <param name="audioTrackId">The ID of the <see cref="BrightcoveAudioTrack">audio track</see> you'd like to delete</param>
		/// <param name="referenceId">The reference ID of the <see cref="BrightcoveAudioTrack">audio track</see> you'd like to delete</param>
		/// <param name="cascade">If true, <see cref="BrightcoveAudioTrack">audio track</see> will be deleted even if it is part of a manual playlist or assigned to 
		/// a player. The <see cref="BrightcoveAudioTrack">audio track</see> will be removed from all playlists and players in which it appears, then deleted.</param>
		/// <param name="deleteShares">Set this to true if you want also to delete shared copies of this <see cref="BrightcoveAudioTrack">audio track</see>. Note that 
		/// this will delete all shared copies from your account, as well as from all accounts with which the <see cref="BrightcoveAudioTrack">audio track</see> has 
		/// been shared, regardless of whether or not those accounts are currently using the <see cref="BrightcoveAudioTrack">audio track</see> in playlists or players.</param>
		private void DoDeleteAudioTrack(long audioTrackId, string referenceId, bool cascade, bool deleteShares)
		{
			string propName;
			object propValue;
			GetIdValuesForUpload(audioTrackId, referenceId, "audiotrack_id", "reference_id", out propName, out propValue);

			BrightcoveParamCollection parms = CreateWriteParamCollection(BrightcoveWriteMethod.DeleteAudiotrack,
																		 methodParams =>
																		 {
																			 methodParams.Add(propName, propValue);
																			 methodParams.Add("cascade", cascade.ToString().ToLower());
																			 methodParams.Add("delete_shares", deleteShares.ToString().ToLower());
																		 });

			RunPost<BrightcoveResultContainer<long>>(parms);
		}
		#endregion
	}
}
