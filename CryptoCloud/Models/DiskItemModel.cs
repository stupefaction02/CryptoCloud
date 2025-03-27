namespace CryptoCloud.Models
{
    public class DiskItemModel
    {
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// item or addButton
        /// </summary>
        public string Type { get; set; } = "item";

        public DiskModel DiskModel { get; set; }
    }
}
