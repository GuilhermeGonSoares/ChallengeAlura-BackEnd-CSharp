using ChallengeAluraBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAluraBackEnd.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options) {}
        public DbSet<Video> Videos { get; set; } = null!;
    }
}