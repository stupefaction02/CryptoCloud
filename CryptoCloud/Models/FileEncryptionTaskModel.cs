namespace CryptoCloud.Models
{
    public class FileEncryptionTaskModel
    {
        public string Name { get; set; }

        public string SizeInfo { get; set; }

        /// <summary>
        /// 1-100
        /// </summary>
        public int ProgressValue { get; set; }
    }
}
