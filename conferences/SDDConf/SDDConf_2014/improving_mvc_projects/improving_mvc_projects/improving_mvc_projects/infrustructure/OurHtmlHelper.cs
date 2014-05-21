using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Web;

namespace improving_mvc_projects.infrustructure
{
	public static class OurHtmlHelper
	{
		private static ConcurrentDictionary<string, string> fileHashLookup = new ConcurrentDictionary<string, string>();


		public static string GetLinkedFileHash(string fileUrl)
		{
			try
			{
#if DEBUG
				string fileName = HttpContext.Current.Server.MapPath(fileUrl);
				string hash = HashUtility.HashToString(File.ReadAllBytes(fileName));
				return hash;
#else
				return fileHashLookup.GetOrAdd(
					fileUrl,
					s =>
					{
						string fileName = HttpContext.Current.Server.MapPath(fileUrl);
						string hash = HashUtility.HashToString(File.ReadAllBytes(fileName));
						return hash;
					});
#endif
			}
			catch
			{
				return "error";
			}
		}


		public static string ToUrlStyle(this string text, bool lowercase = true)
		{
			if (text == null)
				return null;

			StringBuilder sb = new StringBuilder(text.Trim());
			sb.Replace("C#", "csharp");
			sb.Replace("c#", "csharp");
			sb.Replace("ASP.NET", "ASPNET");
			sb.Replace("asp.net", "aspnet");
			sb.Replace("asp.net", "aspnet");
			sb.Replace(" .net", " dotnet");
			sb.Replace(" .NET", " dotNET");
			sb.Replace("c++", "cplusplus");
			sb.Replace("C++", "cplusplus");
			for (int i = 0; i < sb.Length; i++)
			{
				if (!char.IsLetterOrDigit(sb[i]))
				{
					sb[i] = ' ';
				}
			}

			text = sb.ToString();

			while (text.IndexOf("  ") >= 0)
			{
				text = text.Replace("  ", " ");
			}

			text = text.Trim();
			text = text.Replace(" ", "-");
			text = text.Trim();

			if (lowercase)
				text = text.ToLower();

			return HttpUtility.UrlEncode(text);
		}

	}
}