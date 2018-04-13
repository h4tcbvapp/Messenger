using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class PartyTypeDAL
    {
        public string GetPartyTypes()
        {
            using (var context = new bvappContext())
            {
                var query = (from b in context.PartyType
                             select b);
                if (query != null)
                    return JsonConvert.SerializeObject(query);
            }

            return string.Empty;
        }
    }
}
