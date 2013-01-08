using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Util;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Api.Connectors;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Api
{
	/// <summary>
	/// .NET Wrapper for Brightcove's REST Media API.
	/// </summary>
	public partial class BrightcoveApi
	{
		private const string _methodParamsKey = "params";

		/// <summary>
		/// The pointer to the Configuration of the <see cref="Connector"/>. />
		/// </summary>
		public BrightcoveApiConfig Configuration
		{
			get
			{
				return Connector.Configuration;
			}
		}

		/// <summary>
		/// The Connector used for Brightcove connections.
		/// </summary>
		public IBrightcoveApiConnector Connector
		{
			get;
			set;
		}

		/// <summary>
		/// .NET Wrapper for Brightcove's REST Media API.
		/// </summary>
		/// <param name="connector"></param>
		public BrightcoveApi(IBrightcoveApiConnector connector)
		{
			Connector = connector;
		}

		/// <summary>
		/// Converts json retrieved from Brightcove to an instance of the corresponding wrapper model class.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="json"></param>
		/// <returns></returns>
		protected static T DeserializeJson<T>(string json) where T : IJavaScriptConvertable
		{
			JavaScriptSerializer serializer = BrightcoveSerializerFactory.GetSerializer();
			return serializer.Deserialize<T>(json);
		}

		/// <summary>
		/// Converts a wrapper model class into the corresponding JSON representation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		protected static string SerializeJson<T>(T obj) where T : IJavaScriptConvertable
		{
			JavaScriptSerializer serializer = BrightcoveSerializerFactory.GetSerializer();
			return serializer.Serialize(obj);
		}

		/// <summary>
		/// Runs an API read query (HTTP GET).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parms"></param>
		/// <returns></returns>
		protected T RunQuery<T>(NameValueCollection parms) where T : IJavaScriptConvertable
		{
			string json = Connector.GetResponseJson(parms);
			return DeserializeJson<T>(json);
		}

		/// <summary>
		/// Runs an API write (HTTP POST)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="postParams"></param>
		/// <returns></returns>
		protected T RunPost<T>(BrightcoveParamCollection postParams) where T : IJavaScriptConvertable
		{
			string responseJson = Connector.GetPostResponseJson(SerializeJson(postParams));
			return DeserializeJson<T>(responseJson);
		}

		/// <summary>
		/// Runs an API write (HTTP POST) that includes file data.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="fileToUpload"></param>
		/// <param name="postParams"></param>
		/// <returns></returns>
		protected T RunFilePost<T>(BrightcoveParamCollection postParams, FileUploadInfo fileToUpload) where T : IJavaScriptConvertable
		{
			string json = Connector.GetFilePostResponseJson(SerializeJson(postParams), fileToUpload);
			return DeserializeJson<T>(json);
		}

		/// <summary>
		/// Builds a collection of params common to all API read requests
		/// </summary>
		/// <param name="command">The name of a particular Brightcove read API method.</param>
		/// <returns>A <see cref="NameValueCollection"/> containing the basic GET parameters.</returns>
		protected NameValueCollection BuildBasicReadParams(string command)
		{
			NameValueCollection parms = new NameValueCollection();
			parms.Add("command", command);
			parms.Add("token", Configuration.ReadToken);

			if (!String.IsNullOrEmpty(Configuration.MediaDelivery))
			{
				parms.Add("media_delivery", Configuration.MediaDelivery);
			}
			return parms;
		}


		/// <summary>
		/// Builds a basic collection of write params common to all API write requests.
		/// </summary>
		/// <param name="method">The name of a particular Brightcove write API method.</param>
		/// <returns>A <see cref="NameValueCollection"/> containing the basic POST parameters.</returns>
		private BrightcoveParamCollection BuildBasicWriteParams(string method)
		{
			BrightcoveParamCollection methodParams = new BrightcoveParamCollection();
			methodParams.Add("token", Configuration.WriteToken);

			BrightcoveParamCollection parms = new BrightcoveParamCollection();
			parms.Add("method", method);
			parms.Add(_methodParamsKey, methodParams);

			return parms;
		}


		/// <summary>
		/// Builds a collection of write params common to all API write requests.
		/// </summary>
		/// <param name="method">The Brightcove write method to perform.</param>
		/// <param name="addMethodParamsCallback">The callback to performed on the passed dictionary.</param>
		/// <returns>A <see cref="NameValueCollection"/> containing the basic POST parameters.</returns>
		private BrightcoveParamCollection CreateWriteParamCollection(string method, Action<IDictionary<string, object>> addMethodParamsCallback)
		{
			BrightcoveParamCollection parms = BuildBasicWriteParams(method);
			if (addMethodParamsCallback != null)
			{
				BrightcoveParamCollection methodParams = (BrightcoveParamCollection)parms[_methodParamsKey];
				addMethodParamsCallback(methodParams);
			}
			return parms;
		}


		/// <summary>
		/// Determines whether to use the Id property or the reference Id property in various places in the API.
		/// </summary>
		/// <param name="numericId">The numeric id.</param>
		/// <param name="referenceId">The reference id.</param>
		/// <param name="idPropName">Name of the id property name.</param>
		/// <param name="refPropName">Name of the reference id property name.</param>
		/// <param name="propName">Name of the property to use.</param>
		/// <param name="propValue">The property value.</param>
		private static void GetIdValuesForUpload(long numericId, string referenceId, string idPropName, string refPropName, out string propName, out object propValue)
		{
			propName = String.IsNullOrEmpty(referenceId) ? idPropName : refPropName;
			propValue = referenceId;
			if (String.IsNullOrEmpty(referenceId))
			{
				propValue = numericId;
			}
		}
	}
}
