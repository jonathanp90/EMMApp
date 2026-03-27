using Microsoft.EntityFrameworkCore;
using EMMapp.Data;
using EMMapp.Models;
using EMMapp.Controllers;

namespace EMMapp.Services;

public class RegistrationService
{
    private readonly AppDbContext _context;

    public RegistrationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Registration>> GetAllAsync()
    {
        return await _context.Registrations.OrderByDescending(r => r.CreatedAt).ToListAsync();

    }

    public async Task<Registration> CreateAsync(Registration registration)
    {
        _context.Registrations.Add(registration);
        await _context.SaveChangesAsync();
        return registration;
    }
}