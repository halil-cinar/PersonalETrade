namespace ETrade.DataAccess.Migrations
{
    using EnumsNET;
    using ETrade.Core.Utils;
    using ETrade.Entities.Concrete;
    using ETrade.Entities.Enums;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ETrade.DataAccess.EntityFrameworkCore.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ETrade.DataAccess.EntityFrameworkCore.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           
            
            
            if(context.Users.Any())
            {
                return;
            }

           


            #region MethodAdd
            var list = Enum.GetValues(typeof(MethodList));
            foreach( var item in list)
            {
                var methodDesc=((MethodList)item).AsString(EnumFormat.Description);
                    
                var method = new MethodEntity
                {
                    CreateIPAddress = "",
                    CreateTime = DateTime.Now,
                    CreateUserName = "",
                    Description = methodDesc!=null?methodDesc:"None",
                    isDeleted = false,
                    Key = (MethodList)item,
                    Name = Enum.GetName<MethodList>((MethodList)item),
                    LastTransaction = "migrationAdd"
                };
                context.Methods.Add(method);

            }
            context.SaveChanges();

            #endregion


            #region AdminAdd 

            var adminUser = new UserEntity
            {
                BirthDate = DateTime.Now,
                Email = "",
                Gender = 0,
                isDeleted = false,
                CreateTime = DateTime.Now,
                Name = "Admin",
                Surname = "Admin",
                Phone = "00000000000",
                IdentityNumber = "00000000000",
                LastTransaction = "migrationsAdd",
                CreateIPAddress = "127.0.0.1",
                CreateUserName = "migration"
            };
            context.Users.Add(adminUser);
            context.SaveChanges();

            var adminRole = new RoleEntity
            {
                CreateIPAddress = "127.0.0.1",
                CreateUserName = "migration",
                isDeleted = false,
                CreateTime = DateTime.Now,
                Description = "Admin",
                Name = "Admin",
                LastTransaction = "migrationAdd"
            };
            context.Roles.Add(adminRole);
            context.SaveChanges();

            var adminUserRole = new UserRoleEntity
            {
                CreateIPAddress = "127.0.0.1",
                IsActive = true,
                CreateTime = DateTime.Now,
                CreateUserName = "migration",
                isDeleted = false,
                RoleId = adminRole.ID,
                UserId = adminUser.ID,
                LastTransaction = "migrationAdd"
            };
            context.UserRoles.Add(adminUserRole);   
            context.SaveChanges();

            var identitySalt=ExtensionMethods.GenerateRandomString(10);

            var adminIdentity = new IdentityEntity
            {
                isActive = true,
                isDeleted = false,
                CreateTime = DateTime.Now,
                CreateIPAddress = "127.0.0.1",
                CreateUserName = "migration",
                UserId = adminUser.ID,
                UserName = "admin",
                PasswordSalt = identitySalt,
                PasswordHash = ExtensionMethods.CalculateMD5Hash("As12345+" + identitySalt),

            };
            context.Identities.Add(adminIdentity);  
            context.SaveChanges();


            var adminRoleMethods = context.Methods.ToList().Select(x => new RoleMethodEntity
            {
                isDeleted= false,
                CreateTime= DateTime.Now,
                CreateIPAddress = "127.0.0.1",
                CreateUserName="",
                MethodId=x.ID,
                RoleId=adminRole.ID,
                LastTransaction="migrationAdd",
                
            }).ToList();

            foreach(var roleMethod in adminRoleMethods)
            {
                context.RoleMethods.Add(roleMethod);
                
            }
            context.SaveChanges();



            #endregion

            #region createViews

            var viewCreateCodes = new List<string>
            {
               "create view [dbo].[RoleMethodListView] \nas select\nRM.ID,\n      RM.roleId,\n      RM.methodId,\n      RM.expiryDate,\n      RM.isDeleted,\n      RM.createUserName,\n      RM.createIpAddress,\n      RM.createTime,\n      RM.updateUserName,\n      RM.updateIpAddress,\n      RM.updateTime,\n      RM.lastTransaction,\n\t  R.name as roleName,\n      R.description as roleDescription,\n\t  M.[key] as methodKey,\n      M.name as methodname,\n      M.description as methodDescription\nfrom RoleMethod RM \nleft join Role R on RM.roleId=R.ID\nleft join Method M on RM.methodId=M.ID\nwhere M.isDeleted=0 ",
               "CREATE view [dbo].[SessionListView] \r\nas select \r\nS.ID\r\n      ,S.identityId\r\n      ,S.userId\r\n      ,S.expiryDate\r\n      ,S.ipAddress\r\n      ,S.deviceType\r\n      ,S.notifyToken\r\n      ,S.token\r\n\t  ,S.isActive\r\n\t  ,U.name\r\n      ,U.surname\r\n      ,U.email\r\n      ,U.phoneNumber\r\n      ,U.gender\r\n      ,U.birthDate\r\n      ,U.identityNumber,\r\n\t  U.profilePhotoId\r\n\t  ,S.isDeleted\r\n\t  ,I.userName\r\n\t  \r\n\t  ,S.createUserName, S.createIpAddress, S.createTime, S.updateUserName, S.updateIpAddress, S.updateTime, S.lastTransaction\r\nfrom Session S \r\nleft join [User] U on S.userId=U.Id\r\nleft join [Identity] I on S.identityId=I.Id\r\nwhere S.isDeleted=0",
               
            };


            viewCreateCodes.ForEach(x =>
            {
                context.Database.ExecuteSqlCommand(x);
            });
            context.SaveChanges();

            #endregion
        }
    }
}
