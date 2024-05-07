using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace TTLProject2.Models
{
	public static class AppHelper
	{
		public static string RandomKey(string value)
		{
			string[] keys = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "q", "w", "e", "r", "t", "y", "u", "p", "a", "s", "d", "f", "g", "h", "j", "k", "z", "x", "c", "v", "b", "n", "m" };
			string key = value;
			Random random = new Random();
			for (int i = 0; i < 7; i++)
				key += keys[random.Next(0, keys.Length - 1)].ToString();
			return key.ToUpperInvariant();
		}

		public static string RemoveUnicode(string text)
		{
			string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
											"đ",
											"é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
											"í","ì","ỉ","ĩ","ị",
											"ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
											"ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
											"ý","ỳ","ỷ","ỹ","ỵ",};
			string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
											"d",
											"e","e","e","e","e","e","e","e","e","e","e",
											"i","i","i","i","i",
											"o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
											"u","u","u","u","u","u","u","u","u","u","u",
											"y","y","y","y","y",};
			for (int i = 0; i < arr1.Length; i++)
			{
				text = text.Replace(arr1[i], arr2[i]);
				text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
			}
			return text;
		}

		public static string ConvertToSentenceCase(string fullName)
		{
			int length = 0;
			string value = string.Empty;
			string[] fullNames = fullName.Split(' ');
			foreach (string s in fullNames)
			{
				length += s.Length;
				value += s.ToLowerInvariant().Trim().ToSentenceCase() + ' ';
			}
			return value.Trim();
		}

		public static string ToSentenceCase(this string s)
		{
			if (s.Length > 1)
				return s.Substring(0, 1).ToUpperInvariant() + s.Substring(1, s.Length - 1);
			else
				return s.ToUpperInvariant();
		}

		public static string GetLastName(string fullName)
		{
			string result = string.Empty;
			try
			{
				string pupilName = fullName.Trim().Replace(' ', '#');
				if (!pupilName.Contains("#"))
					return string.Empty;
				string[] token = pupilName.Split('#');
				result = token[0];
			}
			catch
			{
			}
			return result;
		}

		public static string GetMiddleName(string fullName)
		{
			string result = string.Empty;
			try
			{
				string pupilName = fullName.Trim().Replace(' ', '#');
				if (!pupilName.Contains("#"))
					return string.Empty;
				string[] token = pupilName.Split('#');
				if (token.Length == 2)
					return string.Empty;
				for (int i = 1; i < token.Length - 1; i++)
					result += token[i] + " ";
				result = result.Trim();
			}
			catch
			{
			}
			return result;
		}

		public static string GetFirstName(string fullName)
		{
			string result = string.Empty;
			try
			{
				string pupilName = fullName.Trim().Replace(' ', '#');
				if (fullName.Trim() == string.Empty)
					return string.Empty;
				if (!pupilName.Contains("#"))
					return pupilName.Trim();
				string[] token = pupilName.Split('#');
				result = token[token.Length - 1];
			}
			catch
			{
			}
			return result;
		}

        public async static Task<string> SaveFile(string path, string name, Stream stream)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fileInfo = new FileInfo(name);
            string guid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15);
            string fileName = $"{RemoveUnicode(fileInfo.Name).Replace(" ", "-").Replace("+", "-").Replace(fileInfo.Extension, "")}{guid}{fileInfo.Extension}";
            path = Path.Combine(path, fileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
                stream.Close();
            }
            return fileName;
        }

        public static IEnumerable<string> RenderNam()
        {
            for (var i = 2005; i >= 1963; i--)
            {
                yield return i.ToString();
            }
        }
        public static IEnumerable<string> RenderThang()
        {
            for (var i = 1; i <= 12; i++)
            {
                yield return i.ToString("00");
            }
        }
        public static IEnumerable<string> RenderNgay()
        {
            for (var i = 1; i <= 31; i++)
            {
                yield return i.ToString("00");
            }
        }
    }
}
