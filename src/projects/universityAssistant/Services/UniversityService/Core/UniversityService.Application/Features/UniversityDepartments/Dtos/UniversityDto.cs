﻿namespace UniversityService.Application.Features.UniversityDepartments.Dtos;

public class UniversityDto
{
    public int Id { get; set; }
    public int ProvienceId { get; set; }
    public string ProvienceName { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public string Name { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Address { get; set; }
    public byte Type { get; set; }
}
