using System;

namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; } // Ajustado para coincidir con el modelo Product
        public string? WeightUnitMeasureCode { get; set; } // Ajustado para coincidir con el modelo Product
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string? ProductLine { get; set; }
        public string? Class { get; set; } // Ajustado para coincidir con el modelo Product
        public string? Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
