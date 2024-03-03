namespace LIMRhino.Bridge
{
    using System;

    public class SpeciesRecord
    {
        public int Id { get; set; } // Non-nullable
        public DateTime? CreatedAt { get; set; } // Nullable DateTime
        public string? TaxonomicGroup { get; set; }
        public string? ScientificName { get; set; }
        public string? MapOfLifeLink { get; set; }
        public string? ThreatStatus { get; set; }
        public string? Family { get; set; }
        public string? Expected { get; set; }
        public string? Recorded { get; set; }
        public string? CommonName { get; set; }
        public string? Obj { get; set; }
        public string? Image { get; set; }
        public double? OxygenProductionKgPerAcreYear { get; set; } // Nullable double
        public double? CarbonStorageKgPerAcreYear { get; set; } // Nullable double

    }

}