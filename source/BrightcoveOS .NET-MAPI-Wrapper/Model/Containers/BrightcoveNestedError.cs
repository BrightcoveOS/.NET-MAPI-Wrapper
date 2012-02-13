using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Model.Containers
{
    public class BrightcoveNestedError : IBrightcoveError, IJavaScriptConvertable
    {
        #region IBrightcoveError implementation
        
        public string Message
		{
			get;
			private set;
		}

		public int Code
		{
			get;
			private set;
		}

		public ICollection<BrightcoveNestedError> Errors
		{
			get;
			private set;
        }

        #endregion IBrightcoveError implementation

        public BrightcoveNestedError()
		{
			Errors = new List<BrightcoveNestedError>();
		}

		#region IJavaScriptConvertable implementation

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
		{
			foreach (string key in dictionary.Keys)
			{
				switch (key)
				{
					case "error":
						Message = dictionary[key].ToString();
						break;

					case "code":
						Code = (int)dictionary[key];
						break;

					case "errors":
						Errors.Clear();
						Errors.AddRange(serializer.ConvertToType<BrightcoveNestedError[]>(dictionary[key]));
						break;
				}
			}
		}

		#endregion
	}
}
