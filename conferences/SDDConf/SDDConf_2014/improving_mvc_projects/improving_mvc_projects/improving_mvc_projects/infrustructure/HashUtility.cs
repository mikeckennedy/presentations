using System;
using System.Linq;
using System.Security.Cryptography;

namespace improving_mvc_projects.infrustructure
{
	public static class HashUtility
	{
		public static string HashToString(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
			{
				return "0";
			}

			using (var md5 = MD5.Create())
			{
				return string.Join(string.Empty, md5.ComputeHash(bytes).Select(c => c.ToString("x2")));
			}
		}
	}
}