using ETrade.Entities.Abstract;
using ETrade.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    [Table("Media")]
    public class MediaEntity:EntityBase
    {
        [Column("entityType")]
        public EntityType? EntityType { get; set; }

        [Column("entityId")]
        public long? EntityId { get; set; }

        [Column("fileType")]
        public FileType FileType { get; set; }

        [Column("contentType")]
        public string ContentType { get; set; }

        [Column("fileName")]
        public string FileName { get; set; }

        [Column("content")]
        public byte[] Content { get; set; }


        public virtual ICollection<MessageMediaEntity> MessageMedias { get; set; }



    }
}
