using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Model;

namespace BrightcoveMapiWrapper.Serialization
{
	/// <summary>
	/// Converts Brightcove model items to JavaScript objects and back.
	/// </summary>
	/// <typeparam name="T">The type of model item to convert.</typeparam>
	public class BrightcoveItemConverter<T> : JavaScriptConverter where T : class, IJavaScriptConvertable, new()
	{
		private static Type ConvertsType
		{
			get
			{
				return typeof(T);
			}
		}

		/// <summary>
		/// When overridden in a derived class, gets a collection of the supported types.
		/// </summary>
		/// <returns>
		/// An object that implements <see cref="IEnumerable{Type}" /> that represents the types supported by the converter.
		///   </returns>
		public override IEnumerable<Type> SupportedTypes
		{
			get
			{
				return new List<Type>(new[] { ConvertsType });
			}
		}

		/// <summary>
		/// When overridden in a derived class, converts the provided dictionary into an object of the specified type.
		/// </summary>
		/// <param name="dictionary">An <see cref="IDictionary{String, Object}" /> instance of property data stored as name/value pairs.</param>
		/// <param name="type">The type of the resulting object.</param>
		/// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer" /> instance.</param>
		/// <returns>
		/// The deserialized object.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">dictionary</exception>
		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}

			if (type != ConvertsType)
			{
				return null;
			}

			T t = new T();
			t.Deserialize(dictionary, serializer);
			return t;
		}

		/// <summary>
		/// When overridden in a derived class, builds a dictionary of name/value pairs.
		/// </summary>
		/// <param name="obj">The object to serialize.</param>
		/// <param name="serializer">The object that is responsible for the serialization.</param>
		/// <returns>
		/// An object that contains key/value pairs that represent the object’s data.
		/// </returns>
		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			T t = obj as T;
			if (t != null)
			{
				return t.Serialize(serializer);
			}
			return new Dictionary<string, object>();
		}
	}
}
