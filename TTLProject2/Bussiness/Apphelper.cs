namespace TTLProject2.Bussines
{
    public static partial class Apphelper
    {

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

        public async static Task<string> SaveMultipleFile(List<IFormFile> files, string path)
        {
            var fileName = string.Empty;
            foreach (var file in files)
            {
                var name = await SaveFile(path, file.FileName, file.OpenReadStream());
                fileName += $"{name},";
            }
            return fileName.Remove(fileName.Length - 1, 1);
        }

    }
}
