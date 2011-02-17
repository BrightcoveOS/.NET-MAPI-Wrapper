using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Model.Items;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// Represents a collection of BrightcoveItems
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BrightcoveItemCollection<T> : List<T>, IJavaScriptConvertable where T : BrightcoveItem, IJavaScriptConvertable
	{
		/// <summary>
		/// The current page of results. (Each page is limited to a max of 100 items)
		/// </summary>
		public int PageNumber
		{
			get;
			set;
		}

		/// <summary>
		/// The size of each page of results. If not specified, the default is 100
		/// </summary>
		public int PageSize
		{
			get;
			set;
		}

		/// <summary>
		/// The total number of items available
		/// </summary>
		public int TotalCount
		{
			get;
			set;
		}

		#region IJavaScriptConvertable implementation

		public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
		{
			foreach (string key in dictionary.Keys)
			{
				switch (key)
				{
					case "error":
						ApiUtil.ThrowIfError(dictionary, key, serializer);
						break;

					case "items":
						Clear();
						AddRange(serializer.ConvertToType<T[]>(dictionary[key]));
						break;

					case "page_number":
						PageNumber = (int) dictionary[key];
						break;

					case "page_size":
						PageSize = (int) dictionary[key];
						break;

					case "total_count":
						TotalCount = (int) dictionary[key];
						break;
				}
			}
		}

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
