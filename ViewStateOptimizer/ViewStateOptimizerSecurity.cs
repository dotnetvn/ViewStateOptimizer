namespace ViewStateOptimizer
{
	using System;
	using System.Security.Cryptography;
	using System.Text;

	/// <summary>
	/// This static class contains the useful helpers to secure the configurations for ViewState
	/// </summary>
	public static class ViewStateOptimizerSecurity
	{
		/// <summary>
		/// Standardize from byte array to the UTF-8 string.
		/// </summary>
		/// <param name="bytes">byte array</param>
		/// <returns>Returns the UTF-8 string</returns>
		public static string StandardizeToUtf8String(byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes);
		}

		/// <summary>
		/// Standardize from string to byte array.
		/// </summary>
		/// <param name="value">string</param>
		/// <returns>Returns the byte array</returns>
		public static byte[] StandardizeToUtf8Bytes(string value)
		{
			return Encoding.UTF8.GetBytes(value);
		}

		/// <summary>
		/// Generates the salt byte array with the specified salt size.
		/// </summary>
		/// <param name="saltSize">salt size</param>
		/// <returns>Return the salt byte array</returns>
		public static byte[] GenerateSalt(int saltSize)
		{
			HashAlgorithm algorithm = new SHA512Managed();

			byte[] random = new Byte[saltSize];
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			rng.GetBytes(random);

			return algorithm.ComputeHash(random);
		}

		/// <summary>
		/// Generates the salt string with the specified salt size.
		/// </summary>
		/// <param name="saltSize">salt size</param>
		/// <returns>Return the salt string</returns>
		public static string GenerateSaltString(int saltSize)
		{
			return StandardizeToUtf8String(GenerateSalt(saltSize));
		}

		/// <summary>
		/// Generates the hash byte array with the specified value.
		/// </summary>
		/// <param name="value">string</param>
		/// <returns>Returns the hash byte array</returns>
		public static byte[] GenerateHash(string value)
		{
			HashAlgorithm algorithm = new SHA512Managed();
			return algorithm.ComputeHash(Encoding.Default.GetBytes(value));
		}

		/// <summary>
		/// Generates the hashed byte array with the specified value and salt string.
		/// </summary>
		/// <param name="value">hash string</param>
		/// <param name="salt">salt string</param>
		/// <returns>Returns the hashed byte array</returns>
		public static byte[] GenerateHashBySalt(string value, string salt)
		{
			var hmacSHA512 = new HMACSHA512(StandardizeToUtf8Bytes(salt));
			return hmacSHA512.ComputeHash(StandardizeToUtf8Bytes(value));
		}

		/// <summary>
		/// Generates the hashed string with the specified value and salt string.
		/// </summary>
		/// <param name="value">hash string</param>
		/// <param name="salt">salt string</param>
		/// <returns>Returns the hashed string</returns>
		public static string GenerateHashStringBySalt(string value, string salt)
		{
			return StandardizeToUtf8String(GenerateHashBySalt(value, salt));
		}
	}
}
