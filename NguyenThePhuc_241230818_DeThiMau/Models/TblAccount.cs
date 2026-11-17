using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NguyenThePhuc_241230818_DeThiMau.Models;

[Table("tblAccount")]
public partial class TblAccount
{
    [Key]
    public int Uid { get; set; }

    [StringLength(10)]
    public string? Username { get; set; }

    [StringLength(10)]
    public string? Password { get; set; }
}
