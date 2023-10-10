using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Settings")]
    public class SettingsEntity:EntityBase
    {
     

        [Column("key")]
        public string Key { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("defaultValue")]
        public string DefaultValue { get; set; }

    }
}
