using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Entities
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<RComment> RComment { get; set; }
        public virtual DbSet<RCounter> RCounter { get; set; }
        public virtual DbSet<RFreeTip> RFreeTip { get; set; }
        public virtual DbSet<RLeague> RLeague { get; set; }
        public virtual DbSet<RMatch> RMatch { get; set; }
        public virtual DbSet<RPageDetails> RPageDetails { get; set; }
        public virtual DbSet<RSeo> RSeo { get; set; }
        public virtual DbSet<RSeoDetails> RSeoDetails { get; set; }
        public virtual DbSet<RTeam> RTeam { get; set; }
        public virtual DbSet<RVipTicket> RVipTicket { get; set; }
        public virtual DbSet<TicketTemplates> TicketTemplates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= 107.151.3.34\\MSSQLSERVER2012;Initial Catalog=bestfixedmatches1x2;user id=freefixe_losko;password=jDb*1T4BPiTyt!$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "freefixe_losko");

            modelBuilder.Entity<RComment>(entity =>
            {
                entity.ToTable("rComment");

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RCounter>(entity =>
            {
                entity.ToTable("rCounter", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RCounterId).HasColumnName("rCounterID");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<RFreeTip>(entity =>
            {
                entity.ToTable("rFreeTip", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RFreeTipId).HasColumnName("rFreeTipID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Odd).HasMaxLength(50);

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.Property(e => e.Tip).HasMaxLength(50);

                entity.Property(e => e.WinLose).HasMaxLength(50);
            });

            modelBuilder.Entity<RLeague>(entity =>
            {
                entity.ToTable("rLeague");

                entity.Property(e => e.RLeagueId).HasColumnName("rLeagueId");

                entity.Property(e => e.FCheck).HasColumnName("f_check");

                entity.Property(e => e.LeagueName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<RMatch>(entity =>
            {
                entity.ToTable("rMatch", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RMatchId).HasColumnName("rMatchID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Odd).HasMaxLength(50);

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.Property(e => e.Tip).HasMaxLength(50);

                entity.Property(e => e.WinLose).HasMaxLength(50);
            });

            modelBuilder.Entity<RPageDetails>(entity =>
            {
                entity.ToTable("rPageDetails", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RPageDetailsId).HasColumnName("rPageDetailsID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RSeo>(entity =>
            {
                entity.ToTable("rSeo", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RSeoId).HasColumnName("rSeoID");

                entity.Property(e => e.Page).HasMaxLength(250);
            });

            modelBuilder.Entity<RSeoDetails>(entity =>
            {
                entity.ToTable("rSeoDetails", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RSeoDetailsId).HasColumnName("rSeoDetailsID");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasMaxLength(150);

                entity.Property(e => e.ImgAlt)
                    .HasColumnName("imgAlt")
                    .HasMaxLength(200);

                entity.Property(e => e.Keywords).HasMaxLength(500);

                entity.Property(e => e.Page).HasMaxLength(150);

                entity.Property(e => e.RelatedKeyword).HasMaxLength(500);

                entity.Property(e => e.Text).HasColumnType("ntext");
            });

            modelBuilder.Entity<RTeam>(entity =>
            {
                entity.ToTable("rTeam");

                entity.Property(e => e.RTeamId).HasColumnName("rTeamId");

                entity.Property(e => e.FCheck).HasColumnName("f_check");

                entity.Property(e => e.RLeagueId).HasColumnName("rLeagueId");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RLeague)
                    .WithMany(p => p.RTeam)
                    .HasForeignKey(d => d.RLeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rTeam_rLeague");
            });

            modelBuilder.Entity<RVipTicket>(entity =>
            {
                entity.ToTable("rVipTicket", "freefixe_bestfixedmatches1x2");

                entity.Property(e => e.RVipTicketId).HasColumnName("rVipTicketID");

                entity.Property(e => e.Alt).HasMaxLength(500);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TicketTemplates>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Html).IsRequired();
            });
        }
    }
}
