using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VBM.ctrls.alert
{
    public class alert_tools
    {
        public static async Task<bool> alert(string body, string btn_text, TaskCompletionSource<alert_obj> tcs)
        {
            //var page2 = new yesno_option(tcs);
            //await PopupNavigation.Instance.PushAsync(page2);
            //var result = await tcs.Task;
            return true;
        }

    }

    public class alert_obj
    {
        public int id { get; set; }
        public bool option_yesno { get; set; }
        public string option_multi { get; set; }
    }

}
