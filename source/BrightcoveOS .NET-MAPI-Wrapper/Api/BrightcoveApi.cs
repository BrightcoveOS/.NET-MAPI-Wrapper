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
		/// Builds a collection of params common to all API read requests.
		/// </summary>
		/// <typeparam name="T">An enum of type <see cref="BrightcoveReadMethod"/>.</typeparam>
		/// <param name="method">A valid <see cref="BrightcoveReadMethod"/> value to perform.</param>
		/// <returns>A <see cref="NameValueCollection"/> containing the basic GET parameters.</returns>
		protected NameValueCollection BuildBasicReadParams<T>(T method) where T : struct, IConvertible
		{
			NameValueCollection parms = new NameValueCollection();
			parms.Add("command", method.ToBrightcoveName().ToLower());
			parms.Add("token", Configuration.ReadToken);

			if (!String.IsNullOrEmpty(Configuration.MediaDelivery))
			{
				parms.Add("media_delivery", Configuration.MediaDelivery);
			}
			return parms;
		}

		///// <summary>
		///// Builds a collection of params common to all API read requests
		///// </summary>
		///// <param name="command"></param>
		///// <returns></returns>
		//protected NameValueCollection BuildBasicReadParams(string command)
		//{
		//    NameValueCollection parms = new NameValueCollection();
		//    parms.Add("command", command);
		//    parms.Add("token", Configuration.ReadToken);

		//    if (!String.IsNullOrEmpty(Configuration.MediaDelivery))
		//    {
		//        parms.Add("media_delivery", Configuration.MediaDelivery);
		//    }
		//    return parms;
		//}


		/// <summary>
		/// Builds a collection of params common to all API write requests.
		/// </summary>
		/// <typeparam name="T">An enum of type <see cref="BrightcoveWriteMethod"/>.</typeparam>
		/// <param name="method">A valid <see cref="BrightcoveWriteMethod"/> value to perform.</param>
		/// <returns>A <see cref="NameValueCollection"/> containing the basic POST parameters.</returns>
		private BrightcoveParamCollection BuildBasicWriteParams<T>(T method) where T : struct, IConvertible
		{
			BrightcoveParamCollection methodParams = new BrightcoveParamCollection();
			methodParams.Add("token", Configuration.WriteToken);

			BrightcoveParamCollection parms = new BrightcoveParamCollection();
			parms.Add("method", method.ToBrightcoveName().ToLower());
			parms.Add(_methodParamsKey, methodParams);

			return parms;
		}

		///// <summary>
		///// Builds a collection of params common to all API write requests
		///// </summary>
		///// <param name="method"></param>
		///// <returns></returns>
		//private BrightcoveParamCollection BuildBasicWriteParams(string method)
		//{
		//    BrightcoveParamCollection methodParams = new BrightcoveParamCollection();
		//    methodParams.Add("token", Configuration.WriteToken);

		//    BrightcoveParamCollection parms = new BrightcoveParamCollection();
		//    parms.Add("method", method);
		//    parms.Add(_methodParamsKey, methodParams);

		//    return parms;
		//}

		
		private BrightcoveParamCollection CreateWriteParamCollection<T>(T method, Action<IDictionary<string, object>> addMethodParamsCallback) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			BrightcoveParamCollection parms = BuildBasicWriteParams(method);
			if (addMethodParamsCallback != null)
			{
				BrightcoveParamCollection methodParams = (BrightcoveParamCollection)parms[_methodParamsKey];
				addMethodParamsCallback(methodParams);
			}
			return parms;
		}

		//private BrightcoveParamCollection CreateWriteParamCollection(string method, Action<IDictionary<string, object>> addMethodParamsCallback)
		//{
		//    BrightcoveParamCollection parms = BuildBasicWriteParams(method);
		//    if (addMethodParamsCallback != null)
		//    {
		//        BrightcoveParamCollection methodParams = (BrightcoveParamCollection)parms[_methodParamsKey];
		//        addMethodParamsCallback(methodParams);
		//    }
		//    return parms;
		//}


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
