using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// Prepares an ordered dictionary of fields for sorting by the SearchVideos method.
	/// </summary>
	public class SortedFieldDictionary
	{
		/// <summary>
		/// A dictionary that preserves both uniqueness of <see cref="SortBy"/> (you can only sort by one field in a single request) and insertion order (the order by which you sort directly affects which items are returned by a single API call).
		/// </summary>
		public IOrderedDictionary OrderedDictionary { get; protected set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="orderedDictionary">A properly constructed <see cref="IOrderedDictionary"/>.</param>
		/// <example>
		/// The example below demonstrates how to pass in objects to this constructor.
		/// <code>
		/// var dict = new <see cref="OrderedDictionary"/>
		///	{
		///		{ SortBy.CreationDate, SortOrder.Ascending },
		///		{ SortBy.CreationDate, SortOrder.Descending }
		///	};
		///	SortedFieldDictionary sortFields = new SortedFieldDictionary(dict);
		/// </code>
		/// </example>
		public SortedFieldDictionary(IOrderedDictionary orderedDictionary)
		{
			OrderedDictionary = orderedDictionary;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="fields">The <see cref="object"/> array passed to the constructor.</param>
		/// <example>
		/// The example below demonstrates how to pass in objects to this constructor.
		/// <code>
		/// SortedFieldDictionary sortFields = new SortedFieldDictionary(SortBy.DisplayName, SortOrder.Ascending, SortBy.CreationDate, SortOrder.Descending);
		/// </code>
		/// </example>
		public SortedFieldDictionary(params object[] fields)
		{
			ParseParams(ref fields);
		}

		/// <summary>
		/// Parses the parameters passed to the constructor.
		/// </summary>
		/// <param name="fields">The object[] passed to the constructor.</param>
		/// <exception cref="ArgumentException">Either the length of the params argument is odd, each pair of objects within the params argument do not each comprise a valid <see cref="KeyValuePair{SortBy,SortOrder}"/>, or there is a duplicate <see cref="SortBy"/> key within the params argument.</exception>
		private void ParseParams(ref object[] fields)
		{
			var orderedDictionary = new OrderedDictionary();
			
			// Must have an even number of items in the array.
			if (fields.Length % 2 != 0)
			{
				throw new ArgumentException("There must be an even number of items in the array.");
			}
			else
			{
				for (int i = 0; i < fields.Length/2; i++)
				{
					if (fields[i*2] is SortBy && fields[i*2 + 1] is SortOrder)
					{
						orderedDictionary.Add((SortBy)fields[i * 2], (SortOrder)fields[i * 2 + 1]);
					}
					else
					{
						throw new ArgumentException(
							"Each pair of items added to the object array must be a pairing of SortBy then SortOrder.");
					}
				}
			}

			OrderedDictionary = orderedDictionary;
		}
	}
}
