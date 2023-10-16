using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Abstract
{
    public class EntityBase:IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Column("isDeleted")]
        public bool isDeleted { get; set; }

        [Column("isDeletable")]
        public bool? isDeletable { get; set; }

        [Column("createUserName")]
        public string CreateUserName { get; set; }

        [Column("createIpAddress")]
        public string CreateIPAddress { get; set; }

        [Column("createTime")]
        public DateTime CreateTime { get; set; }


        [Column("updateUserName")]
        public string UpdateUserName { get; set; }

        [Column("updateIpAddress")]
        public string UpdateIpAddress { get; set; }

        [Column("updateTime")]
        public DateTime? UpdateTime { get; set; }


        [Column("lastTransaction")]
        public string LastTransaction { get; set; }



    }
}
