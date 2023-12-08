using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCApp.Models
{
    public partial class musicPlaylistContext : DbContext
    {
        public musicPlaylistContext()
        {
        }

        public musicPlaylistContext(DbContextOptions<musicPlaylistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;database=musicPlaylist");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PRIMARY");

                entity.ToTable("playlist");

                entity.HasIndex(e => e.Userid, "userid");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.NumOfSongs).HasColumnName("num_of_songs");

                entity.Property(e => e.PName)
                    .HasMaxLength(50)
                    .HasColumnName("pName");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("playlist_ibfk_1");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("playlist_song");

                entity.HasIndex(e => e.PId, "pId");

                entity.HasIndex(e => e.SId, "sId");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.SId).HasColumnName("sId");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("playlist_song_ibfk_1");

                entity.HasOne(d => d.SIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SId)
                    .HasConstraintName("playlist_song_ibfk_2");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PRIMARY");

                entity.ToTable("song");

                entity.Property(e => e.SId).HasColumnName("sId");

                entity.Property(e => e.SName)
                    .HasMaxLength(50)
                    .HasColumnName("sName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Fname)
                    .HasMaxLength(35)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(35)
                    .HasColumnName("lname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
