using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;

namespace FRCCheckSystem
{
    /// <summary>
    /// Загрузчик
    /// </summary>
    public static class Downloader // класс-загрузчик файлов
    {
        public static void Download(string sFileName, string sFilePath)
        {
            HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
            if (sFileName.Contains("Temp/")) // проверить, содержит ли имя файла Temp
                sFileName = sFileName.Replace("Temp/", "");
            String Header = "Attachment; Filename=" + sFileName; // имя файла в загрузчике
            HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
            FileInfo Dfile = new FileInfo(HttpContext.Current.Server.MapPath(sFilePath)); // полное имя файла
            HttpContext.Current.Response.WriteFile(Dfile.FullName);
            HttpContext.Current.Response.End(); // окончание процесса загрузки
        }

    }
    public partial class Default : System.Web.UI.Page
    {
        protected void btnNorms_Click(object sender, EventArgs e)
        {
            // открытие модального окна методами JavaScript
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalNorms", "$('#myModalNorms').modal();", true);
            // получение имен документа
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/NormDocs/"));
            List<ListItem> files = new List<ListItem>(); // имена файлов
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridView1.DataSource = files; // заполнение таблицы для отображения
            GridView1.DataBind();
        }
        protected void DownloadFile(object sender, EventArgs e) // загрузка файла с панели
        {
            string filePath = (sender as LinkButton).CommandArgument; // имя файла по ссылке
            Response.ContentType = ContentType; // тип контента
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath); // загрузка файла в поток
            Response.End();
        }

        protected void btnLogin_Click(object sender, EventArgs e) // вход на сайт
        {
            string log = login.Value; // получение значения логина
            string password = inputPassword.Value; // значение пароля
            if (log == "" || password == "")
            {
                // обработка ошибки при неверном логине или пароле
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Неверный логин/пароль');</script>");
            }
            else if (log == "admin" && password == "123") // если данные введены верно
            {
                ExpireAllCookies(); // уничтожение всех Cookie из сессии пользователя
                Response.Redirect("Admin.aspx");
            }
        }

        private void ExpireAllCookies() // удаление Cookie из массива
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count; // количество в массиве
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i]; // текущий Cookie
                    if (cookie != null)
                    {
                        var cookieName = cookie.Name; //имя текущего Cookie
                        // удаление Cookie
                        var expiredCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }
                // удаление Cookie на стороне сервера
                HttpContext.Current.Request.Cookies.Clear();
            }
        }
        
    }
}