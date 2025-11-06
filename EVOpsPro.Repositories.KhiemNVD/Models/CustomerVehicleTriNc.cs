using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class CustomerVehicleTriNc
{
    public int? CustomerVehicleTriNcid { get; set; }

    public string CustomerFullName { get; set; } = null!;

    public string? Email { get; set; }

    public string Vin { get; set; } = null!;
    public string? VehicleName { get; set; }

    public int VehicleTypeTriNcid { get; set; }

    public int? Year { get; set; }

    public bool IsUnderWarranty { get; set; }

    public DateOnly? WarrantyExpiry { get; set; }

    public string WorkDescription { get; set; } = null!;

    public decimal? OdometerKm { get; set; }


    public DateTime ServiceDate { get; set; }

    public virtual VehicleTypeTriNc? VehicleTypeTriNc { get; set; } = null!;
}
