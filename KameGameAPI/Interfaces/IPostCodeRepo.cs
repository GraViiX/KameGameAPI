using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Interfaces
{
    public interface IPostCodeRepo
    {
        Task<ActionResult<IEnumerable<PostcodeModel>>> GetpostcodesRepo();
    }
}
