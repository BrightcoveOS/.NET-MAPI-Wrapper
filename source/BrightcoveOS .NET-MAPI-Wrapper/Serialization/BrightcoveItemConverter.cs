using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Model;

namespace BrightcoveMapiWrapper.Serialization
{
	public class BrightcoveItemConverter<T> : JavaScriptConverter where T : class, IJavaScriptConvertable, new()
	{
		private static Type ConvertsType
		{
			get
			{
				return typeof(T);
			}
		}

		public override IEnumerable<Type> SupportedTypes
		{
			get
			{
				return new List<Type>(new[] { ConvertsType });
			}
		}

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
