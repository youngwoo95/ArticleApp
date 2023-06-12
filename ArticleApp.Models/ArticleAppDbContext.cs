﻿using ArticleApp.Models.Articles;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ArticleApp.Models
{
    /// <summary>
    /// DbContext Class
    /// </summary>
    public class ArticleAppDbContext : DbContext
    {
        // Install-Packaged Microsoft.EntityFrameworkCore.SqlServer
        // Install-Packaged Microsoft.EntityFrameworkCOre.InMemory
        // Install-Packaged System.Configuration.ConfigurationManager
        public ArticleAppDbContext()
        {
            // Empty
        }
        public ArticleAppDbContext(DbContextOptions<ArticleAppDbContext> options) : base(options)
        {
            // 공식과 같은 코드

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역 : 
            // App.Config 또는 Web.Config의 연결 문자열 사용
            /*
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
            */
            optionsBuilder.UseSqlServer(@"Server=192.168.45.94,1433;Database=ArticleApp;User Id=sa2;Password=wegg2650;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //[A] Articles 테이블의 Created 열은 자동으로 GetDate() 제약 조건을 부여하기
            modelBuilder.Entity<Article>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
        }

        //[!] ArticleApp 관련 모들 테이블 참조
        public DbSet<Article> Articles { get; set; }

    }
}
