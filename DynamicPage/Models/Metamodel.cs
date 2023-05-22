namespace DynamicPage.Models
{
    public class Metamodel
    {
        public int Version { get; set; }
        public List<AdditionalField> Fields { get; set; } = new();
        public List<AdditionalEntity> Entities { get; set; } = new();
    }
}
