using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.EntityFrameworkCore
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("server=DESKTOP-FOCIP6T;Initial Catalog=PersonalETradeDatabase;Integrated Security=True;")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            


            base.OnModelCreating(modelBuilder);
        }






        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<BrandEntity> Brands { get; set; }

        public DbSet<CarouselItemEntity> CarouselItems { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<ChatEntity> Chats { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<CurrencyEntity> Currencies { get; set; }

        public DbSet<DeliveryOptionEntity> DeliveryOptions { get; set;}

        public DbSet<GenderEntity> Genders { get; set; }

        public DbSet<IdentityEntity> Identities { get; set; }

        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<ProductCommentEntity> ProductComments { get; set; }

        public DbSet<ProductEntity>Products { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        
        public DbSet<UserAddressEntity> UserAddresses { get; set; }

        public DbSet<UserChatEntity> UserChats { get; set; }

        public DbSet<UserEntity> Users { get; set;}

        public DbSet<UserRoleEntity> UserRoles { get; set; }

        public DbSet<MediaEntity> Medias { get; set; }

        public DbSet<StatusEntity> Statuses { get; set; }

        public DbSet<SessionEntity> Sessions { get; set; }

        public DbSet<MethodEntity> Methods { get; set; }    

        public DbSet<RoleMethodEntity> RoleMethods { get; set; }

        //Views

        public DbSet<RoleMethodListEntity> RoleMethodLists { get; set; }

        public DbSet<SessionListEntity> SessionLists { get; set; }

    }
}
