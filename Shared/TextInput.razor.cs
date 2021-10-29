using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazorWasm.Shared
{
    public class TextInputBase : ComponentBase
    {
		[Parameter]
		public Mode TextMode { get; set; }

		[Parameter]
		public string Value { get; set; }

		protected string ClassName => DateTime.Now.ToString("g", CultureInfo.CreateSpecificCulture("fr-FR"));

		public enum Mode
		{
			Default,
			Required
		}
	}
}
