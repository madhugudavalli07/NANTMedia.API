
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NANTMedia.API.Data;
using NANTMedia.API.DTOs;
using NANTMedia.API.Models;
using System.Security.Claims;

namespace NANTMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAd(CreateAdDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var ad = new Ad()
            {
                Title = dto.Title,
                Description = dto.Description,
                SubscriptionType = dto.SubscriptionType,
                Status = "Pending",
                UserId = int.Parse(userId)
            };
            if (dto.SubscriptionType == "Basic")
            {
                ad.Status = "Newspaper Only";
            }
            else if (dto.SubscriptionType == "Premium")
            {
                ad.Status = "Digital + Newspaper";
            }

            _context.Ads.Add(ad);

            await _context.SaveChangesAsync();

            return Ok("Ad Created Successfully");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAds()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var myAds = await _context.Ads
                .Where(x => x.UserId == int.Parse(userId))
                .ToListAsync();

            return Ok(myAds);
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAd(int id, UpdateAdDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var ad = await _context.Ads
                .FirstOrDefaultAsync(x =>
                    x.Id == id &&
                    x.UserId == int.Parse(userId));

            if (ad == null)
            {
                return NotFound("Ad not found");
            }

            ad.Title = dto.Title;
            ad.Description = dto.Description;
            ad.SubscriptionType = dto.SubscriptionType;

            await _context.SaveChangesAsync();

            return Ok("Ad Updated Successfully");
        }
    }
}