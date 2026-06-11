using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMMapp.Data;
using EMMapp.Models;
using EMMapp.Dtos;
using EMMapp.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace EMMapp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RegistrationsController : ControllerBase
{
    private readonly AppDbContext _context;

    private readonly CertificateService _certificateService;

    public RegistrationsController(AppDbContext context, CertificateService certificateService)
    {
        _context = context;
        _certificateService = certificateService;
    }

//GET: api/registrations

    [HttpGet]
    public async Task< IActionResult> GetAll()
    {
        var registrations = await _context.Registrations.OrderByDescending( r => r.CreatedAt).ToListAsync();
        return Ok(registrations);
    }

    //GET; /api/registrations/$
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var registration = await _context.Registrations.FindAsync(id);

        if(registration == null)
            return NotFound();

        return Ok(registration);
    }

//POST: api/registrations
    [HttpPost]
    public async Task<IActionResult> Create(RegistrationCreateDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var registration = new Registration
            {
                lastName = dto.lastName,
                hisName = dto.hisName,
                herName = dto.herName,
                hisPhone = dto.hisPhone,
                herPhone = dto.herPhone,
                city = dto.city,
                zone = dto.zone,
                paid = dto.paid,
                churchMarried = dto.churchMarried,
                readSpanish = dto.readSpanish,
                yearsMarried = dto.yearsMarried,
                comments = dto.comments

            };



        _context.Registrations.Add(registration);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = registration.id}, registration);
    }

    //PUT: api/registrations
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Registration updated)
    {
        var registration = await _context.Registrations.FindAsync(id);

        if(registration == null)
            return NotFound();


        registration.lastName = updated.lastName;
        registration.hisName = updated.hisName;
        registration.herName = updated.herName;
        registration.hisPhone = updated.hisPhone;
        registration.city = updated.city;
        registration.zone = updated.zone;
        registration.herPhone = updated.herPhone;
        registration.paid = updated.paid;
        registration.churchMarried = updated.churchMarried;
        registration.readSpanish = updated.readSpanish;
        registration.yearsMarried = updated.yearsMarried;
        registration.comments = updated.comments;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    //DELETE; api/registrations/$
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var registration = await _context.Registrations.FindAsync(id);

        if(registration == null)
            return NotFound();

        _context.Remove(registration);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    //Certificate for member
    [HttpGet("{id}/Certificate")]
    public async Task<IActionResult> GenerateCertificate(int id)
    {
        var registration = await _context.Registrations.FindAsync(id);

        if(registration == null)
        {
            return NotFound();
        }

        var pdfBytes = _certificateService.GenerateCertificate(registration.hisName, registration.herName, registration.lastName);

        return File(pdfBytes, "application/pdf", $"{registration.lastName}, {registration.hisName} y {registration.herName} certificado.pdf");
    }


    [HttpGet("certificates/all")]
    public async Task<IActionResult> GenerateAllCertificates()
    {
        var registrations = await _context.Registrations
        .OrderBy(r => r.lastName)
        .ToListAsync();

        if(!registrations.Any())
        {
            return BadRequest("No registrations found.");
        }

        var pdf = _certificateService.GenerateAllCertificates(registrations);

        return File(pdf, "application/pdf", "all-certificates.pdf");
    }

    //Table Tents
    [HttpGet("{id}/table-tent")]
    public async Task<IActionResult> GenerateTableTent(int id)
    {
        var registration = await _context.Registrations.FindAsync(id);

        if(registration == null)
        {
            return NotFound();
        }

        var pdf = _certificateService.GenerateTableTent(registration.hisName, registration.herName, registration.lastName);

        return File(pdf, "application/pdf", $"{registration.lastName}, {registration.hisName} y {registration.herName} Table Tents.pdf");
    }

    [HttpGet("table-tents/all")]
    public async Task<IActionResult> GenerateAllTableTents()
    {
        var registrations = await _context.Registrations
        .OrderBy( r => r.lastName)
        .ToListAsync();

        if(!registrations.Any())
        {
            return BadRequest("No registrations found.");
        }

        var pdf = _certificateService.GenerateAllTableTents(registrations);

        return File( pdf, "application/pdf", "all-table-tents.pdf");
    }

}
