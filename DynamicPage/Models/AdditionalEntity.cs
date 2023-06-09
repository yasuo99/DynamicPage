﻿namespace DynamicPage.Models
{
    public class AdditionalEntity
    {
        public string EntityName { get; set; }
        public string TableName { get; set; }
        public string? TableSchema { get; set; }
        public List<AdditionalField> Key { get; set; } = new();
        public List<AdditionalField> Fields { get; set; } = new();
    }
}