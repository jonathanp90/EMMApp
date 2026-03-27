using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMMapp.Data;
using EMMapp.Models;
using EMMapp.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace EMMapp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RegistrationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RegistrationsController(AppDbContext context)
    {
        _context = context;
    }

//GET: api/registrations

    [HttpGet]
    public async Task< IActionResult> GetAll()
    {
        var registrations = await _context.Registrations.OrderByDescending( r => r.CreatedAt).ToListAsync();
        return Ok(registrations);
    }

    //GET; api/registrations/$
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var registration = await _context.Registrations.FindAsync(id);

        if(registration == null)
            return NotFound();
        
        return Ok(registration);
    }

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
                city = dto.city,
                zone = dto.zone,
                herPhone = "",
                paid = 0.0f,
                churchMarried = false,
                readSpanish = false,
                comments = ""

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
        _context.SaveChangesAsync();

        return NoContent();
    }

}