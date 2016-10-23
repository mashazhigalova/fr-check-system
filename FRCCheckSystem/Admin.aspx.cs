using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FRCCheckSystem
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) // загрузка страницы
        {
            if (Request.Cookies["showAgainNorm"] != null) // открыть заново модальное окно после манипуляций
            {
                if (Server.HtmlEncode(Request.Cookies["showAgainNorm"].Value) == "1")
                {
                    btnNorms_Click(sender, e); // для окна с нормативными документами
                }
            }
            if (Request.Cookies["showAgainRules"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["showAgainRules"].Value) == "1")
                {
                    btnEditList_Click(sender, e); // для списка правил
                }
            }
        }
        protected void btnNorms_Click(object sender, EventArgs e) // обработка метода открытия модального окна
        {
            // открытие модального окна
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalNorms", "$('#myModalNorms').modal();", true);
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/NormDocs/")); // все файлы в папке
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridView1.DataSource = files; // отображение всех файлов на панели 
            GridView1.DataBind();
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            DownLoad(sender); // скачивание файла
        }

        protected void DeleteFile(object sender, EventArgs e)
        {
            Delete(sender, "showAgainNorm"); // удаление файла
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            Upload(FileUpload1, "~/App_Data/NormDocs/", "showAgainNorm"); // загрузка файла на сервер
        }

        protected void btnEditList_Click(object sender, EventArgs e) // редактирование правил оформления
        {
            // открытие модального окна
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalNorms", "$('#myModalRules').modal();", true);
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/RulesRepository/")); // путь к файлам папки
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths) // для каждого файла в папке с правилами
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath)); // запись в список названий
            }
            GridView2.DataSource = files; // отображение на панели
            GridView2.DataBind();
        }

        protected void btnUploadRules_Click(object sender, EventArgs e)
        {
            Upload(FileUpload2, "~/App_Data/RulesRepository/", "showAgainRules"); // загрузка новых правил на сервер
        }

        protected void lnkDownloadRules_Click(object sender, EventArgs e)
        {
            DownLoad(sender); // скачивание правил оформления
        }

        protected void lnkDeleteRules_Click(object sender, EventArgs e)
        {
            Delete(sender, "showAgainRules"); // удаление правил
        }

        private void Delete(object sender, string cookie) // метод удаления
        {
            string filePath = (sender as LinkButton).CommandArgument; // имя файла по ссылке
            File.Delete(filePath); // удаление файла
            Response.Cookies[cookie].Value = "1";
            Response.Redirect(Request.Url.AbsoluteUri + "#Check"); // перенаправление на страницу проверки
        }
        private void Upload(FileUpload fupl, string path, string cookie) // загрузка документа
        {
            if (fupl.HasFile)  // если файл выбран
                try
                {
                    if (!fupl.FileName.Contains(".docx")) // проверка на поддерживаемый формат
                    {
                        // сообщение об ошибке
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey",
                            "<script>alert('Формат загружаемого файла не поддерживается.');</script>");
                        return;
                    }
                    string fileName = Path.GetFileName(fupl.PostedFile.FileName);
                    fupl.PostedFile.SaveAs(Server.MapPath(path) + fileName); // сохранение файла
                    Response.Cookies[cookie].Value = "1";
                    Response.Redirect(Request.Url.AbsoluteUri + "#Check");
                }
                catch    // ошибка, если файл не выбран
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Файл не выбран');</script>");
                }
        }

        private void DownLoad(object sender) // загрузка документа
        {
            string filePath = (sender as LinkButton).CommandArgument; // получение файла по ссылке
            Response.ContentType = ContentType; // тип контента
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath); 
            Response.End();
        }
    }
}