using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("UserSettings")]
    public class UserSettingsEntity:EntityBase
    {
        [Column("userId")]
        public long UserId { get; set; }

        [Column("settingId")]
        public long SettingId { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("SettingId")]
        public virtual SettingsEntity Settings { get; set; }



    }
}
