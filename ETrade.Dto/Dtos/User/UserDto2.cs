using ETrade.Dto.Dtos.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.User
{
    public class UserDto2
    {
        [Column("name")]
        public string Name { get; set; }


        [Column("surname")]
        public string Surname { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phoneNumber")]
        public string Phone { get; set; }

        [Column("identityNumber")]
        public string IdentityNumber { get; set; }



        [Column("profilePhoto")]
        public MediaListDto? ProfilePhoto { get; set; }

        [Column("genderId")]
        public long GenderId { get; set; }


        [Column("birthDate")]
        public DateTime? BirthDate { get; set; }
    }
}
