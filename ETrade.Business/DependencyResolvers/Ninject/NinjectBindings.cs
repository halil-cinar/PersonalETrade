using AutoMapper;
using Microsoft.VisualBasic;
using Ninject.Modules;

using ETrade.Dto.Dtos.Session;
using ETrade.Entities.Abstract;
using ETrade.Entities.Concrete;
using ETrade.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Core.Abstract.DataAccess;
using ETrade.DataAccess.EntityFrameworkCore;

namespace ETrade.Business.DependencyResolvers.Ninject
{
    public class NinjectBindings: NinjectModule
    {
        public override void Load()
        {
            Bind<BaseEntityValidator<ChatEntity>>()             .To<ChatValidator>();
            Bind<BaseEntityValidator<CommentEntity>>().To<CommentValidator>();
            Bind<BaseEntityValidator<CountryEntity>>().To<CountryValidator>();

            Bind<BaseEntityValidator<IdentityEntity>>()         .To<IdentityValidator>();
            Bind<BaseEntityValidator<MediaEntity>>()            .To<MediaValidator>();
            Bind<BaseEntityValidator<MessageEntity>>()          .To<MessageValidator>();
            
            Bind<BaseEntityValidator<RoleEntity>>()             .To<RoleValidator>();
            Bind<BaseEntityValidator<SessionEntity>>()          .To<SessionValidator>();
            Bind<BaseEntityValidator<SettingsEntity>>()         .To<SettingsValidator>();
            Bind<BaseEntityValidator<SystemSettingsEntity>>()   .To<SystemSettingsValidator>();
            Bind<BaseEntityValidator<UserChatEntity>>()         .To<UserChatValidator>();
            Bind<BaseEntityValidator<UserEntity>>()             .To<UserValidator>();
            Bind<BaseEntityValidator<UserRoleEntity>>().To<UserRoleValidator>();
            Bind<BaseEntityValidator<NotifyEntity>>().To<NotifyValidator>();
            Bind<BaseEntityValidator<MethodEntity>>().To<MethodValidator>();
            Bind<BaseEntityValidator<RoleMethodEntity>>().To<RoleMethodValidator>();







            Bind<IEntityDal<AddressEntity>>().To<EfEntityGenericRepository<AddressEntity>>();

            Bind<IEntityDal<ChatEntity>>().To<EfEntityGenericRepository<ChatEntity>>();
            Bind<IEntityDal<CommentEntity>>().To<EfEntityGenericRepository<CommentEntity>>();
            Bind<IEntityDal<CountryEntity>>().To<EfEntityGenericRepository<CountryEntity>>();

            Bind<IEntityDal<IdentityEntity>>()         .To<EfEntityGenericRepository<IdentityEntity>>();
             Bind<IEntityDal<MediaEntity>>()            .To<EfEntityGenericRepository<MediaEntity>>();
             Bind<IEntityDal<MessageEntity>>()          .To<EfEntityGenericRepository<MessageEntity>>();
             Bind<IEntityDal<RoleEntity>>()             .To<EfEntityGenericRepository<RoleEntity>>();
             Bind<IEntityDal<SessionEntity>>()          .To<EfEntityGenericRepository<SessionEntity>>();
             Bind<IEntityDal<SettingsEntity>>()         .To<EfEntityGenericRepository<SettingsEntity>>();
             Bind<IEntityDal<SystemSettingsEntity>>()   .To<EfEntityGenericRepository<SystemSettingsEntity>>();
             Bind<IEntityDal<UserChatEntity>>()         .To<EfEntityGenericRepository<UserChatEntity>>();
             Bind<IEntityDal<UserEntity>>()             .To<EfEntityGenericRepository<UserEntity>>();
             Bind<IEntityDal<UserRoleEntity>>()         .To<EfEntityGenericRepository<UserRoleEntity>>();
            Bind<IEntityDal<UserSettingsEntity>>()      .To<EfEntityGenericRepository<UserSettingsEntity>>();
            Bind<IEntityDal<NotifyEntity>>().To<EfEntityGenericRepository<NotifyEntity>>();
            Bind<IEntityDal<MethodEntity>>().To<EfEntityGenericRepository<MethodEntity>>();
            Bind<IEntityDal<RoleMethodEntity>>().To<EfEntityGenericRepository<RoleMethodEntity>>();




        }
    }
}
