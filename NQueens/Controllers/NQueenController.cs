using NQueens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace NQueens.Controllers
{
    public class NQueenController : SurfaceController
    {
        [ChildActionOnly]
        public ActionResult GetNQ()
        {
            return PartialView("ViewNQView", (new NQ()));

        }

        [NotChildAction]
        public ActionResult GetNQNum(int numberofqueens)
        {
            NQ tempNQ = new NQ(numberofqueens);

            return PartialView("ViewNQView", tempNQ);

        } 
    }
}