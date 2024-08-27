using Microsoft.AspNetCore.Identity;

namespace QuickShop.Server.Services;

public class RoleServices
{
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<IdentityUser> userManager;

    public RoleServices(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }

    public async Task<List<string>> GetUserRolesAsync(string emailId)
    {
        var user = await userManager.FindByNameAsync(emailId);

        var userRole = await userManager.GetRolesAsync(user);
        return userRole.ToList();

    }
}
