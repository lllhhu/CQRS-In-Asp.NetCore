using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //开发环境开启自动创建表结构功能
#if DEBUG
            this.Database.EnsureCreated();
#endif

        }


        public DbSet<CQRS.Domain.Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region 
            modelBuilder.Entity<CQRS.Domain.Order>().ToTable("Order");
            modelBuilder.Entity<CQRS.Domain.OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<CQRS.Domain.OrderItem>().OwnsOne(c => c.Product);//（值对象）复杂类型映射
            modelBuilder.Entity<CQRS.Domain.Order>().HasMany(m => m.OrderItems);// 使用简单方式配置一对多关系
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
