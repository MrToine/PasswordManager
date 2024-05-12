using System;

namespace Generator
{
	public class Generator
	{
		public generate_password()
		{
			const string chars = "ABCDEFGHIJLKMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789./*-+=)àç_è-('é&1234567890°+^$ù*!:;,?§%µ£";
			var random = new Random;

			string randomString = new string(Enumerable.Reapeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

			Console.WriteLine(randomString);
		}
	}
}
