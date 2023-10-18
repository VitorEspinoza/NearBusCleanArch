using Microsoft.AspNetCore.Identity;
using NearBusCleanArch.Domain.Account;

namespace NearBusCleanArch.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void seedUsers()
    {
    }

    public void seedRoles()
    {
        if (!_roleManager.RoleExistsAsync("companie").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Companie";
            role.NormalizedName = "COMPANIE";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
        
        if (!_roleManager.RoleExistsAsync("employee").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "employee";
            role.NormalizedName = "EMPLOYEE";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }
}