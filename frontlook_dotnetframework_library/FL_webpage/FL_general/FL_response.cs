﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontlook_dotnetframework_library.FL_webpage.FL_general
{
    public class FL_response
    {
        public static string FL_message(string message)
        {
            return "<script language='javascript'>" +
                   "window.alert('" +
                   message + "');" +
                   "</script>";
        }

        public static string FL_message(string message, string redirect)
        {
            return "<script language='javascript'>" +
                   "window.alert('Salary Head Is Already Present With Name " +
                   message + "');" +
                   "window.location='" + redirect + "';" +
                   "</script>";
        }
    }
}
