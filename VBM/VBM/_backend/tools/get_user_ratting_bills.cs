﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using vbm.objs;

namespace vbm
{
    public partial class tools
    {
        public async Task<internal_contact> get_user_ratting_bills(string username, long userid)
        {
            try
            {
                string url = $"{input_data.user_rating_bills_url}?sdt={username}&userid={userid}";
                using (var cl = new HttpClient())
                {
                    var response = await cl.GetAsync(url);
                    var js = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<api_trans>(js);
                    if (result.success)
                    {
                        var data = new internal_contact { success = true, data = result.Data, err_type = 0 };
                        return data;
                    }
                    else
                    {
                        var data = new internal_contact { success = false, data = result.Data, err_type = 1 };
                        return data;
                    }
                }
            }
            catch (Exception e)
            {
                var data = new internal_contact { success = false, data = e.Message, err_type = 2 };
                return data;
            }
        }
    }
}
