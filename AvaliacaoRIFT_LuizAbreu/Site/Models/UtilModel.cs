using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class UtilModel
    {
        public string MensagemRetorno
        {
            get
            {
                if (HttpContext.Current.Session["MensagemRetorno"] != null)
                {
                    return HttpContext.Current.Session["MensagemRetorno"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session.Add("MensagemRetorno", value);
            }
        }
        public bool StatusLogin
        {
            get
            {
                if (HttpContext.Current.Session["StatusLogin"] != null)
                {
                    return (bool)HttpContext.Current.Session["StatusLogin"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session.Add("StatusLogin", value);
            }
        }
        public void LimpaMensagemRetorno()
        {
            MensagemRetorno = "";
        }
        public string ObterURL()
        {
            string retorno = "";
            try
            {
                var context = HttpContext.Current;
                retorno = $"{context.Request.Url.Scheme}://{context.Request.Url.Authority}{context.Request.ApplicationPath}";
            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
        }
    }
}