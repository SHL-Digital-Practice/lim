namespace LIMRhino.Bridge
{
    using System;

    public class SpeciesRecord
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TaxonomicGroup { get; set; }
        public string ScientificName { get; set; }
        public string MapOfLifeLink { get; set; }
        public string ThreatStatus { get; set; }
        public string Family { get; set; }
        public bool? Expected { get; set; }
        public bool Recorded { get; set; }
        public string CommonName { get; set; }
        public string Obj { get; set; }
        public string Image { get; set; }
        public float? OxygenProductionKgPerAcrePerYear { get; set; }
        public float? CarbonStorageKgPerAcrePerYear { get; set; }
    }

}